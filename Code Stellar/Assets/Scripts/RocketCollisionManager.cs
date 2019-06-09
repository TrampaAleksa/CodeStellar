using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RocketCollisionManager : MonoBehaviour {

    public GameObject cometSpawner;
    public int scorept;
    public GameObject backgroundFrame;
    public GameObject thrusters;
    public GameObject codeSolvingCanvas;
    public GameObject explosionBlue, explosionRed;
    public int sizeOfExplosionRocket;

    private GameObject[] comets;
    private GameObject comet;
    private Collider currentPlanet;
    private Rigidbody rb;
    public GameObject rocket;

    private AudioSource[] audio;
    private bool shouldCollideWithComets = true;
    //true while landing / moving to the planet
    private bool isLanding;
    // true in the time where the rocket is returning to its original position
    private bool hasLanded;
    public bool isTakingOff;
    //after the rocket returns to its original location
    private bool hasTakenOff;
    public static float scoreP;
    Vector3 starting;
    private Vector2 planetXY;
    float step;

    void Start()
    {
        codeSolvingCanvas.SetActive(false);
        hasLanded  = false;
        hasTakenOff = false;
        starting = rocket.transform.position;
        isLanding = false;
        isTakingOff = false;
        scoreP = 0;
        rb = GetComponent<Rigidbody>();
        audio = GetComponents<AudioSource>();
    }

    void Update()
    {   

        if (isLanding)
        {
            comets = GameObject.FindGameObjectsWithTag("Comet");
            for (int i = 0; i < comets.Length; i++)
            {
                comet = comets[i];
                Instantiate(explosionBlue, comet.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                Destroy(comet);
            }
                //Destroy(GameObject.FindGameObjectsWithTag("Comet")[i]);
            Landing();
            //kod za odgovor
           // Invoke("StartCodeSolving",3);
            
        }

        if (hasLanded)
        {
            Invoke("StartCodeSolving", 1);
            hasLanded = false;
        }

        if (isTakingOff)
        {
            if (rocket.transform.position.y == starting.y)
            {
                hasTakenOff = true;
                isTakingOff = false;
            }
            rocket.transform.position = Vector3.MoveTowards(transform.position, starting, 80 * Time.deltaTime);
        }

        if (hasTakenOff)
        {
            AfterTakeoff();
        }
        //rocket.transform.position = Vector3.MoveTowards(transform.position, new Vector3(planet.transform.position.x, rocket.transform.position.y, rocket.transform.position.z), step);

    }

    void StartCodeSolving()
    {
        thrusters.SetActive(false);
        codeSolvingCanvas.SetActive(true);
        codeSolvingCanvas.GetComponent<CodingGame>().InitializeGame();
    }

    void Landing()
    {

        step = 180f * Time.deltaTime;
        rocket.transform.position = Vector3.MoveTowards(rocket.transform.position, new Vector3(planetXY.x, planetXY.y, rocket.transform.position.z), step);

        if(rocket.transform.position.y == planetXY.y)
        {
            isLanding = false;
            hasLanded = true;
        }
        /* Vector3 targetDir = new Vector3(planet.transform.position.x, rocket.transform.position.y, rocket.transform.position.z) - transform.position;
         Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
         transform.rotation = Quaternion.LookRotation(newDir);*/
        
    }

    void AfterTakeoff()
    {
        backgroundFrame.GetComponent<BackgroundController>().backgroundMovementSpeed -= 30f;
        GetComponent<RaketaMovement>().enabled = true;
        cometSpawner.SetActive(true);
        hasTakenOff = false;
    }

    void takeoffSound()
    {
        audio[2].Play();    
    }

    public void Takeoff()
    {
        thrusters.SetActive(true);
        takeoffSound();
        cometSpawner.GetComponent<SpawnerComet>().SpawnSpeed 
            = cometSpawner.GetComponent<SpawnerComet>().SpawnSpeed / cometSpawner.GetComponent<SpawnerComet>().cometSpawnIncreaseModifier;
        shouldCollideWithComets = true;
        codeSolvingCanvas.SetActive(false);
        currentPlanet.GetComponent<PlanetMovement>().shouldMovePlanet = true;
        currentPlanet.GetComponent<PlanetMovement>().palnetMovementSpeed += 100f;
        backgroundFrame.GetComponent<BackgroundController>().backgroundMovementSpeed += 30f;
        backgroundFrame.GetComponent<BackgroundController>().shouldMoveBackground = true;

        isTakingOff = true;
    }


    void StartedLanding(Collider unit)
    {
        rb.velocity = new Vector3(0, 0, 0);
        transform.localEulerAngles = new Vector3(0, -4.1f, 0);
        rocket.GetComponent<RaketaMovement>().enabled = false;
        currentPlanet = unit;
        cometSpawner.SetActive(false);
        shouldCollideWithComets = false;
        unit.GetComponent<PlanetMovement>().shouldMovePlanet = false;
        planetXY = new Vector2(unit.transform.position.x, unit.transform.position.y);
        backgroundFrame.GetComponent<BackgroundController>().shouldMoveBackground = false;

        isLanding = true;

    }
    void rocketExplode()
    {
        Vector3 oldScale = explosionRed.transform.localScale;
        explosionRed.transform.localScale = new Vector3(sizeOfExplosionRocket, sizeOfExplosionRocket, sizeOfExplosionRocket);
        Instantiate(explosionRed, transform.position + new Vector3(0, +25, -45), Quaternion.identity);
        explosionRed.transform.localScale = oldScale;
        audio[3].Play();
    }
    void coinSound()
    {
        if (!GetComponent<AudioSource>().enabled) GetComponent<AudioSource>().enabled = true;
        else audio[0].Play();
    }
    void landingSound()
    {
        audio[1].Play();
    }
    void OnTriggerEnter(Collider unit)
    {
        if (unit.tag == "CheckPoint")
        {
            StartedLanding(unit);
            landingSound();
            // Poziv layout-a sa kodovima
        }
        if ((unit.tag == "Comet") && shouldCollideWithComets)
        {
            rocketExplode();
            //ovde ide kod za popup endimg screen
            //  Application.LoadLevel("Main Scene");
        }
        if(unit.tag=="Token")
        {
            coinSound();
            Destroy(unit.gameObject);
            scoreP += scorept;
        }

    }
}
