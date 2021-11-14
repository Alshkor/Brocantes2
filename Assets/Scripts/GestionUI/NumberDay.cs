using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDay : MonoBehaviour
{

    private static int _day;
    public static int _gainsDay;
    
    // Start is called before the first frame update
    void Awake()
    {
        _day = 1;
    }

    public static int GetDay()
    {
        return _day;
    }

    public static void PassDay()
    {
        
        /*Dernier Jour*/
        if (GetDay() == 5) {
            /*On lance l'écran de fin*/
            StockingRessources.Ending();
            

        /*Autres Jours*/
        } else {
            /*Update items dispo*/


            /*Update perso*/
            PNJManagement.ChangePNJ("vieux");

            /*On lance l'écran de changement de jour*/

            _day++;
        }

        
    }
    
}
