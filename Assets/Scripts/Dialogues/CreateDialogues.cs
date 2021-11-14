using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateDialogues : MonoBehaviour
{
    //Nombres de boite de dialogue sélectionnable
    [SerializeField]private  int numberDialogue = 3;

    [SerializeField] private GameObject _button;

    public static List<int> sentenceAlreadySaid;
    public static List<int> sentenceUnavailable;
    private ListDialogues _listDialogues;

    [SerializeField] private PNJManagement _pnjManagement;

    private bool update = false;

    // Start is called before the first frame update
    void Start()
    {
        _listDialogues = new ListDialogues();

        sentenceAlreadySaid = new List<int>();
        sentenceUnavailable = new List<int>();
    }

    void Update()
    {
        if (!update)
        {
            UpdateSentences();
            update = true;
        }
    }

    public void UpdateSentences()
    {
        //Liste des dialogues qui convient à la personne devant nous. Doit être update quand l'on passe à une autre personne ou que
        //l'on fait des actions sur les objets
        _listDialogues = new ListDialogues();

        sentenceAlreadySaid = new List<int>();
        sentenceUnavailable = new List<int>();

        var jsonFiles = Resources.Load<TextAsset>("Discussions/Jour" + NumberDay.GetDay() + "/Player/"+ PNJManagement.GetCurrentPNJ());
        
        
        _listDialogues = JsonUtility.FromJson<ListDialogues>(jsonFiles.ToString());
    }
    

    public void UpdateSentenceUnavailable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            sentenceUnavailable.Add(transform.GetChild(i).GetComponent<AnswerPlayer>().idAnswer);
        }
    }

    public void UpdateSentenceSaid(int id)
    {
        sentenceAlreadySaid.Add(id);
    }


    public void UpdateNumberAnswer(bool blockPlayer)
    {
        //A changer avec une fonction pour calculer le nombre de boite de dialogue disponible
        //numberDialogue = 3;
        GameObject dialogue;
        RectTransform trans;

        List<string> answer;
        List<int> answerId;
        int numberDialog = 0;

        try
        {
            numberDialog = _listDialogues.NumberAnswerAvailable(_pnjManagement.GetListSaidPNJ(), sentenceUnavailable);
        }
        catch (Exception e)
        {
        }
        
        try
        {
            answer = new List<string>();
            answerId = new List<int>();
            answer = _listDialogues.GetAnswer(_pnjManagement.GetListSaidPNJ(), sentenceUnavailable);
            
            answerId = _listDialogues.GetIdAnswer(_pnjManagement.GetListSaidPNJ(), sentenceUnavailable);
        }
        catch (Exception e)
        {
            answerId = new List<int>();
            answer = new List<string>();
        }

        numberDialog = Mathf.Clamp(numberDialog, 0, 3);
        
        //Organise les buttons de sélections des dialogues pour que ce soit plus jolie dependant du nombre de dialogues que l'on veut
        switch(numberDialog)
        {
            case 2:
                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[0]);
                dialogue.GetComponent<AnswerPlayer>().idAnswer = answerId[0];
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,75);
                trans.localScale = new Vector3(1, 1, 1);

                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[1]);
                dialogue.GetComponent<AnswerPlayer>().idAnswer = answerId[1];
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0, -75);
                trans.localScale = new Vector3(1, 1, 1);
                break;
            case 1:
                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[0]);
                dialogue.GetComponent<AnswerPlayer>().idAnswer = answerId[0];
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,0);
                trans.localScale = new Vector3(1, 1, 1);
                break;
            case 0:
                dialogue = (Instantiate(_button));
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,0);
                trans.localScale = new Vector3(1, 1, 1);
                break;
            default:
                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[0]);
                dialogue.GetComponent<AnswerPlayer>().idAnswer = answerId[0];
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,75);
                trans.localScale = new Vector3(1, 1, 1);

                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[1]);
                dialogue.GetComponent<AnswerPlayer>().idAnswer = answerId[1];
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,0);
                trans.localScale = new Vector3(1, 1, 1);
                
                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[2]);
                dialogue.GetComponent<AnswerPlayer>().idAnswer = answerId[2];
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0, -75);
                trans.localScale = new Vector3(1, 1, 1);
                break;
        }

        if (blockPlayer)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
    }

    public static void AddIdSentenceSaid(int id)
    {
        sentenceAlreadySaid.Add(id);
    }

    public void DeblockAnswerPlayer()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }
    

}

