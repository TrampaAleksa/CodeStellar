using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorRange : MonoBehaviour {
    Color myColor = new Color();
    private int range;
    // Use this for initialization
    void Start () {
        range = Random.Range(1, 254);
       GetComponent<Renderer>().material.color =new Color32((byte)range, (byte)range, (byte)range, (byte)range);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
