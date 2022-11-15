using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointMaster : MonoBehaviour
{

    private static CheckPointMaster instance;
    public Vector3 lastCheckPointPos;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
