using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public SceneTransition sceneTransition;

    public string menuName = "MainMenu";
    public string levelName = "Level 2";
    public int levelToUnlock = 2;

    public void Cantinue()
    {
        PlayerPrefs.SetInt("levelTaked", levelToUnlock);
        sceneTransition.FadeTo(levelName);
    }

    public void Menu()
    {
        sceneTransition.FadeTo(menuName);
    }
}
