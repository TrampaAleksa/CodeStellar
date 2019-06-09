using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComet : MonoBehaviour {
    public float SpawnSpeed;
    private float timeLeft;
    public GameObject comet;

    public float cometSpawnIncreaseModifier;

    public GameObject rocket;
    private float rocketZCoordinate;
	// Use this for initialization
	void Start () {
        rocketZCoordinate = rocket.transform.position.z;
        timeLeft = Random.Range(SpawnSpeed/2,SpawnSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            Instantiate(comet, new Vector3(0, 50, rocketZCoordinate), Quaternion.identity);
            timeLeft = SpawnSpeed;
        }
    }
}
