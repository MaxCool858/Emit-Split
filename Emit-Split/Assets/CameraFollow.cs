using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public float timeStart;

    public float timeDuration = 3f;

    public bool ChecktoCalculate;

    public bool moving;

    public Transform p1, p2;

    public Vector3 p01;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Transition()
    {
        ChecktoCalculate = true;
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

            this.transform.position = p01;
        }

        if (!moving)
        {
            transform.position = player.transform.position + new Vector3(0, 0, 0);
            transform.rotation = player.transform.localRotation;
        }
    }
}
