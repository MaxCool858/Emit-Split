using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    public bool BlockOn2 = false;
    public bool BlockOn3 = false;

    public GameObject P2;
    public GameObject P3;

    public GameObject BlueBlock;

    public int speed = 2;

    private void Awake()
    {
        //Transform me = transform.position;
    }

   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet" && BlockOn2 == true)
        {
            //transform.position = new Vector3(P3.transform.position,P3.transform.rotation);
            
        }
        else if (other.tag == "Bullet" && BlockOn3 == true)
        {
            //move into p2
        }

    }



}
