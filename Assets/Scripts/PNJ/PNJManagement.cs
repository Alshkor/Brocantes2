using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class PNJManagement : MonoBehaviour
{
    private static string _currentPNJ;

    [SerializeField] private GameObject Vieux;
    [SerializeField] private GameObject Aristo;
    [SerializeField] private GameObject Primrose;
    [SerializeField] private GameObject Luke;

    public static PNJManagement Instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject getPnjByName(string name)
    {
        switch (name)
        {
            case "vieux":
                return Vieux;
            case "aristo":
                return Aristo;
            case "primrose":
                return Primrose;
            case "luke":
                return Luke;
        }

        throw new Exception("PNJ not found");
    }

    public static void ChangePNJ(string name)
    {
        _currentPNJ = name;
    }

    /*
    public GameObject GetRandomPNJ()
    {
        List<string> PNJAvailable = new List<string>();
        PNJAvailable.Add("vieux");
        PNJAvailable.Add("aristo");
        PNJAvailable.Add("primrose");
        PNJAvailable.Add("luke");

        foreach (var pnj in _pngAlreadyPass)
        {
            if (PNJAvailable.Contains(pnj))
            {
                PNJAvailable.Remove(pnj);
            }
        }

        int numberAvailable = _pngAlreadyPass.Count;

        int indexRandom = Random.Range(0, numberAvailable);

        string randomPNJ = PNJAvailable[indexRandom];

        try
        {
            return getPnjByName(PNJAvailable[indexRandom]);
        }
        catch (Exception e)
        {
            Debug.Log("PNJ not found");
            return null;
        }
    }*/

    public void ChangeSentenceCurrent()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Carac pnj = getPnjByName(_currentPNJ).GetComponent<Carac>();
        
        pnj.changeText();
    }

    public static string GetCurrentPNJ()
    {
        return _currentPNJ;
    }

    public List<int> GetListSaidPNJ()
    {
        return getPnjByName(GetCurrentPNJ()).GetComponent<Carac>()._sentenceSaid;
    }

    public bool CurrentAccept(int idItem)
    {
        //Renvoie TRUE si le pnj accepte la transaction (possiblement rajouter le syst??me de prix, si il est trop cher)
        return getPnjByName(GetCurrentPNJ()).GetComponent<Carac>().listObjectAccepted.Contains(idItem);
    }
    
}
