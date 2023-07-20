using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowLives : MonoBehaviour
{
    public Image healthBar;
    void Update()
    {
        healthBar.GetComponent<Image>().fillAmount = PlayerStats.Lives/100f;
    }
}
