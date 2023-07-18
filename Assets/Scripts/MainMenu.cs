using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public SceneTransition sceneTransition;
    public void Play()
    {
        sceneTransition.FadeTo(sceneToLoad);
    }
    public void Configs()
    {
        Debug.Log("Do configs");
    }
    public void Quit()
    {
        Debug.Log("Quit App");
       // Application.Quit();
    }
}
