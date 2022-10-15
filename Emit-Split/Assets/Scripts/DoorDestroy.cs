using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroy : MonoBehaviour
{

    public Keys keys;

    private List<GameObject> keyList;
    
    

    void Update()
    {

        keyList = keys.keyList;

    }


    public void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player" )//&& keylist.Contains(Key_Blue))
        {
            Debug.Log("in keylist " + keyList); 

          //  Destroy(gameObject);
        }


    }



   
}
