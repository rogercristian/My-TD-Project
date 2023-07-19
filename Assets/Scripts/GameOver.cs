using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{  

    public SceneTransition sceneTransition;

    public string menuName = "MainMenu";   
   
    public void Retry()
    {
        sceneTransition.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneTransition.FadeTo(menuName);
    }
}
