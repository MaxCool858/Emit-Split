using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Mechanics : MonoBehaviour
{
    //Color Changer 
    private bool BlueOn = false;
    private bool RedOn = true;
    private bool GreenOn = false;


    //Spawn Enemies
    public GameObject exploder_red;
    public GameObject exploder_blue;
    public GameObject exploder_green;
    public GameObject ESpawn1;
    public GameObject ESpawn2;
    public GameObject ESpawn3;
    public GameObject ESpawn4;
    public GameObject ESpawn5;
    public GameObject ESpawn6;
    public GameObject ESpawn7;

    public GameObject ESpawn;
    public bool SpawnCycle1 = true;
    public bool SpawnCycle2 = false;
    public bool SpawnCycle3 = false;


    //Timer
    public float timeValue = 2;

    //Ring Spawn
    public GameObject Ring;
    public GameObject RingSpawner;


    //Phases
    public bool Phase1 = true;
    public bool Phase2 = false;
    public bool Phase3 = false;

    //render
    public Renderer rend;

    void Start()
    {
        ChangeColor();
        SpawnEnemies();
        RingSpawn();
        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }
    // Update is called once per frame
    void Update()
    {
        
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
                //Debug.Log("Time is: " + timeValue);
            }
            else
            {
                timeValue += 10;
               // Debug.Log("Timer reset");
                ChangeColor();
                SpawnEnemies();
                RingSpawn();
            }

        
    
        }


        void ChangeColor()
        {

            if (RedOn)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                RedOn = false;
                BlueOn = true;
            }

            else if (BlueOn)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                BlueOn = false;
                GreenOn = true;

            }
            else if (GreenOn)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                GreenOn = false;
                RedOn = true;
            }


        }

        void SpawnEnemies()
        {
            if (Phase1)
            {

                if (SpawnCycle1)
                {
                    Instantiate(exploder_red, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_green, ESpawn1.transform.position, ESpawn1.transform.rotation);

                    Instantiate(exploder_blue, ESpawn3.transform.position, ESpawn3.transform.rotation);


                    SpawnCycle1 = false;
                    SpawnCycle2 = true;

                }
                else if (SpawnCycle2)
                {
                    Instantiate(exploder_green, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_blue, ESpawn1.transform.position, ESpawn1.transform.rotation);

                    Instantiate(exploder_red, ESpawn3.transform.position, ESpawn3.transform.rotation);


                    SpawnCycle2 = false;
                    SpawnCycle3 = true;
                }
                else if (SpawnCycle3)
                {

                    Instantiate(exploder_blue, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_red, ESpawn1.transform.position, ESpawn1.transform.rotation);

                    Instantiate(exploder_green, ESpawn3.transform.position, ESpawn3.transform.rotation);


                    SpawnCycle3 = false;
                    SpawnCycle1 = true;
                }
            }
            else if (Phase2)
            {
                if (SpawnCycle1)
                {
                    Instantiate(exploder_red, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_green, ESpawn1.transform.position, ESpawn1.transform.rotation);
                    Instantiate(exploder_red, ESpawn2.transform.position, ESpawn2.transform.rotation);
                    Instantiate(exploder_blue, ESpawn3.transform.position, ESpawn3.transform.rotation);
                    Instantiate(exploder_green, ESpawn4.transform.position, ESpawn4.transform.rotation);

                    SpawnCycle1 = false;
                    SpawnCycle2 = true;

                }
                else if (SpawnCycle2)
                {
                    Instantiate(exploder_green, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_blue, ESpawn1.transform.position, ESpawn1.transform.rotation);
                    Instantiate(exploder_green, ESpawn2.transform.position, ESpawn2.transform.rotation);
                    Instantiate(exploder_red, ESpawn3.transform.position, ESpawn3.transform.rotation);
                    Instantiate(exploder_blue, ESpawn4.transform.position, ESpawn4.transform.rotation);

                    SpawnCycle2 = false;
                    SpawnCycle3 = true;
                }
                else if (SpawnCycle3)
                {

                    Instantiate(exploder_blue, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_red, ESpawn1.transform.position, ESpawn1.transform.rotation);
                    Instantiate(exploder_blue, ESpawn2.transform.position, ESpawn2.transform.rotation);
                    Instantiate(exploder_green, ESpawn3.transform.position, ESpawn3.transform.rotation);
                    Instantiate(exploder_red, ESpawn4.transform.position, ESpawn4.transform.rotation);

                    SpawnCycle3 = false;
                    SpawnCycle1 = true;
                }


            }
            else if (Phase3)
            {
                if (SpawnCycle1)
                {
                    Instantiate(exploder_red, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_green, ESpawn1.transform.position, ESpawn1.transform.rotation);
                    Instantiate(exploder_red, ESpawn2.transform.position, ESpawn2.transform.rotation);
                    Instantiate(exploder_blue, ESpawn3.transform.position, ESpawn3.transform.rotation);
                    Instantiate(exploder_green, ESpawn4.transform.position, ESpawn4.transform.rotation);

                    SpawnCycle1 = false;
                    SpawnCycle2 = true;

                }
                else if (SpawnCycle2)
                {
                    Instantiate(exploder_green, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_blue, ESpawn1.transform.position, ESpawn1.transform.rotation);
                    Instantiate(exploder_green, ESpawn2.transform.position, ESpawn2.transform.rotation);
                    Instantiate(exploder_red, ESpawn3.transform.position, ESpawn3.transform.rotation);
                    Instantiate(exploder_blue, ESpawn4.transform.position, ESpawn4.transform.rotation);

                    SpawnCycle2 = false;
                    SpawnCycle3 = true;
                }
                else if (SpawnCycle3)
                {

                    Instantiate(exploder_blue, ESpawn.transform.position, ESpawn.transform.rotation);
                    Instantiate(exploder_red, ESpawn1.transform.position, ESpawn1.transform.rotation);
                    Instantiate(exploder_blue, ESpawn2.transform.position, ESpawn2.transform.rotation);
                    Instantiate(exploder_green, ESpawn3.transform.position, ESpawn3.transform.rotation);
                    Instantiate(exploder_red, ESpawn4.transform.position, ESpawn4.transform.rotation);

                    SpawnCycle3 = false;
                    SpawnCycle1 = true;
                }


            }

        }



        void RingSpawn()

        {
         if (Phase1)
          {

            Instantiate(Ring, RingSpawner.transform.position, RingSpawner.transform.rotation);

          }
    

        }





        void OnTriggerEnter(Collider other)
        {
            /*
            if(other.tag == "Exploder_Red" && RedOn)
            {
                Damage();
            }
            else if(other.tag == "Exploder_Blue" && BlueOn)
            {
                Damage();
            }
            else if(other.tag == "Exploder_Green" && GreenOn)
            {
                Damage();
            }
            */
            //delete below- ONLY FOR TESTING- NEED POSSESION
            if (other.tag == "Player" && RedOn)
            {
                Damage();
            }
            else if (other.tag == "Player" && BlueOn)
            {
                Damage();
            }
            else if (other.tag == "Player" && GreenOn)
            {
                Damage();
            }
        }


        void Damage()
        {
            if (Phase1)
            {
                Phase1 = false;
                Phase2 = true;
               
            }
            else if (Phase2)
            {
                Phase2 = false;
                Phase3 = true;
          
            }
            else if (Phase3)
            {
                Death();
            }
        }

        void Death()
        {
        Destroy(this.gameObject);
        }





    }


