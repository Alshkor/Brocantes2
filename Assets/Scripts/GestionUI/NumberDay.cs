using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NumberDay : MonoBehaviour
{

    private static int _day;
    private static int iteration;
    public static int _gainsDay;
    public static NumberDay Instance;

    void Awake()
    {
        Instance = this;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        _day = 1;
        iteration = 0;
        PassDay();
    }

    public static int GetDay()
    {
        return _day;
    }

    public void PassDay()
    {
        
        /*Dernier Jour*/
        if (_day + 1 == 5) {
            /*On lance l'écran de fin*/
            StockingRessources.Ending();
            

        /*Autres Jours*/
        } else {
            iteration++;
            
            /*On lance l'écran de changement de jour*/
            changePersonnage();

            Debug.Log("jour = " + _day + " et iteration = " + iteration);
            if (iteration < 5)
            {
                _day = 1;
            }
            else
            {
                _day = iteration - 3;
            }
        }
    }
    
    public void changePersonnage()
    {
        //IsItemSelect.GetItemSelect().SetActive(false);
        switch (iteration)
        {
            case 1:
                PNJManagement.ChangePNJ("aristo");
                break;
            case 2:
                PNJManagement.ChangePNJ("vieux");
                break;
            case 3:
                PNJManagement.ChangePNJ("primrose");
                break;
            case 4:
                PNJManagement.ChangePNJ("luke");
                break;
            case 5:
                //change item
                
                PNJManagement.ChangePNJ("primrose");
                break;
            case 6:
                PNJManagement.ChangePNJ("vieux");
                break;
            case 7:
                PNJManagement.ChangePNJ("aristo");
                break;
            case 8:
                PNJManagement.ChangePNJ("luke");
                break;
        }

        //IsItemSelect.GetItemSelect().SetActive(true);
        
        StartCoroutine("PrintFirstSentence");
    }

    IEnumerator PrintFirstSentence()
    {
        yield return new WaitForSeconds(0.1f);
        PNJManagement.Instance.ChangeSentenceCurrent();
        Debug.Break();
    }
    
}
