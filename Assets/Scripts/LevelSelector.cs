using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneTransition sceneTransition;

    public Button[] selectLevel;

    private void Start()
    {
        int levelTaked = PlayerPrefs.GetInt("levelTaked", 1);

        for (int i = 0; i < selectLevel.Length; i++)
        {
            if(i + 1 > levelTaked) selectLevel[i].interactable = false;

        }
    }
    public void SelectLevel(string levelName)
    {
        sceneTransition.FadeTo(levelName);
    }
}
