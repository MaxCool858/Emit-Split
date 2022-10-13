using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightDetect : MonoBehaviour
{
    //objects that the spotlight can enable
    public bool ventDetected = false;
    public bool potionDetected = false;
    public bool portalDetected = false;
    private bool lightOn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "vent")
        {
            ventDetected = true;
            Debug.Log("I found a vent!");
            
        }

        if(other.tag == "potion")
        {
            potionDetected = true;
            Debug.Log("I found a potion!");
        }
    }
}
