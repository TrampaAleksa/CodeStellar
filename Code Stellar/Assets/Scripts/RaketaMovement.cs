using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaketaMovement : MonoBehaviour
{
    public float rocketSpeed;
    private float screenCenterX;
    public float tilt;
    
    public GameObject backgroundFrame;
    private float rocketWidth;
    private float backgroundWidth;
    private float xCenter;
    public float rotationSpeed;
    private Vector3 startEular;
    //da li se raketa krece
    private bool notMoving = false;
    private bool levo;
    private bool desno;
    //uglov za raket
    public float rotationAngleY;
    public float rotationAngleZ;
    public float returnRotationSpeed;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        screenCenterX = Screen.width * 0.5f;
        backgroundWidth = backgroundFrame.GetComponent<BackgroundController>().backgroundWidth;
        xCenter = backgroundFrame.GetComponent<BackgroundController>().xCenter;
        startEular = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //touch unos i kretanje
        touchAndMovment();
        ComputerMovement();
        teleport();

    }
    void ComputerMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-rocketSpeed * Time.deltaTime, 0, 0);
            rotation();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(0, 0, 0);
           notMoving = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(rocketSpeed * Time.deltaTime, 0, 0);
            rotation2();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
            rb.velocity = new Vector3(0, 0, 0);
        if (notMoving)
        {
            rotation3();
        }
    }
    void touchAndMovment()
    {
        // Ako ima dodir trenutno
        if (Input.touchCount > 0)
        {
            // Uzima prvi dodir
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.position.y < Screen.height * 0.5f)
            {
                if (firstTouch.position.x > screenCenterX)
                {
                    //Ako je dodirnuo desnu stranu ekrana pomera desno
                    rb.velocity = new Vector3(rocketSpeed * Time.deltaTime, 0, 0);
                    rotation2();

                }
                else if (firstTouch.position.x < screenCenterX)
                {
                    //Ako je dodirnuo levu stranu ekrana pomera levo 
                    rb.velocity = new Vector3(-rocketSpeed * Time.deltaTime, 0, 0);
                    rotation();
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            rotation3();
        }


    }

    void teleport()
    {
        // Ovde je prebacaj sa desne na levu
        if (transform.position.x > xCenter + backgroundWidth / 2)
        {
            transform.position = new Vector3(xCenter - backgroundWidth / 2, transform.position.y, transform.position.z);
        }
        // Ovde je prebacaj sa leve na desnu
        if (transform.position.x < xCenter - backgroundWidth / 2)
        {
            transform.position = new Vector3(xCenter + backgroundWidth / 2, transform.position.y, transform.position.z);
        }

    }
    //rotacija u desno
    void rotation()
    {
        Vector3 euler = transform.localEulerAngles;
        euler.y = Mathf.LerpAngle(euler.y, rotationAngleY, rotationSpeed * Time.deltaTime);
        euler.z = Mathf.LerpAngle(euler.z, rotationAngleZ, rotationSpeed * Time.deltaTime);
        transform.localEulerAngles = euler;
    }
    //rotacija u levo
    void rotation2()
    {
        Vector3 euler = transform.localEulerAngles;
        euler.y = Mathf.LerpAngle(euler.y, -rotationAngleY, rotationSpeed * Time.deltaTime);
        euler.z = Mathf.LerpAngle(euler.z, -rotationAngleZ, rotationSpeed * Time.deltaTime);
        transform.localEulerAngles = euler;
    }
    //vraca rotaciju kad ne pipa
    void rotation3() {
        Vector3 euler = transform.localEulerAngles;
        euler.y = Mathf.LerpAngle(euler.y, startEular.y, returnRotationSpeed * Time.deltaTime);
        euler.z = Mathf.LerpAngle(euler.z, startEular.z, returnRotationSpeed * Time.deltaTime);
        transform.localEulerAngles = euler;
    }


    /* void OnTriggerEnter(Collider unit)
    {
        if (unit.tag == "CheckPoint")
        {
            // Poziv layout-a sa kodovima
        }
        if (unit.tag == "Comet")
        {
            //ovde ide kod za popup endimg screen
          //  Application.LoadLevel("Main Scene");
        }

    }*/


}