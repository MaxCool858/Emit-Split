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
                Door_Blue = GameObject.Find("Door_Blue");
                Destroy(Door_Blue);
                Debug.Log("Door is open");
            }
           else
            {
                Debug.Log("Door is closed");
            }
        }

    

    }

    private void CheckIfKey()
    {
        //if(keyList)

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




    }

}
