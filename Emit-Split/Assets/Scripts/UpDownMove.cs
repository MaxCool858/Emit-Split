using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    public bool BlockOn2 = false;
    public bool BlockOn3 = false;

    public GameObject P2;
    public GameObject P5;

    public GameObject BlueBlock;

    public int speed = 2;

    

   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && BlockOn2 == true)
        {
            StartCoroutine("Teleporting");
            BlockOn2 = false;
            BlockOn3 = true;
        }
        else if (other.tag == "Player" && BlockOn3 == true)
        {
            StartCoroutine("Teleporting2");
            BlockOn2 = true;
            BlockOn3 = false;
        }

    }


    IEnumerator Teleporting()
    {

        yield return new WaitForSeconds(.5f);

        BlueBlock.transform.position = P5.transform.position;

    }


    IEnumerator Teleporting2()
    {

        yield return new WaitForSeconds(.5f);

        BlueBlock.transform.position = P2.transform.position;

    }


}
