using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to each of the keys
//keys must have sphere collider
public class KeyCollection : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            KeysAndElevator.Instance.keyNum++;
            Debug.Log("Keys: " + KeysAndElevator.Instance.keyNum);
        }
        /*
        if (other.gameObject == key2)
        {
            key2.SetActive(false);
            KeysAndElevator.Instance.keyNum++;
            Debug.Log("Keys: " + KeysAndElevator.Instance.keyNum);
        }

        if (other.gameObject == key3)
        {
            key3.SetActive(false);
            KeysAndElevator.Instance.keyNum++;
            Debug.Log("Keys: " + KeysAndElevator.Instance.keyNum);
        }

        if (other.gameObject == key4)
        {
            key4.SetActive(false);
            KeysAndElevator.Instance.keyNum++;
            Debug.Log("Keys: " + KeysAndElevator.Instance.keyNum);
        }
        */
    }
}
