using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemScript : MonoBehaviour, IPointerDownHandler
{
    private string _name;
    
    private bool _sold = false;
    
    private GameObject _prefab3D;
    
    public float _price = 100;
    
    private float _priceSold;

    public int id;

    public bool eventDeclenched;
    
    public Sprite _selection;
    private GameObject selection;
    private GameObject spriteSelection;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //On active l'event que si le joueur effectue l'action de l'objet dans l'examination
        eventDeclenched = false;
        
        //DontDestroyOnLoad(gameObject);
       
        if (_sold)
        {
           gameObject.SetActive(false); 
        }
        
        _priceSold = _price;
        
         //creation de l'objet et de ses differents composants
        _name = gameObject.name;
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + gameObject.name);
        _prefab3D = Resources.Load<GameObject>("Prefabs/" + gameObject.name);

        gameObject.AddComponent<BoxCollider2D>();
        
        
        //creation du fond indiquant qu'oin a selectionné l'objet
        selection = new GameObject("Selection");
        selection.transform.SetParent(transform);
        selection.transform.localPosition = new Vector3(0, 0, 2);
        selection.transform.localScale = new Vector3(1, 1, 1);
        selection.AddComponent<Image>().sprite = _selection;
        selection.GetComponent<RectTransform>().anchorMax = Vector2.one;
        selection.GetComponent<RectTransform>().anchorMin = Vector2.zero;
        selection.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        selection.GetComponent<RectTransform>().sizeDelta = Vector2.one;
                
        spriteSelection = new GameObject("Sprite");
        spriteSelection.transform.SetParent(transform);
        spriteSelection.transform.localPosition = new Vector3(0, 0, 2);
        spriteSelection.transform.localScale = new Vector3(1, 1, 1);
        spriteSelection.AddComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + gameObject.name);;
        spriteSelection.GetComponent<RectTransform>().anchorMax = Vector2.one;
        spriteSelection.GetComponent<RectTransform>().anchorMin = Vector2.zero;
        spriteSelection.GetComponent<RectTransform>().sizeDelta = Vector2.one;
        
        spriteSelection.SetActive(false);
        selection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pntEvt)
    {
        IsItemSelect.SelectAnItem(gameObject);
    }

    public void DisappearSelection()
    {
        selection.SetActive(false);
        spriteSelection.SetActive(false);
    }

    public void AppearSelection()
    {
        selection.SetActive(true);
        spriteSelection.SetActive(true);
    }

    public void ChangePriceSold(float amount)
    {
        _priceSold += amount;
    }

    
    public void ChangePrice(float amount)
    {
        _price += amount;
    }
    
    public float GetPriceItemSold()
    {
        return _priceSold;
    }
    public float GetPriceItem()
    {
        return _price;
    }

    public GameObject GetPrefab()
    {
        return _prefab3D;
    }

    public string GetName()
    {
        return _name;
    }
    
}
