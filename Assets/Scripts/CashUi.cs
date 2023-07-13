using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashUi : MonoBehaviour
{
    [SerializeField] TMP_Text cashText;
    // Update is called once per frame
    void Update()
    {
        cashText.text = "R$ " + PlayerStats.Cash.ToString();
    }
}
