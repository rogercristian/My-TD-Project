using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUi;
  
    void Update()
    {
        bool startButton = InputManager.GetInstance().GetStartPressed();

        if (startButton)
        {
            PauseToggle();
        }
    }
   public void PauseToggle()
    {
        pauseUi.SetActive(!pauseUi.activeSelf);

        if (pauseUi.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

    }

    public void RetryLevel()
    {
        PauseToggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Debug.Log("fazer main menu");
    }

    public void QuitOption()
    {
        Debug.Log("Fazer quit options");
    }
}
