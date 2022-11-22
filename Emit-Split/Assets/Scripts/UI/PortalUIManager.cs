using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalUIManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Portal1"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            Debug.Log("This portal has an invalid tag");
        }
        
    }
}
