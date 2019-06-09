using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject sprite1;
    public GameObject sprite2;

    public bool shouldMoveBackground;

    private float backgroundHeight;
    public float backgroundWidth;
    public float xCenter;
    public static int recycleCounter;

    public float backgroundMovementSpeed;

    private Vector3 bottomTarget;
    private Vector3 topTarget;
    private Vector3 targetPosition;

    private float backgroundOffset = 10f;



    void Start()
    {
        shouldMoveBackground = true;
        Screen.orientation = ScreenOrientation.Portrait;
        backgroundHeight = GetDimensionInPX(sprite1).y;
        bottomTarget = sprite1.transform.position - new Vector3(0, GetDimensionInPX(sprite1).y, 0);
        topTarget = sprite2.transform.position - Vector3.up * 3;
        backgroundWidth = GetDimensionInPX(sprite1).x;
        xCenter = sprite1.transform.position.x;
        recycleCounter = 0;

    }

    void Update()
    {


        if (shouldMoveBackground) { 
        MoveSpriteDown(sprite1, sprite2);
    }
        print(recycleCounter);
    }

    void MoveSpriteDown(GameObject sprite1, GameObject sprite2)
    {
        sprite1.transform.position -= new Vector3(0, backgroundMovementSpeed * Time.deltaTime, 0);
        sprite2.transform.position -= new Vector3(0, backgroundMovementSpeed * Time.deltaTime, 0);

        //when a sprite leaves the screen, move it up
        if (sprite1.transform.position.y < bottomTarget.y)
        {
            sprite1.transform.position += new Vector3(0,( backgroundHeight * 2) - backgroundOffset, 0);
            recycleCounter++;
        }
        if (sprite2.transform.position.y < bottomTarget.y)
        {
            //sprite2.transform.position = topTarget;
            sprite2.transform.position += new Vector3(0, (backgroundHeight * 2) - backgroundOffset, 0);
            recycleCounter++;
        }


    }

    public static Vector2 GetDimensionInPX(GameObject obj)
    {
        Vector2 tmpDimension;

        tmpDimension.x = obj.transform.localScale.x * obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;  // this is gonna be our width
        tmpDimension.y = obj.transform.localScale.y * obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y;  // this is gonna be our height

        return tmpDimension;
    }

}
