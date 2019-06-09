using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatePoints : MonoBehaviour {
    int i = 0;
    TextMeshProUGUI txtPoints;
	// Use this for initialization
	void Start () {
        txtPoints = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        txtPoints.text = RocketCollisionManager.scoreP.ToString();
	}
}
