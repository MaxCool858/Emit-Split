using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add this script to a "button" and assign a "door", a close position empty GameObject and an open position empty GameObject to allow the player to open the door while staying on the button
//This is a simple script so the door only moves down and up to open

//Door must be in closed position at start
//Button must be set to trigger
//GameObject must have "Player" tag in order for it to activate the button
public class NewDoorOpener : MonoBehaviour
{
    public static NewDoorOpener Instance;

    public GameObject door;
    public GameObject button;

    //only reads GameObject.transform.posiiton.y
    public GameObject closePoint;
    public GameObject openPoint;

    private Vector3 closePos;
    private Vector3 openPos;

    //current position of the door
    private Vector3 currentPos;

    private bool doorOpening;
    private bool doorOpen;
    private bool doorClosing;
    private bool doorClosed;
    public bool doorOverride;

    private float speed = 2f;

    private void Awake()
    {
        Instance = this;
    }

    // Sets position of open and close on start
    void Start()
    {
        currentPos = door.transform.position;
        closePos = closePoint.transform.position;
        openPos = openPoint.transform.position;
        doorClosed = true;        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOverride)
        {
            doorOpening = true;
            doorClosing = false;
        }
        DoorStatus();
    }

    //when "Player" touches button, door recieves open command
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorOpening = true;
            doorClosing = false;
        }
    }

    //when "Player" leaves button, door recieves close command
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorClosing = true;
            doorOpening = false;
        }
    }

    //Determines the current position when called and acts accordingly when swicthed
    private void DoorStatus()
    {
        // Moves door to open posotion when triggered
        if (doorOpening && !doorOpen)
        {
            if (currentPos.y <= openPos.y)
            {
                doorOpen = true;
                doorOpening = false;
            }
            else
            {
                doorClosed = false;
                door.transform.Translate(Vector3.down * speed * Time.deltaTime);
                currentPos = door.transform.position;
            }
        }
        // Moves door to closing position when triggered
        if(doorClosing && !doorClosed)
        {
            if (currentPos.y >= closePos.y)
            {
                doorClosed = true;
                doorClosing = false;
            }
            else
            {
                doorOpen = false;
                door.transform.Translate(Vector3.up * speed * Time.deltaTime);
                currentPos = door.transform.position;
            }
        }
    }
}
