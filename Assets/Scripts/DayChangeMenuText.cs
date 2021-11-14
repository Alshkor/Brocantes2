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

    public void changeScreen()
    {
        switch (NumberDay.GetDay())
        {
            case 2:
                _descriptionDayObject.GetComponent<UnityEngine.UI.Text>().text = "~ Fin du jour " + NumberDay.GetDay() + " ~";
                _gainDayObject.GetComponent<UnityEngine.UI.Text>().text = NumberDay._gainsDay.ToString();
                _commentaireDayObject.GetComponent<UnityEngine.UI.Text>().text =
                    "La journée est finie, mais vous devez payer les frais de stands pour la semaine.\n Vous perdez 10 €";
                _perteDayObject.GetComponent<UnityEngine.UI.Text>().text = "-10€";
                break;
            
            case 3:
                _descriptionDayObject.GetComponent<UnityEngine.UI.Text>().text = "~ Fin du jour " + NumberDay.GetDay() + " ~";
                _gainDayObject.GetComponent<UnityEngine.UI.Text>().text = NumberDay._gainsDay.ToString();
                _commentaireDayObject.GetComponent<UnityEngine.UI.Text>().text =
                    "La journée est finie, mais un mioche du coin a cassé votre vitre. Vous estimez la réparation.\nVous perdez 30 €";
                _perteDayObject.GetComponent<UnityEngine.UI.Text>().text = "-30€";
                break; 
            case 4:
                    _descriptionDayObject.GetComponent<UnityEngine.UI.Text>().text = "~ Fin du jour " + NumberDay.GetDay() + " ~";
                    _gainDayObject.GetComponent<UnityEngine.UI.Text>().text = NumberDay._gainsDay.ToString();
                    _commentaireDayObject.GetComponent<UnityEngine.UI.Text>().text =
                        "La journée est finie, mais vous êtes invité à dîner par vos anciens collègues, que vous ne pouvez pas refuser. Heureusement, vous n’achetez qu’un morceau de pain rassi.\nVous perdez 30 €";
                    _perteDayObject.GetComponent<UnityEngine.UI.Text>().text = "-5€";
                    break;
            case 5:
                _descriptionDayObject.GetComponent<UnityEngine.UI.Text>().text = "~ Fin du jour " + NumberDay.GetDay() + " ~";
                _gainDayObject.GetComponent<UnityEngine.UI.Text>().text = NumberDay._gainsDay.ToString();
                _commentaireDayObject.GetComponent<UnityEngine.UI.Text>().text = "La journée est finie, mais vous devez payer votre loyer du mois pour votre redoutable 2 pièce à 50 km.\nVous perdez 30 €";
                _perteDayObject.GetComponent<UnityEngine.UI.Text>().text = "-30€";
                break;
        }
    } 
    
    
    
}
