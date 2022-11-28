    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    protected NavMeshAgent enemy;
    public Vector3 Player;

    private GameObject PlayerGO;
    // Start is called before the first frame update
    void Start()
    {
        PlayerGO  = GameObject.FindWithTag("Player");


        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        Player = PlayerGO.transform.position;



        enemy.SetDestination(Player);
        
    }
}
