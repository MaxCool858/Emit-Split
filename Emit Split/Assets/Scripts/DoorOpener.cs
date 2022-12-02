using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//place this script on a "button" and assign the door you would wish it to open
//staying on the button will open the door but leaving it will close it again
public class DoorOpener : MonoBehaviour
{
    public GameObject door;
    private Vector3 doorPos;
    public GameObject button;
    public GameObject closePoint;
    private Vector3 closePos;
    public GameObject openPoint;
    private Vector3 openPos;

    private bool isClosed;
    private bool goingUp;
    private bool goingLeft;
    private bool goingRight;

    private float speed = 0.025f;
    private float origSpeed;
    private float doorTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        origSpeed = speed;
        doorPos = door.transform.position;
        openPos = openPoint.transform.position;
        closePos = closePoint.transform.position;

        if (openPos.x > doorPos.x && openPos.y == doorPos.y && openPos.z == doorPos.z)
        {
            goingRight = true;
        }
        else if (openPos.x < doorPos.x && openPos.y == doorPos.y && openPos.z == doorPos.z)
        {
            goingLeft = true;
        }
        else if(openPos.y > doorPos.y && openPos.x == doorPos.y && openPos.z == doorPos.z)
        {
            goingUp = true;
        }
        else if(openPos.y < doorPos.y && openPos.x == doorPos.y && openPos.z == doorPos.z)
        {
            goingUp = false;
        }
        else
        {
            Debug.Log("doorPos needs to have the same position as openPos except for in the direction you want it to open");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            StartCoroutine(OpenDoor(doorTime));
        }

        if (other.CompareTag("heavy"))
        {
            StartCoroutine(OpenDoor(doorTime));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(CloseDoor(doorTime));
    }

    private IEnumerator OpenDoor(float time)
    {
        speed = origSpeed;
        door.transform.position = closePos * speed * Time.deltaTime;
        yield return new WaitForSeconds(time);
        speed = 0;        
    }

    private IEnumerator CloseDoor(float time)
    {
        speed = origSpeed;
        door.transform.Translate(closePos * speed * Time.deltaTime);
        yield return new WaitForSeconds(time);
        speed = 0;
    }



    private void CloseDoor()
    {

    }

}
