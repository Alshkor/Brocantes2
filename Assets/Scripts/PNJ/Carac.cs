using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Carac : MonoBehaviour
{
    //On y stock tous les ID des phrases dites par le PNJ actuel
    public List<int> _sentenceSaid;
    
    //Nom de la personne qui parle (tous les fichiers lui étant attribué doivent être à ce nom)
    [SerializeField] private string _name;

    [SerializeField] private CreateDialogues _playerDialogues;

    //Liste des dialogues du personnage le jour qui va bien
    private ListDialogues _listeDialogues;

    public List<int> listObjectAccepted;

    private bool update = false;
    // Start is called before the first frame update
    void Start()
    {
        _sentenceSaid = new List<int>();
        
        _listeDialogues = new ListDialogues();
    }

    void Update()
    {
        if (!update)
        {
            UpdateSentence();
            update = true;

        }
    }

    void UpdateSentence()
    {
        _sentenceSaid = new List<int>();
        
        _listeDialogues = new ListDialogues();

        var jsonFiles = Resources.Load<TextAsset>("Discussions/Jour" + NumberDay.GetDay() + "/PNJ/"+ _name );
        
        _listeDialogues = JsonUtility.FromJson<ListDialogues>(jsonFiles.ToString());
    }
    
    
    private string Speak()
    {
        if (_sentenceSaid == null)
        {
            UpdateSentence();
        }
        
        string sentence = "";
        int idNextSentence;

        try
        {
            idNextSentence = _listeDialogues.NextSentenceID(CreateDialogues.sentenceAlreadySaid, _sentenceSaid);
            sentence = _listeDialogues.NextSentence(CreateDialogues.sentenceAlreadySaid, _sentenceSaid);
            _sentenceSaid.Add(idNextSentence);
            _playerDialogues.UpdateNumberAnswer(_listeDialogues.GetBlockPlayer(idNextSentence));
        }
        catch (Exception e)
        {
            //Debug.Log("Esxception : " + e.ToString());
            NumberDay.Instance.PassDay();
            Debug.Log("Currnet personnage : " + PNJManagement.GetCurrentPNJ());
            _sentenceSaid = null;
            
            _playerDialogues.UpdateSentences();
        }


        return sentence;
    }


    public void changeText()
    {

        TextPersonnage.UpdateSentence(Speak());

    }

    private void changeTextForce(int id)
    {
        TextPersonnage.UpdateSentence(_listeDialogues.GetSentenceByID(id));
        _sentenceSaid.Add(id);
        _playerDialogues.UpdateNumberAnswer(_listeDialogues.GetBlockPlayer(id));
    }
    
    
}


//Class qui contient les propriétés du PNJ qui fait face au joueur. Doit notamment contenir les paramètres contenus dans le JSon qui décrits les personnage.

public class PNJ
{
    //Nom du personnage
    private string name;
    
    //Son niveau de richesse
    private float richness;

}

//class qui répértorie les phrases qui se déclenchent aprés une action spéciale
public class EventSentence
{
    //Déclenche la phrase lorsque l'on effectue une action sur l'objet représenté par idObject.
    private int idObject;
    
    //La phrase que doit dire le personnage.
    private string sentence;
}