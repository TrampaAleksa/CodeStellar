using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour {
    private float planetAxis_Y;

    public bool shouldMovePlanet;

    public float palnetMovementSpeed;
    // Use this for initialization
    void Start () {
        planetAxis_Y = gameObject.transform.position.y;
        shouldMovePlanet = true;
    }
	
	// Update is called once per frame
	void Update () {
        float screenSize = BackgroundController.GetDimensionInPX(GameObject.Find("Space Background 1")).y;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, planetAxis_Y, gameObject.transform.position.z);

        if (shouldMovePlanet)
        {
            planetAxis_Y -= palnetMovementSpeed * Time.deltaTime;
        }

        if (planetAxis_Y < -screenSize) Destroy(gameObject);
    }



}
