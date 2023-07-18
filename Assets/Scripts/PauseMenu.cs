using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUi;
    public SceneTransition sceneTransition;
    public string menuName;
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
        sceneTransition.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        PauseToggle();
        sceneTransition.FadeTo(menuName);
    }

}
