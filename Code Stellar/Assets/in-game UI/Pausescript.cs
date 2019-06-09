using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Pausescript : MonoBehaviour
{

    public GameObject PausePanel;
    public GameObject PauseButton;
    public string GameSceneName;

    public void togglePause()
    {
  

        if (!PausePanel.activeSelf)
        {
            PauseButton.SetActive(false);
            PausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        else
        {
            PausePanel.SetActive(false);
            PauseButton.SetActive(true);
            Time.timeScale = 1.0f;
        }


    }

    public void backmenu()
    
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("menu");
     
    }
   

    public void reloadScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(GameSceneName);
    }


}
