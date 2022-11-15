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

    public float timeValue = 30;



    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue += 30;
            SpawnEnemy();
        }


    }


    private void SpawnEnemy()
    {

      Instantiate(Enemy1, Spawn.transform.position, Spawn.transform.rotation);

    }



}
