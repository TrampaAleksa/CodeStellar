using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public Image progressBar;
    float station;
    float destination = 5;
	void Start () {
        station = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DrawProgressBar();
    }
    void OnTriggerEnter(Collider unit)
    {
        if(unit.tag=="CheckPoint")
        {
            station++;
        }
    }
    void DrawProgressBar()
    {
        progressBar.fillAmount = station / destination;
    }
}
