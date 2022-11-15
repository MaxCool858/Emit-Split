using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointMaster CP;


    void Start()
    {
        CP = GameObject.FindGameObjectWithTag("CP").GetComponent<CheckPointMaster>();
    }



    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            CP.lastCheckPointPos = transform.position;

            ChangeColor();

        }   

    }

    private void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}
