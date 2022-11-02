using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDestroy : MonoBehaviour
{
    //destroys key upon touch
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }


}
