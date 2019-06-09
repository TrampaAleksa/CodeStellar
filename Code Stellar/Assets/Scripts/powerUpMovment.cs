using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpMovment : MonoBehaviour
{
    public float tokenSpeed;
    public float tokenRotationSpeed, tokenSize;
    float screenSize;
    // Use this for initialization
    void Start()
    {
        screenSize = BackgroundController.GetDimensionInPX(GameObject.Find("Space Background 1")).y;
        transform.localScale = new Vector3(tokenSize, tokenSize, tokenSize * 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * tokenSpeed, transform.position.z);
        transform.Rotate(Vector3.up * Time.deltaTime * tokenRotationSpeed);
        if (transform.position.y < -screenSize)
            Destroy(gameObject);
    }
}

