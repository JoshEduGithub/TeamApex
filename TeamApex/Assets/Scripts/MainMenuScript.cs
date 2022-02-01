using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    // coded by joshua
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public void play()
    {
        SceneManager.LoadScene("Level1");

    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);

    }

    public void MenuBtn()
    {
        if (optionsPanel == true)
        {
            mainMenuPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
    }
}
