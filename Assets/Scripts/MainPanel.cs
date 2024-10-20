using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenPanel( GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);
    }
}
