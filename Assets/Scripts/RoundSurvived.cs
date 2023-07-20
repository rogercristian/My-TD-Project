using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoundSurvived : MonoBehaviour
{
    [SerializeField] TMP_Text roundText;
   
    private void OnEnable()
    {
        StartCoroutine(RoundTextAnimator()) ;
       
    }

    IEnumerator RoundTextAnimator()
    {
        roundText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundText.text = round.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }

   
}
