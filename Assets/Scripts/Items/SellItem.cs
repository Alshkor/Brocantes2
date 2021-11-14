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
        string itemSelect = IsItemSelect.GetNameItemSelect();
        if (priceItem.Equals(-1))
        {
            return;
        }

        if (priceItem > IsItemSelect.GetRecommandedPriceItemSelected() + 20 && NumberDay.GetDay() > 1)
        {
            CreateDialogues.sentenceAlreadySaid.Add(1000); //On ajoute l'id correspondant à "c est trop cher"
            SceneManagement.Instance.InventoryToDiscussion();
            return;
        }
        
        if (priceItem > IsItemSelect.GetRecommandedPriceItemSelected() - 20 && NumberDay.GetDay() > 1)
        {
            CreateDialogues.sentenceAlreadySaid.Add(1001); //On ajoute l'id correspondant à "c est pas assez cher"
            SceneManagement.Instance.InventoryToDiscussion();
            return;
        }

        int idItem = -1;
        if (NumberDay.GetDay() == 1)
        {
            switch (itemSelect)
            {
                case "Vase ancien":
                    CreateDialogues.AddIdSentenceSaid(100);
                    idItem = 100;
                    break;
                case "Vase moderne":
                    CreateDialogues.AddIdSentenceSaid(101);
                    idItem = 101;
                    break;
                case "Livre - Le Noël de Moustache":
                    CreateDialogues.AddIdSentenceSaid(102);
                    idItem = 102;
                    break;
                default:
                    idItem = -1;
                    break;
            }
        }

        if (PNJManagement.Instance.CurrentAccept(idItem))
        {
            StockingRessources.UpdateGold(priceItem);
            StockingRessources.UpdateReputation(priceItem);
        }
        
        PNJManagement.Instance.ChangeSentenceCurrent();
        SceneManagement.Instance.InventoryToDiscussion();
    }
    
}
