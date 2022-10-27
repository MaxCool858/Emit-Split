using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    //key spawn
    public GameObject KeyPrefab;

    //Key point spawn
    public GameObject KeySpawn;



    private void WinPuzzle()
    {
        Instantiate(KeyPrefab, KeySpawn.transform.position, KeySpawn.transform.rotation);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere")
        {

            WinPuzzle();
        }
}

}
