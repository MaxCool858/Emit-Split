using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfPuzzle : MonoBehaviour
{
    public GameObject RedKeyPrefab;
    public GameObject BlueKeyPrefab;
    public GameObject GreenKeyPrefab;



    public GameObject KeySpawn;

    public GameObject Teleporter1Spawn;

    public GameObject Teleporter1PreFab;


    //CHOOSE WHICH KEY TO SPAWN IN INSPECTOR

    public bool spawnRed;

    public bool spawnBlue;

    public bool spawnGreen;


    public bool ActivatedOnce = false;

    //spawns a key next to pad
    //spawns a teleporter 1- 
    //IMPORTANT-
    //MUST SET POSITION FOR TELEPORTER1 SPAWN IN CORRECT PLACE
    //BEFORE PUZZLE BEGINS 

    //IMPORTANT-
    //player AND enemies able to trigger this. Should usually only be the enemy at the END of the puzzle 
    private void OnTriggerEnter(Collider other)
    {
        if (ActivatedOnce == false)
        {

            if (other.tag == "Player" || other.tag == "Hurty")
            {
                if (spawnRed == true)
                {
                    Instantiate(RedKeyPrefab, KeySpawn.transform.position, KeySpawn.transform.rotation);


                    Instantiate(Teleporter1PreFab, Teleporter1Spawn.transform.position, Teleporter1Spawn.transform.rotation);

                    ActivatedOnce = true;
                }

                if (spawnGreen == true)
                {

                    Instantiate(GreenKeyPrefab, KeySpawn.transform.position, KeySpawn.transform.rotation);

                    Instantiate(Teleporter1PreFab, Teleporter1Spawn.transform.position, Teleporter1Spawn.transform.rotation);

                    ActivatedOnce = true;

                }

                if (spawnBlue == true)
                {

                    Instantiate(BlueKeyPrefab, KeySpawn.transform.position, KeySpawn.transform.rotation);

                    Instantiate(Teleporter1PreFab, Teleporter1Spawn.transform.position, Teleporter1Spawn.transform.rotation);

                    ActivatedOnce = true;

                }

            }
        }
    }





}
