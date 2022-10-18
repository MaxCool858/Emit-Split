using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject blastWave;
    public GameObject player;

    private void Start()
    {
        InvokeRepeating("Shot", 2f, 2f);
    }

    private void Shot()
    {
        Instantiate(blastWave);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject == player)
        {
            Destroy(this.gameObject);
        }
    }


}
