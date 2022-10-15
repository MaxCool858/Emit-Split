using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public List<GameObject> keyList = new List<GameObject>();

    public GameObject Key_Blue;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key_Blue")
        {
            Key_Blue = GameObject.Find("Key_Blue");
            keyList.Add(Key_Blue);
            
            Debug.Log(keyList);
        }


        if (other.tag == "Door_Blue")
        {
           if(keyList.Contains (Key_Blue))
            {
                
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
