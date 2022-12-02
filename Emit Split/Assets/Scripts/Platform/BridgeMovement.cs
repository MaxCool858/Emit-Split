using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adding this to a platform makes the platform move vertically between assigned bounds
public class BridgeMovement : MonoBehaviour
{
    //the speed that the platform moves
    private float speed =5f;

    //determine vertical direction
    public bool goingUp;

    //Points at which the platform will stop and go the other way and their respective position
    public GameObject upperBound;
    private Vector3 upPos;
    public GameObject lowerBound;
    private Vector3 downPos;
    
    // Start is called before the first frame update
    void Start()
    {
        upPos = upperBound.transform.position;
        downPos = lowerBound.transform.position;
        goingUp = true;

    }

    // Update is called once per frame
    void Update()
    {
        UpAndDown();
    }

    //Method to move the platform up and down
    private void UpAndDown()
    {
        if (goingUp)
        {
            if (transform.position.y >= upPos.y)
            {
                goingUp = false;
            }
            else
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        else
        {
            if(transform.position.y <= downPos.y)
            {
                goingUp = true;
            }
            else
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
}
