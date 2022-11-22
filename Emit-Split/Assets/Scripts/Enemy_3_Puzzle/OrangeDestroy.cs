using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeDestroy : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        //REPLACE THIS WITH BULLETw
        if(other.tag == "Player")
        {
            Object.Destroy(this.gameObject);
        }

        
    }


}
