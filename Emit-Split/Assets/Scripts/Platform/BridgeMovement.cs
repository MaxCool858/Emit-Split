using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adding this to a platform makes the platform move vertically AND rotate on the y axis
public class BridgeMovement : MonoBehaviour
{
    //the speed that the platform moves
    private float speed = 10f;
    private float spinSpeed = 30f;

    //the vertical position of the object
    private Vector3 vertPos;

    //determine vertical direction
    public bool goingUp;

    //Points at which the platform will stop and go the other way
    //[SerializeField]
    public GameObject upperBound;
    private Vector3 upPos;
    //[SerializeField]
    public GameObject lowerBound;
    private Vector3 downPos;
    
    // Start is called before the first frame update
    void Start()
    {
        vertPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        upPos = upperBound.transform.position;
        downPos = lowerBound.transform.position;
        goingUp = true;

    }

    // Update is called once per frame
    void Update()
    {
        UpAndDown();
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
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
