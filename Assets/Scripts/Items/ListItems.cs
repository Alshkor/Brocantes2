using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ListItems : MonoBehaviour
{
    private List<GameObject> _items;
    [SerializeField] private Sprite bg;
    public static ListItems Instance;

    void Awake()
    {
        Instance = this;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        _items = new List<GameObject>();
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            _items.Add(transform.GetChild(i).gameObject);
        }
        
        
        ListItemsJSon _listItems = new ListItemsJSon();

        var jsonFiles = Resources.Load<TextAsset>("objects_cycle" + Mathf.Clamp(NumberDay.GetDay(),1,2));
        
        _listItems = JsonUtility.FromJson<ListItemsJSon>(jsonFiles.ToString());

        
        int j = 0;
        foreach (var truc in _listItems.ListObjects)
        {
            GameObject item = _items[j];
            item.name = truc.objectName;
            item.AddComponent<Image>();
            item.AddComponent<ItemScript>();
            item.GetComponent<ItemScript>()._selection = bg;
            item.GetComponent<ItemScript>()._price = truc.recommandedPrice;
            item.GetComponent<ItemScript>().id = truc.idObject;
            j++;
        }
    }


    public void GetItemNextIt()
    {
        _items = new List<GameObject>();
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            _items.Add(transform.GetChild(i).gameObject);
        }
        
        
        ListItemsJSon _listItems = new ListItemsJSon();

        var jsonFiles = Resources.Load<TextAsset>("objects_cycle2");
        
        _listItems = JsonUtility.FromJson<ListItemsJSon>(jsonFiles.ToString());

        
        int j = 0;
        foreach (var truc in _listItems.ListObjects)
        {
            GameObject item = _items[j];
            item.name = truc.objectName;
            item.AddComponent<Image>();
            item.AddComponent<ItemScript>();
            item.GetComponent<ItemScript>()._selection = bg;
            item.GetComponent<ItemScript>()._price = truc.recommandedPrice;
            item.GetComponent<ItemScript>().id = truc.idObject;
            j++;
        }
    } 
}




public class ListItemsJSon
{
    public List<Items> ListObjects;
}

[Serializable]
public class Items
{
    public float recommandedPrice;

    public string objectName;

    public int idObject;
}
