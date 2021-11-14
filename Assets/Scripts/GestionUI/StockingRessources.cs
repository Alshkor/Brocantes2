using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingRessources : MonoBehaviour
{
    //Quantité d'argent que posséde le joueur
    private static float _gold;
    
    
    //Quantité de réputation que posséde le joueur
    private static float _reputation;

    private static float _minGold;

    private static float _maxGold;
    
    private static float _minRep;

    private static float _maxRep;
    

    // Start is called before the first frame update
    void Awake()
    {
        //Pour l'instant, on fix comme ca les valeurs
        InitializeRessources(0,500, 0, 100,20, 50);
        

    }

    public static void InitializeRessources(float minGold, float maxGold, float minRep, float maxRep, float startingValueGold, float startingValueRep)
    {
        //Valeur maximale et minimale de gold et reputation
        _minGold = minGold;
        _maxGold = maxGold;
        _minRep = minRep;
        _maxRep = maxRep;
        
        //On fix les valeurs de base
        _gold = startingValueGold;
        _reputation = startingValueRep;
    }
    
    //Retourne la valeur minimum de gold et reputation
    public static float GetMinRep()
    {
        return _minRep;
    }

    //Retourne la valeur maximum de gold et reputation
    public static float GetMaxRep()
    {
        return _maxRep;
    }
    

    //Ajoute ou retire amount au nombre de gold que posséde le joueur
    public static void UpdateGold(float amount)
    {
        _gold += amount;
        
        //On fix le nombre de gold max a 100 et min a 0
        Mathf.Clamp(_gold, _minGold, _maxGold);
        if (_gold <= _minGold)
        {
            SceneManagement.Instance.SceneToLooseGold();
        } 

    }
    
    
    //Ajoute ou retire amount au nombre de reputation que posséde le joueur
    public static void UpdateReputation(float amount)
    {
        _reputation += amount;
        
        //On fix le nombre de gold max a 100 et min a 0
        Mathf.Clamp(_reputation, _minRep, _maxRep);

        //Debug.Log("Notre réputation : " + _reputation + ". On meurt si on atteinds : " + _minRep);
        //Debug.Log(_reputation.Equals(_minRep));
        if (_reputation <= _minRep)
        {
            SceneManagement.Instance.SceneToLooseRep();
        } 
    }

    //Retourne le nombre de gold du joueur
    public static float GetGold()
    {
        return _gold;
    }
    
    //Retourne le nombre de reputation du joueur    
    public static float GetReputation()
    {
        return _reputation;
    }

    public static void Ending()
    {
        if (_reputation > 90 && _gold > 120)
        {
            SceneManagement.Instance.SceneToGoodEnding();
        }
        else if (_reputation > 90 && _gold < 120)
        {
            SceneManagement.Instance.SceneToBonteEnding();
        }
        else if (_reputation < 30 && _gold > 200)
        {
            SceneManagement.Instance.SceneToMoulagaEnding();
        }
        else if(_reputation < 30 && _gold < 50) 
        {
            SceneManagement.Instance.SceneToBadEnding();
        }
        else
        {
            SceneManagement.Instance.SceneToNeutralEnding();
        }
    }
    
}
