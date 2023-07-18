using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    [SerializeField] TMP_Text roundText;

    public SceneTransition sceneTransition;

    public string menuName = "MainMenu";   
    private void OnEnable()
    {
        roundText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        sceneTransition.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneTransition.FadeTo(menuName);
    }
}
