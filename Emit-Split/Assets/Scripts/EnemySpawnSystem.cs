using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public GameObject Spawn;

    public bool EnemyAlive =true;

    public float timeValue = 10;



    void Update()
    {

        if(GameObject.Find("Hurty") != null)
        {
            EnemyAlive = true;

        }
        else
        {
            EnemyAlive = false;
        }

        if (EnemyAlive == false)

        {
            SpawnEnemy();
        }

    }


    private void SpawnEnemy()
    {

      Instantiate(Enemy1, Spawn.transform.position, Spawn.transform.rotation);

    }



}
