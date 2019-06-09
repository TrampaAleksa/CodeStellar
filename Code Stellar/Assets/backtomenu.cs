using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomenu : MonoBehaviour {


    public void backmenu()
    {
        StartCoroutine(back2menu());
    }
    IEnumerator back2menu()
    {
        yield return new WaitForSeconds(.05f);
        SceneManager.LoadScene("menu");
    }
}
