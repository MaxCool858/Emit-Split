using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    private CheckPointMaster CP;

    void Start()
    {
        CP = GameObject.FindGameObjectWithTag("CP").GetComponent<CheckPointMaster>();
        transform.position = CP.lastCheckPointPos;
    }
    
    void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }

    }



}
