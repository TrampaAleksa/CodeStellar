using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startagain : MonoBehaviour {

public void startGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void showMenu()
    {

        SceneManager.LoadScene("menu");
    }
}
