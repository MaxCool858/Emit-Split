using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{

    public Transform playerTransform;

    public Vector3 position;

    public GameObject Bullet_Emitter;

    public GameObject Bullet;

    public float ForceAmount = 10.0f;


    public bool inRange ;




    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            ShootPlayer();
        }
    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        position = playerTransform.transform.position;

        if(inRange = true)
        {
            ShootPlayer();
        }

       

    }

 


    private void ShootPlayer()
    {

       GameObject Temporary_Buller_Handler;


       Temporary_Buller_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);

        Temporary_Buller_Handler.transform.Rotate(Vector3.left * 90);


        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Buller_Handler.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(transform.forward * ForceAmount);

        Destroy(Temporary_Buller_Handler, 10.0f);


    }



}


