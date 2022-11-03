using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    public bool BlockOn3 = false;
    public bool BlockOn6 = false;

    public GameObject P3;
    public GameObject P6;

    public GameObject RedBlock;

    public int speed = 2;

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && BlockOn3 == true)
        {
            StartCoroutine("Teleporting");
            BlockOn3 = false;
            BlockOn6 = true;
        }
        else if (other.tag == "Player" && BlockOn6 == true)
        {
            StartCoroutine("Teleporting2");
            BlockOn3 = true;
            BlockOn6 = false;
        }

    }


    IEnumerator Teleporting()
    {

        yield return new WaitForSeconds(.5f);

        RedBlock.transform.position = P6.transform.position;

    }


    IEnumerator Teleporting2()
    {

        yield return new WaitForSeconds(.5f);

        RedBlock.transform.position = P3.transform.position;

    }
}
