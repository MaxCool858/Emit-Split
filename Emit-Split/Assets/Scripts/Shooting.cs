using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject blastWave;
    public GameObject playerWeapon;

    private void Start()
    {
        InvokeRepeating("Shot", 2f, 2f);
    }

    private void Shot()
    {
        Instantiate(blastWave, this.transform.position, this.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (playerWeapon.activeSelf)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("You Died");
            }           
        }
    }
}
