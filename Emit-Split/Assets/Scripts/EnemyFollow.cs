    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    protected NavMeshAgent enemy;
    public Transform Player;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        //agent.destination = Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
        
    }
}
