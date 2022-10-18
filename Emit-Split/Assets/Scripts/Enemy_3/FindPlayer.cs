using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    //public GameObject PlayerLocation;

    public Transform playerTransform;

    public Vector3 position;

    public GameObject Bullet;

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {

            LookAtPlayer();

          //  StartCoroutine(ShootAtPlayer());

        }

    }


    // Update is called once per frame
    void Update()
    {
      position = playerTransform.transform.position;



    }

    private void LookAtPlayer()
    {
        this.transform.LookAt(position);

    }

 
/*
    private IEnumerator ShootAtPlayer()
    {
        Instantiate(Bullet);
    }
*/
}

