using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spins object at assigned speed along selected axis or axes
public class Spin : MonoBehaviour
{
    public float speed;
    public bool x;
    public bool y;
    public bool z;


    // Update is called once per frame
    void Update()
    {
        Spinny();
    }

    private void Spinny()
    {
        if (x)
        {
            transform.Rotate(speed * Time.deltaTime, 0, 0);
        }

        if (y)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }

        if (z)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}
