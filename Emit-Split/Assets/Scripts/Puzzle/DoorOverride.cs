using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOverride : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NewDoorOpener.Instance.doorOverride = true;
        }
    }
}
