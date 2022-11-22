using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    //public float ForceAmount = .05f;

    public float xForce = 0.5f;

    public float yForce = 2f;

    public float zForce = 0.5f;




    private void Update()
    {
        PushForward();
    }


    private void PushForward()
    {

        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;

        x = x + xForce;
        y = y - yForce;
        z = z - zForce;
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = this.gameObject.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(x,y,z);



    }


}
