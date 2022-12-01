using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Checks if keys/orbs are collected and, if player collides with trigger platform,
 * the evelator platform will rise to the endpoint
 */
public class KeysAndElevator : MonoBehaviour
{
    private static KeysAndElevator _instance;
    public static KeysAndElevator Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("KeyManager");
                go.AddComponent<KeysAndElevator>();
            }

            return _instance;
        }
    }

    public GameObject elevatePlat;
    public GameObject endPoint;

    private Vector3 platPos;
    private Vector3 posPos;
    private Vector3 startPos;
    private Vector3 endPos;

    public int keyNum { get; set; }

    private float speed = 5f;
    public float duration;
    private float startTime;

    private bool goingUp;
    [SerializeField]
    private bool isMoving;
    [SerializeField]
    private bool setMove;

    private void Awake()
    {
        _instance = this;
        //platPos = elevatePlat.transform.position;
        startPos = elevatePlat.transform.position;
        endPos = endPoint.transform.position;
        //elevatePlat.transform.position = platPos;
        //keyNum = KeyCollection.Instance.numKeys;
        Debug.Log(platPos);
        Debug.Log(startPos);
        Debug.Log(endPos);
    }

    private void Start()
    {
        keyNum = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(keyNum >= 4)
            {
                setMove = true;
                keyNum = 0;
            }
        }
    }

    private void Update()
    {
        if (setMove)
        {
            setMove = false;
            isMoving = true;
            startTime = Time.time;
        }

        if (isMoving)
        {
            float u = (Time.time - startTime) / duration;
            if (u >= 1)
            {
                u = 1;
                isMoving = false;
            }

            posPos = (1 - u) * startPos + u * endPos;
            elevatePlat.transform.position = posPos;
        }
    }
}
