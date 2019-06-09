using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometeRotate : MonoBehaviour {
    public float speedMin;
    public float speedMax;
    float randomSpeedX, randomSpeedZ;
	// Use this for initialization
	void Start () {
        randomSpeedX = Random.Range(speedMin,speedMax);
        randomSpeedZ = Random.Range(speedMin, speedMax);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(randomSpeedX, 0, randomSpeedZ)*Time.deltaTime*randomSpeedX);
    }
}
