using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{

    //public Transform playerTransform;
    public Vector3 position;
    public GameObject PlayerLoc;

    public GameObject Bullet_Emitter;

    public GameObject Bullet;

    public float ForceAmount = 10.0f;

    
    public bool inRange ;


    public bool CanShoot;


    public float timeValue = 2;


    //shoots at player every X amount of seconds
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            inRange = true;
            InvokeRepeating("Shoot", 0.2f, 0.6f);

        }
    }

    //top shooting if not in range
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            CancelInvoke();
        }


    }

    // constantly updates players location

    void Update()
    {

        PlayerLoc = GameObject.FindGameObjectWithTag("Player");


        position = PlayerLoc.transform.position;

        this.transform.LookAt(position);


    }



    //Spawns bullet at player
    private void Shoot()
    {

        GameObject Temporary_Buller_Handler;


        Temporary_Buller_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);


        Temporary_Buller_Handler.transform.Rotate(Vector3.left * 90);



        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Buller_Handler.GetComponent<Rigidbody>();


        Temporary_RigidBody.AddForce(transform.forward * ForceAmount);

        Destroy(Temporary_Buller_Handler, 10.0f);
        //    CanShoot = true;
    }





}


