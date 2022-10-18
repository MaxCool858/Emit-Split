using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{

    public GameObject EnemyTargeted;

    public GameObject[] handler;

    public Image TargetLocked;

    public Image TargetSearch;

    public GameObject Player;
    

    void Awake()
    {
        TargetSearch.enabled = true;
        TargetLocked.enabled = false;
     
    }

    void Start()
    {

        

    }

    void Update()
    {
        Raycast();
        /*
        if (playerInput.CharacterMove.FireWeapon.triggered && player.GetComponent<UIManagement>().Energy >= 10)
        {
            FireWeapon();
        }
        */
        Debug.DrawRay(transform.position, transform.forward *100,Color.green);

    }


    //raycast to hit enemy
    void Raycast()
    {       
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.forward,out hit,100f))
        {
            //if raycast hits enemy tags, then crosshair goes red . meaning its ready to become possessable 
            if (hit.transform.tag == "Enemy" || hit.transform.tag == "Enemy_3" )
            {
                //
                TargetLocked.enabled = true;
                TargetSearch.enabled = false;
                EnemyTargeted = hit.transform.gameObject;

                //enable wehn fixing
                /*
                Player.GetComponent<UIManagement>().enabled = false;
                Player.GetComponent<Movee>().enabled = false;
                */
            }


        }

        //if no enemy present, then make crosshair back to white and clear raycast hit
        else
        {
            TargetLocked.enabled = false;
            TargetSearch.enabled = true;

            EnemyTargeted = null;

            //enable these two when fixing 
            /*
            Player.GetComponent<UIManagement>().enabled = true;
            Player.GetComponent<Movee>().enabled = true;
            */
        }

    }

   
}
