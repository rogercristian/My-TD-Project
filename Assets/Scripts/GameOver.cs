using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOver : MonoBehaviour
{
    [SerializeField] TMP_Text roundText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
       
    }
    public void Menu()
    {

    }
}
