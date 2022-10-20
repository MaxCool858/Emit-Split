using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjects : MonoBehaviour
{
    public GameObject lightSource;
    public GameObject hiddenObject;
    private bool objectHidden;
    private void Awake()
    {
        objectHidden = true;
    }

    private void Update()
    {
        if (objectHidden)
        {
            hiddenObject.SetActive(false);
        }
        else
        {
            hiddenObject.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "light")
        {
            objectHidden = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "light")
        {
            objectHidden = true;
        }
    }
}
