using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data : EnemyClass
{
    // Start is called before the first frame update
    void Start()
    {
      

        Health = 5;
        self = this.gameObject;
        enemycontrol = GetComponent<CharacterController>();
        EnemyTypeNum = 3;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}