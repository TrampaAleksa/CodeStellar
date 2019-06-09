using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanets : MonoBehaviour {
    public GameObject planet1, planet2, planet3, planet4, planet5;
    bool planet1_spawned, planet2_spawned, planet3_spawned, planet4_spawned, planet5_spawned;
    private int numofRecycles;

    public float planetSpawnOffset;

    public GameObject rocket;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        landingRocket();
    }
    void landingRocket()
    {
        numofRecycles = BackgroundController.recycleCounter;
        if (numofRecycles == 1 && !planet1_spawned)
        {
            Instantiate(planet1, new Vector3(0, +50, rocket.transform.position.z + planetSpawnOffset), Quaternion.identity);
            planet1_spawned = true;
        }
        if (numofRecycles == 3 && !planet2_spawned)
        {
            Instantiate(planet2, new Vector3(0, +50, rocket.transform.position.z + planetSpawnOffset), Quaternion.identity);
            planet2_spawned = true;
        }
        if (numofRecycles == 5 && !planet3_spawned)
        {
            Instantiate(planet3, new Vector3(0, +50, rocket.transform.position.z + planetSpawnOffset), Quaternion.identity);
            planet3_spawned = true;
        }
        if (numofRecycles == 7 && !planet4_spawned)
        {
            Instantiate(planet4, new Vector3(0, +50, rocket.transform.position.z + planetSpawnOffset), Quaternion.identity);
            planet4_spawned = true;
        }
        if (numofRecycles ==9 && !planet5_spawned)
        {
            Instantiate(planet5, new Vector3(0, +50, rocket.transform.position.z + planetSpawnOffset), Quaternion.identity);
            planet5_spawned = true;
        }
    }
}
