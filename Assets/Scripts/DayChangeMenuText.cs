using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayChangeMenuText : MonoBehaviour
{

    [SerializeField] private GameObject _descriptionDayObject;
    [SerializeField] private GameObject _gainDayObject;
    [SerializeField] private GameObject _commentaireDayObject;
    [SerializeField] private GameObject _perteDayObject;

    // Start is called before the first frame update
    void Start()
    {
        
        _descriptionDayObject.GetComponent<UnityEngine.UI.Text>().text = "~ Fin du jour" + NumberDay.GetDay() + " ~";
        _gainDayObject.GetComponent<UnityEngine.UI.Text>().text = NumberDay._gainsDay.ToString();
        _commentaireDayObject.GetComponent<UnityEngine.UI.Text>().text = "Le gérant vous fait payer des frais de stand de 10€.";
        _perteDayObject.GetComponent<UnityEngine.UI.Text>().text = "-10€";
        
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            /*On lance le jour suivant*/
        }
    }
}
