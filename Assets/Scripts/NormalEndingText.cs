using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalEndingText : MonoBehaviour
{
    [SerializeField] private GameObject _reputObject;
    [SerializeField] private GameObject _moneyObject;

    // Start is called before the first frame update
    void Start()
    {
        
        _reputObject.GetComponent<UnityEngine.UI.Text>().text = StockingRessources.GetReputation().ToString();
        _moneyObject.GetComponent<UnityEngine.UI.Text>().text = StockingRessources.GetGold().ToString();

   
    }
}
