using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPlayer : MonoBehaviour
{
    public string answer;
    public int idAnswer;
    private PNJManagement _pnjManagement;
    // Start is called before the first frame update
    void Start()
    {
        _pnjManagement = GameObject.Find("PNJManager").GetComponent<PNJManagement>();
    }

    public void setText(string ans)
    {
        answer = ans;
        transform.GetChild(0).GetComponent<Text>().text = answer;
    }

    public void NextSentencePNJ()
    {
        transform.parent.gameObject.GetComponent<DestroyChildren>().destroy();
        transform.parent.gameObject.GetComponent<CreateDialogues>().UpdateSentenceSaid(idAnswer);
        transform.parent.gameObject.GetComponent<CreateDialogues>().UpdateSentenceUnavailable();
        _pnjManagement.ChangeSentenceCurrent();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
