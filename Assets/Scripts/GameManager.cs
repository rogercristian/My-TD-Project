using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   private bool gameEnded = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.LogError("Mais de um Game Manager");
            return;
        }
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
       if (gameEnded) return;

       if(PlayerStats.Lives <= 0)
        {
            EndGame();
        } 
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game over");
    }
}
