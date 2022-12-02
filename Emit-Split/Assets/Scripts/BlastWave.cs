using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 startPos;
    public int maxDist;

    private void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z <= startPos.z - maxDist)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(null))
        {
            Destroy(this.gameObject);
        }
    }
}
