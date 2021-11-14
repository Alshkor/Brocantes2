using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchQuit : MonoBehaviour
{
    /*Simples fonctions pour permettre de quitter ou lancer le jeu*/
    public void QuitGame() {
        Application.Quit();
    }

    public void LaunchGame() {
        SceneManager.LoadScene("FinalScene");
    }
}
