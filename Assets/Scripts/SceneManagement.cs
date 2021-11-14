using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance;
    
    
    [SerializeField] private GameObject sceneParentInventory;
    [SerializeField] private GameObject sceneParentExamine;
    [SerializeField] private GameObject sceneParentDiscussion;

    [SerializeField] private InitObservableObject _initObservableObject;
    [SerializeField] private AdaptativeText _adaptativeText;

    void Awake()
    {
        Instance = this;
    }
    
    
    public void ExamineObject()
    {
        if (IsItemSelect.IsItemAlreadySelect())
        {
            StaticObject.activeObject = IsItemSelect.GetItemSelect().GetComponent<ItemScript>().GetPrefab();
            InventoryToExamine();
            _initObservableObject.SetNewObject();
            _adaptativeText.SetDescription();
        }
    }


    public void DiscussionToInventory()
    {
        sceneParentDiscussion.GetComponent<SaveScene>().DisactiveScene();
        sceneParentInventory.GetComponent<SaveScene>().ActiveScene();
    }

    public void InventoryToDiscussion()
    {

        sceneParentInventory.GetComponent<SaveScene>().DisactiveScene();
        sceneParentDiscussion.GetComponent<SaveScene>().ActiveScene();
    }

    public void InventoryToExamine()
    {
        sceneParentExamine.GetComponent<SaveScene>().ActiveScene();
        sceneParentInventory.GetComponent<SaveScene>().DisactiveScene();

    }
    
    public void ExamineToInventory()
    {
        Debug.Log("On clique dessus");
        sceneParentExamine.GetComponent<SaveScene>().DisactiveScene();
        sceneParentInventory.GetComponent<SaveScene>().ActiveScene();
        _initObservableObject.CloseObject();
    }
    
    
}
