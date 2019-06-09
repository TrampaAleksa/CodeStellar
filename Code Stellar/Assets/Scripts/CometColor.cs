using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometColor : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.black);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
