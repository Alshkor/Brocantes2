using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance;

    public static string _openScene;
    
    [SerializeField] private SaveScene sceneParentInventory;
    [SerializeField] private SaveScene sceneParentExamine;
    [SerializeField] private SaveScene sceneParentDiscussion;

    [SerializeField] private SaveScene sceneParentLooseGold;
    [SerializeField] private SaveScene sceneParentLooseRep;
    
    [SerializeField] private SaveScene sceneParentEndingVeryGood;
    [SerializeField] private SaveScene sceneParentEndingBonte;
    [SerializeField] private SaveScene sceneParentEndingMoulaga;
    [SerializeField] private SaveScene sceneParentEndingVeryBad;
    [SerializeField] private SaveScene sceneParentEndingNeutral;

    [SerializeField] private SaveScene sceneChangementDay;
    
    [SerializeField] private InitObservableObject _initObservableObject;
    [SerializeField] private AdaptativeText _adaptativeText;

    void Awake()
    {
        Instance = this;
        _openScene = "Discussion";
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
        _openScene = "Inventory";
        sceneParentDiscussion.DisactiveScene();
        sceneParentInventory.ActiveScene();
    }

    public void InventoryToDiscussion()
    {
        _openScene = "Discussion";
        sceneParentInventory.DisactiveScene();
        sceneParentDiscussion.GetComponent<SaveScene>().ActiveScene();
    }

    public void InventoryToExamine()
    {
        sceneParentExamine.ActiveScene();
        sceneParentInventory.DisactiveScene();
        _openScene = "Examine";
    }
    
    public void ExamineToInventory()
    {
        _openScene = "Inventory";
        sceneParentExamine.DisactiveScene();
        sceneParentInventory.ActiveScene();
        _initObservableObject.CloseObject();
    }

    public void SceneToLooseGold()
    {
        switch (_openScene)
        {
            case "Inventory":
                sceneParentInventory.DisactiveScene();
                sceneParentLooseGold.ActiveScene();
                break;
            case "Examine":
                sceneParentExamine.DisactiveScene();
                sceneParentLooseGold.ActiveScene();
                break;
            case "Discussion":
                sceneParentDiscussion.DisactiveScene();
                sceneParentLooseGold.ActiveScene();
                break;
        }
    }
    public void SceneToLooseRep()
    {
        switch (_openScene)
        {
            case "Inventory":
                sceneParentInventory.DisactiveScene();
                sceneParentLooseRep.ActiveScene();
                break;
            case "Examine":
                sceneParentExamine.DisactiveScene();
                sceneParentLooseRep.ActiveScene();
                break;
            case "Discussion":
                sceneParentDiscussion.DisactiveScene();
                sceneParentLooseRep.ActiveScene();
                break;
        }
    }

    public void SceneToGoodEnding()
    {
        switch (_openScene)
        {
            case "Inventory":
                sceneParentInventory.DisactiveScene();
                sceneParentEndingVeryGood.ActiveScene();
                break;
            case "Examine":
                sceneParentExamine.DisactiveScene();
                sceneParentEndingVeryGood.ActiveScene();
                break;
            case "Discussion":
                sceneParentDiscussion.DisactiveScene();
                sceneParentEndingVeryGood.ActiveScene();
                break;
        }
    }    public void SceneToBonteEnding()
    {
        switch (_openScene)
        {
            case "Inventory":
                sceneParentInventory.DisactiveScene();
                sceneParentEndingBonte.ActiveScene();
                break;
            case "Examine":
                sceneParentExamine.DisactiveScene();
                sceneParentEndingBonte.ActiveScene();
                break;
            case "Discussion":
                sceneParentDiscussion.DisactiveScene();
                sceneParentEndingBonte.ActiveScene();
                break;
        }
    }    public void SceneToMoulagaEnding()
    {
        switch (_openScene)
        {
            case "Inventory":
                sceneParentInventory.DisactiveScene();
                sceneParentEndingMoulaga.ActiveScene();
                break;
            case "Examine":
                sceneParentExamine.DisactiveScene();
                sceneParentEndingMoulaga.ActiveScene();
                break;
            case "Discussion":
                sceneParentDiscussion.DisactiveScene();
                sceneParentEndingMoulaga.ActiveScene();
                break;
        }
    }    public void SceneToBadEnding()
    {
        switch (_openScene)
        {
            case "Inventory":
                sceneParentInventory.DisactiveScene();
                sceneParentEndingVeryBad.ActiveScene();
                break;
            case "Examine":
                sceneParentExamine.DisactiveScene();
                sceneParentEndingVeryBad.ActiveScene();
                break;
            case "Discussion":
                sceneParentDiscussion.DisactiveScene();
                sceneParentEndingVeryBad.ActiveScene();
                break;
        }
    }
    
    public void SceneToNeutralEnding()
    {
        switch (_openScene)
        {
            case "Inventory":
                sceneParentInventory.DisactiveScene();
                sceneParentEndingNeutral.ActiveScene();
                break;
            case "Examine":
                sceneParentExamine.DisactiveScene();
                sceneParentEndingNeutral.ActiveScene();
                break;
            case "Discussion":
                sceneParentDiscussion.DisactiveScene();
                sceneParentEndingNeutral.ActiveScene();
                break;
        }
    }

    public void DiscussionToChangeDay()
    {
        sceneChangementDay.ActiveScene();
        sceneParentDiscussion.DisactiveScene();
        _openScene = "ChangeDay";
    }
    
    public void ChangeDayToDiscussion()
    {
        sceneParentDiscussion.ActiveScene();
        sceneChangementDay.DisactiveScene();
        _openScene = "Discussion";
    }
}
