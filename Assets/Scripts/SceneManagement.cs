using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private GameObject sceneParentInventory;
    [SerializeField] private GameObject sceneParentExamine;
    [SerializeField] private GameObject sceneParentDiscussion;


    public void ExamineObject()
    {
        if (IsItemSelect.IsItemAlreadySelect())
        {
            StaticObject.activeObject = IsItemSelect.GetItemSelect().GetComponent<ItemScript>().GetPrefab();
            InventoryToExamine();
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
    }
    
    
}
