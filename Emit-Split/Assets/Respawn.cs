using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    //Refrences to other scripts
    //make sure to take scrfipt from player inspector
    //set it to respawn script in player inspector
    public UIManagement script;
    public Movee script2;

    //sets current checkpoint
    public Vector3 VecCP;


    //checks if players health is 0
    //respawns player to last checkpoint
    void Update()
    {
        if(script.Health <= 0)
        {

            StartCoroutine(RespawnPlayer());

        }

    }

    //Colliding w/ checkpoint
    //sets that checkpoints position into VecCP
    //Colliding w/ Death
    //Respawns player

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CP")
        {
             VecCP = other.transform.gameObject.transform.position;
        }

        if(other.tag =="Death")
        {
            StartCoroutine(RespawnPlayer());

        }

    }


   
    //Access player controller
    //disables controller 
    //teleports player to last saved checkpoint
    //reenables player controller
    //sets health to max again
    IEnumerator RespawnPlayer()
    {
        script2.playercontrol.enabled = false;
        yield return new WaitForSeconds(.5f);
        gameObject.transform.position = VecCP;
        script2.playercontrol.enabled = true;
        script.Health = 10;
    }


}
