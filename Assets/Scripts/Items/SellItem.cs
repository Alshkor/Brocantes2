using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SellItem : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SellItemSelect()
    {
        float priceItem = IsItemSelect.GetPriceItemSelected();
        if (priceItem.Equals(-1))
        {
            return;
        }

        if (priceItem > IsItemSelect.GetRecommandedPriceItemSelected() + 20)
        {
            CreateDialogues.sentenceAlreadySaid.Add(1000); //On ajoute l'id correspondant à "c est trop cher"
            SceneManagement.Instance.InventoryToDiscussion();
            return;
        }
        
        if (priceItem > IsItemSelect.GetRecommandedPriceItemSelected() - 20)
        {
            CreateDialogues.sentenceAlreadySaid.Add(1001); //On ajoute l'id correspondant à "c est pas assez cher"
            SceneManagement.Instance.InventoryToDiscussion();
            return;
        }
        
        StockingRessources.UpdateGold(priceItem);
        StockingRessources.UpdateReputation(priceItem);
        
        SceneManagement.Instance.InventoryToDiscussion();
    }
    
}
