using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsItemSelect : MonoBehaviour
{
    //TRUE = un item est selectionné, FALSE = pas d'item sélectionné
    private static bool select = false;

    private static GameObject itemSelect;

    public static bool IsItemAlreadySelect()
    {
        return select;
    }

    public static void SelectAnItem(GameObject item)
    {

        if (select)
        {
            itemSelect.GetComponent<ItemScript>().DisappearSelection();
        }

        itemSelect = item;
        itemSelect.GetComponent<ItemScript>().AppearSelection();
        select = true;
    }
    

    public void ChangePriceItemSelected(float amount)
    {
        if (select)
        {
            itemSelect.GetComponent<ItemScript>().ChangePriceSold(amount);
        }

    }

    public static float GetPriceItemSelected()
    {
        if (select)
        {
            return itemSelect.GetComponent<ItemScript>().GetPriceItemSold();
        }

        return -1;
    }
    
    public static float GetRecommandedPriceItemSelected()
    {
        if (select)
        {
            return itemSelect.GetComponent<ItemScript>().GetPriceItem();
        }

        return -1;
    }

    public static GameObject GetItemSelect()
    {
        return itemSelect;
    }

    public static string GetNameItemSelect()
    {
        return itemSelect.GetComponent<ItemScript>().GetName();
    }

    public static bool IsEventDeclenched()
    {
        return GetItemSelect().GetComponent<ItemScript>().eventDeclenched;
    }
    
    public static void DeclenchEvent()
    {
        GetItemSelect().GetComponent<ItemScript>().eventDeclenched = true;
    }

    public static void destroyItem()
    {
        select = false;
        Destroy(itemSelect);
        itemSelect = null;
    }
}
