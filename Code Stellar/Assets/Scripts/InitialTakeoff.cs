using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTakeoff : MonoBehaviour {


    public GameObject startingPlanet;
    public GameObject backgroundFrame;
    public GameObject spawner;
    public GameObject rocket;
    public GameObject thrusters;

	// Use this for initialization
	void Start () {
        Invoke("InitiateTakeoff", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void InitiateTakeoff()
    {
        backgroundFrame.GetComponent<BackgroundController>().enabled = true;
        spawner.SetActive(true);
        startingPlanet.GetComponent<PlanetMovement>().enabled = true;
        rocket.GetComponent<RaketaMovement>().enabled = true;
        thrusters.SetActive(true);
    }
}