public class ListDialogues
{
    public List<DialoguesPNJ> listDialogues;

    public string NextSentence(List<int> sentenceSaidByPlayer, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {

            if (dial.canSay(sentenceSaidByPlayer) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {
                answerAvailable.Add(dial.idSentence);
            }
        }
        if (answerAvailable.Count == 0)
        {
            throw new Exception("Pas d'élément");
        }
        

        return GetSentenceByID(answerAvailable[0]);
    }
    
    public int NextSentenceID(List<int> sentenceSaidByPlayer, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {
            if (dial.canSay(sentenceSaidByPlayer) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {
                answerAvailable.Add(dial.idSentence);
            }
        }

        if (answerAvailable.Count == 0)
        {
            throw new Exception("Pas d'élément");
        }
        return answerAvailable[0];
    }

    public int NumberAnswerAvailable(List<int> sentenceSaidByPNJ, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {
            if (dial.canSay(sentenceSaidByPNJ) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {
                answerAvailable.Add(dial.idSentence);
            }
        }
        return answerAvailable.Count;
    }

    public string GetSentenceByID(int id)
    {
        foreach (var dial in listDialogues)
        {
            if (dial.idSentence == id)
            {
                return dial.sentence;
            }
        }

        throw new Exception("Pas d'id correspondant");
    }
    
    public bool GetBlockPlayer(int id)
    {
        foreach (var dial in listDialogues)
        {
            if (dial.idSentence == id)
            {
                return dial.blockPlayer;
            }
        }

        return false;
    }

    public List<String> GetAnswer(List<int> sentenceSaidByPNJ, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {
            
            if (dial.canSay(sentenceSaidByPNJ) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {

                
                answerAvailable.Add(dial.idSentence);
            }
        }

        if (answerAvailable.Count == 0)
        {
            throw new Exception("Pas d'élément");
        }

        int nbrAnswer = Mathf.Clamp(answerAvailable.Count,1,3);
        
        List<string> returnAnswer = new List<string>();
        
        for(int i = 0; i < nbrAnswer ;i ++)
        {
            returnAnswer.Add(GetSentenceByID(answerAvailable[i]));
        }
        return returnAnswer;
    }

    public List<int> GetIdAnswer(List<int> sentenceSaidByPNJ, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {
            
            if (dial.canSay(sentenceSaidByPNJ) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {
                answerAvailable.Add(dial.idSentence);
            }
        }

        if (answerAvailable.Count == 0)
        {
            throw new Exception("Pas d'élément");
        }

        int nbrAnswer = Mathf.Clamp(answerAvailable.Count,1,3);
        
        List<int> returnAnswer = new List<int>();
        
        for(int i = 0; i < nbrAnswer ;i ++)
        {
            returnAnswer.Add(answerAvailable[i]);
        }
        return returnAnswer;
    }
    
}

[Serializable]
public class DialoguesPNJ
{
    //Phrase du dialogue
    public string sentence;
    
    //Int représentant ce que va répondre le PNJ (pour pouvoir "retrouver" ce qu'a dit le joueur et adapter la réponse du pnj)
    public int idSentence;
    
    //List d'int si le joueur a dit ou fait un des int present (qui représente une phrase ou une action)
    //Alors le dialogue peut avoir lieu
    public List<int> canSayIf;
    
    //Bool, si true alors quand le pnj dit la phrase ca bloque les réponses du joueur en attente de vente
    public bool blockPlayer;

    public bool canSay(List<int> sentenceByPlayer)
    {
        if (canSayIf.Count == 0)
        {
            return true;
        }
        foreach (int sent in sentenceByPlayer)
        {
            if (canSayIf.Contains(sent))
            {
                return true;
            }
        }

        return false;
    }

}
