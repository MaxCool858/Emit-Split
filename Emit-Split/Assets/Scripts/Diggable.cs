using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggable : MonoBehaviour
{
    [SerializeField]
    public int DiggableType;

    public GameObject coinfield;

    public GameObject platform;

    public Transform p1;

    public Transform p2;

    public Vector3 p01;

    public bool coinspawn = true;

    public bool platformspawn;

    public float timeStart;

    public float timeDuration = 3f;

    public bool ChecktoCalculate;

    public bool moving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ChecktoCalculate)
        {
            ChecktoCalculate = false;
            moving = true;
            timeStart = Time.time;
        }

        if (moving)
        {
            float u = (Time.time - timeStart) / timeDuration;
            if (u >= 1)
            {
                u = 1;
                moving = false;
            }

            p01 = (1 - u) * p1.position + u * p2.position;

            platform.transform.position = p01;
        }
    }

    void ActivatePlatform()
    {
        ChecktoCalculate = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (DiggableType == 1 && other.tag == "Diggable") 
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
        if (DiggableType == 2)
        {
            if (coinspawn == true)
            {
                coinspawn = false;
                coinfield.SetActive(true);
            }
        }
        if (DiggableType == 3 && other.tag == "Diggable") 
        {
            if (platformspawn == true)
            {
                platformspawn = false;
                ActivatePlatform();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (DiggableType == 1 && other.tag == "Diggable") 
        {
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
