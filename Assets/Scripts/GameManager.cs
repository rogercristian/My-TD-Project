using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   public static bool GameEnded;
   public GameObject gameoverUi;
  
    private void Awake()
    {
        if (Instance == null)
        {
            Debug.LogError("Mais de um Game Manager");
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        GameEnded = false;
        gameoverUi.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       if (GameEnded) return;       

       if(PlayerStats.Lives <= 0)
        {
            EndGame();
        } 
    }

    void EndGame()
    {
        GameEnded = true;
        gameoverUi.SetActive(true);
        Debug.Log("Game over");
    }
}
