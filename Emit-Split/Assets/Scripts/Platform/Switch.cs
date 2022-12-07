using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{   
    //the speed that the platform moves
    private float speed = 2f;

    //determine vertical direction
    public bool goingUp;

    //determines if the switch was flipped, activating the platform
    public bool powerOn;

    //Points at which the platform will stop and go the other way
    public GameObject upperBound;
    private Vector3 upPos;
    public GameObject lowerBound;
    private Vector3 downPos;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        upPos = upperBound.transform.position;
        downPos = lowerBound.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //moves platform up and down if it has been activated
        if (powerOn)
        {
            UpAndDown();
        }

    }

    //Method to move the platform up and down
    private void UpAndDown()
    {
        if (goingUp)
        {
            if (platform.transform.position.y >= upPos.y)
            {
                goingUp = false;
            }
            else
            {
                platform.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        else
        {
            if (platform.transform.position.y <= downPos.y)
            {
                goingUp = true;
            }
            else
            {
                platform.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerOn = true;
            Debug.Log("switched on");
            Destroy(Spin.Instance);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Spin.Instance.speed = 10;
            Debug.Log("switched off");
        }
    }
   
}
