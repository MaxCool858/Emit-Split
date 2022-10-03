using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{

    public GameObject EnemyTargeted;

    public GameObject[] handler;

    public Image TargetLocked;

    void Awake()
    {
        TargetLocked.enabled = false;
    }

    void Start()
    {

        

    }

    void Update()
    {
        Raycast();
            
        Debug.DrawRay(transform.position, transform.forward *50,Color.green);

    }


    //raycast to hit enemy
    void Raycast()
    {       
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.forward,out hit,50f))
        {
            //if enemy by tag
            if (hit.transform.tag == "Enemy")
            {
                //
                TargetLocked.enabled = true;
                EnemyTargeted = hit.transform.gameObject;

                Debug.Log("Trget" + EnemyTargeted);

             Debug.Log("Hit Enemy");

            }
            
            
        }
        else
        {
            TargetLocked.enabled = false;
            Debug.Log("Hitting nothing");
            EnemyTargeted = null;
        }

    }


}
