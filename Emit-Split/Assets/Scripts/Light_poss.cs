using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_poss : EnemyClass
{

    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
        self = this.gameObject;
        enemycontrol = GetComponent<CharacterController>();
        EnemyTypeNum = 1;
    }

   
    
}
