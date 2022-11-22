using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{


    public GameObject Bullet_Emitter;

    public GameObject Bullet;

    public float ForceAmount = 10.0f;


    public bool inRange ;


    public bool CanShoot;

    

    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            inRange = true;
            CanShoot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            CanShoot = false;
        }


    }

    // checks if player is in range, if so, then it shoots

    void Update()
    {
      



        if (CanShoot == true && inRange == true)
        {
            
             ShootPlayer();
            CanShoot = false;
            StartCoroutine(Reload());
            
        }   


        
    }


    //shoots player 
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

    //delay after every shot
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3);
        CanShoot = true;
    }



}


