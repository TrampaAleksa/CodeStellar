using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometMovement : MonoBehaviour {
    public float comet_speed, comet_rotation, comet_position;
    private float cometAxis_X, cometAxis_Y;
    public float cometScaleMin, cometScaleMax;
    float screenSize;
    // Use this for initialization
    void Start () {
        cometAxis_X = Random.Range(-comet_position, +comet_position);
        cometAxis_Y = gameObject.transform.position.y;
        comet_rotation = Random.Range(-comet_rotation, comet_rotation);
        screenSize = BackgroundController.GetDimensionInPX(GameObject.Find("Space Background 1")).y;
        float cometScale = Random.Range(cometScaleMin, cometScaleMax);
        gameObject.transform.localScale += new Vector3(cometScale, cometScale, cometScale);
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(cometAxis_X, cometAxis_Y, gameObject.transform.position.z);
        cometAxis_X += comet_rotation * Time.deltaTime;
        cometAxis_Y -= comet_speed * Time.deltaTime;
        if (cometAxis_Y < -screenSize) Destroy(gameObject);
}
}
