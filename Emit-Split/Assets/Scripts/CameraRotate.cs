using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Vector2 turn;

    //disables mouse on screen
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    //takes positions of x and y of camera and rotates
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");

        turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
