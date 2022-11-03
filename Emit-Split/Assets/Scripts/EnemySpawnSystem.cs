using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public GameObject Spawn;

    public bool EnemyinRange =true;

   void Update()
    {
        if(EnemyinRange == false)
        {
            CheckRadius();
        }

    }

    void OnTriggerEnter (Collider other)
    {
        

        if (other.tag == "Hurty" )
        {
            EnemyinRange = true;

        }

    }

    void OnTriggerExit (Collider other)
    {
        if(other.tag == "Hurty")
        {
            EnemyinRange = false;
        }
    }


    private void CheckRadius()
    {

        GameObject EnemyX;


        EnemyX = Instantiate(Enemy1, Spawn.transform.position, Spawn.transform.rotation);

    }


}
