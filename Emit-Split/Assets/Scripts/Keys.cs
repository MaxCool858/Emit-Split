using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public List<GameObject> keyList = new List<GameObject>();

    public GameObject Key_Blue;

    public GameObject Key_Green;

    public GameObject Key_Red;

    public GameObject Door_Blue;




    /*
    *checks for colored keys and doors
    *adds keys to list 
    *checks if door has right key color
    *if not then door stays closed
    *if yes then the door destroys
    *this can be replaced with an animation later to look smoother
    */  
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key_Blue")
        {
            Key_Blue = GameObject.Find("Key_Blue");
            keyList.Add(Key_Blue);
            
        }


        if (other.tag == "Key_Green")
        {
            Key_Blue = GameObject.Find("Key_Green");
            keyList.Add(Key_Green);

        }

        if (other.tag == "Key_Red")
        {
            Key_Blue = GameObject.Find("Key_Red");
            keyList.Add(Key_Red);

        }


        if (other.tag == "Door_Blue")
        {
           if(keyList.Contains (Key_Blue))
            {
                Destroy(GameObject.FindWithTag("Door_Blue"));
            }
           else
            {
                Debug.Log("Door is closed");
            }
        }
        if (other.tag == "Door_Green")
        {
            if (keyList.Contains(Key_Green))
            {
                Destroy(GameObject.FindWithTag("Door_Green"));
            }
            else
            {
                Debug.Log("Door is closed");
             }
        }
        if (other.tag == "Door_Red")
        {
            if (keyList.Contains(Key_Red))
            {
                Destroy(GameObject.FindWithTag("Door_Red"));
            }
            else
            {
                Debug.Log("Door is closed");
             }
        }



    }

}
