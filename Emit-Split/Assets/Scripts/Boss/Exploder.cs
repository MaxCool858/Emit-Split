using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Explode();

        }

        if(other.tag == "Boss")
        {
            Debug.Log("code");
            //check if colors match

        }


    }

    private void Explode()
    {
        Destroy(this.gameObject);
    }

    


}
