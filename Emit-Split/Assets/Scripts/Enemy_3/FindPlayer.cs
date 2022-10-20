using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{

    public Transform playerTransform;

    public Vector3 position;

    private bool inRange;

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {

            inRange = true;
    
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = false;
        }


    }


    // Update is called once per frame
    void Update()
    {
      position = playerTransform.transform.position;


        Debug.Log("IN range " + inRange);

        if(inRange = true)
        {
            LookAtPlayer();
        }


    }

    private void LookAtPlayer()
    {
        this.transform.LookAt(position);

    }


}

