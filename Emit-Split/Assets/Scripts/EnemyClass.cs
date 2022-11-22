using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public int Health;
    public GameObject self;

    public Transform groundcheck;

    public CharacterController enemycontrol;

    public int EnemyTypeNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(int Damage)
    {
        Health = Health - Damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
