using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyType_Exploder_Blue : EnemyClass
{
    public GameObject dirtparticles;
    public GameObject Hat;
    public GameObject digbox;
    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
        self = this.gameObject;
        enemycontrol = GetComponent<CharacterController>();
        EnemyTypeNum = 33;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.name == "Fist")
        {
            LoseHealth(1);
        }
    }
}
