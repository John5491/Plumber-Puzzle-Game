using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvlselect : MonoBehaviour
{
    public Button[] lvlButtons;

    void Start()
    {
        int progress = PlayerPrefs.GetInt("progress", 1);
        for(int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > progress)
                lvlButtons[i].interactable = false;
        }
    }

    public void loadscene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void uiResetLevelSelection()
    {
        PlayerPrefs.DeleteKey("progress");
        lvlButtons[1].interactable = false;
        lvlButtons[2].interactable = false;
    }
}
