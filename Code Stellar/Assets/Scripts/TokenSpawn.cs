using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawn : MonoBehaviour
{
    public float spawnSpeed;
    private float timeLeft;
    public GameObject token;
    private float xCenter;
    private float width;
    public float distancaZaSpawn;
    public GameObject rocket;
    public GameObject backgroundFrame;
    private int quanititySpawned;
    // Use this for initialization
    void Start()
    {
        xCenter = backgroundFrame.GetComponent<BackgroundController>().xCenter;
        width = backgroundFrame.GetComponent<BackgroundController>().backgroundWidth;
        timeLeft = Random.Range(15, 40);
        quanititySpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timeLeft - spawnSpeed * Time.deltaTime;
        if (timeLeft < 0)
        {
            //daje vectoru random lokaciju koja se menja po sirini pozadine
            float randomRange = Random.Range(xCenter + distancaZaSpawn, xCenter - distancaZaSpawn);
            Vector3 rand = new Vector3(randomRange, transform.position.y,rocket.transform.position.z);
            if (quanititySpawned < 25)
            {
                Instantiate(token, rand, Quaternion.identity);
                quanititySpawned++;
            }
            timeLeft = Random.Range(15, 40);
        }

    }
}

