using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Cash;
    public int initialCash = 500;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

   
    private void Start()
    {
        Cash = initialCash;
        Lives = startLives;

        Rounds = 0;
    }
   
}
