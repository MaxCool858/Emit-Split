using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public int LeverType;

    public GameObject LeverText;

    public float timeStart;

    public float timeDuration = 3f;

    public bool ChecktoCalculate;

    public bool moving;

    public Transform p1;

    public Transform p2;

    public Vector3 p01;

    public GameObject platform;

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

    private void OnTriggerEnter(Collider collision)
    {
        LeverText.SetActive(true);
    }

    private void OnTriggerExit(Collider collision)
    {
        LeverText.SetActive(false);
    }
}
