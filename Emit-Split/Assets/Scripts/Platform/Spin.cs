using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spins object at assigned speed along selected axis or axes
public class Spin : MonoBehaviour
{
    public static Spin Instance;
    public float speed;
    public bool x;
    public bool y;
    public bool z;
    public bool spinActive;

    private void Start()
    {
        spinActive = true;
    }
    private void Update()
    {
        if (spinActive)
        {
            Spinny();
        }
    }

    private void Awake()
    {
        Instance = this;
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
