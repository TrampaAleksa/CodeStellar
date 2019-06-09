using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float spawnSpeed;
    private float timeLeft;
    public GameObject token;
    private float xCenter;
    private float width;
    public float distancaZaSpawn;
    // Use this for initialization
    void Start()
    {
        xCenter = GetComponent<BackgroundController>().xCenter;
        width = GetComponent<BackgroundController>().backgroundWidth;
        timeLeft = Random.Range(15, 40);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timeLeft - spawnSpeed * Time.deltaTime;
        if (timeLeft < 0)
        {
            //daje vectoru random lokaciju koja se menja po sirini pozadine
            float randomRange = Random.Range(xCenter + distancaZaSpawn, xCenter - distancaZaSpawn);
            Vector3 rand = new Vector3(randomRange, transform.position.y, transform.position.z);
            Instantiate(token, rand, Quaternion.identity);
            timeLeft = Random.Range(15, 40);
        }

    }
}

