using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Cash;
    public int initialCash = 500;

    public static int Lives;
    public int startLives = 20;
    private void Start()
    {
        Cash = initialCash;
        Lives = startLives;
    }
}
