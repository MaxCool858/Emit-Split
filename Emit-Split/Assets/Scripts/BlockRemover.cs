using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRemover : MonoBehaviour
{  //prefabs
    // blue moves up and down
    // red moves left adn right
    // orange destroys
    //green is goal
    public GameObject SpherePrefab;
    public GameObject BluePrefab;
    public GameObject RedPrefab;
    public GameObject OrangePrefab;
    public GameObject GreenPrefab;

    //grid
    //P1 Is always for sphere prefab
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject P5;
    public GameObject P6;
    public GameObject P7;
    public GameObject P8;



    //destroy
    private GameObject BlueBlock;
    private GameObject RedBlock; 
    private GameObject OrangeBlock;
    private GameObject Sphere;


 

    // Start is called before the first frame update
    void Awake()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Reset()
    {




        Sphere =  Instantiate(SpherePrefab, P1.transform.position, P1.transform.rotation);
        BlueBlock = Instantiate(BluePrefab, P7.transform.position, P7.transform.rotation);
        RedBlock = Instantiate(RedPrefab, P8.transform.position, P8.transform.rotation);
        OrangeBlock = Instantiate(OrangePrefab, P4.transform.position, P4.transform.rotation);

        



    }

    private void Destroy()
    {
        Destroy(Sphere);
        Destroy(BlueBlock);
        Destroy(RedBlock);
        Destroy(OrangeBlock);
        Debug.Log("Destroyed");
    }



    private void OnTriggerEnter(Collider other)
    {
        //CHANGE THIS TO BULLET WHEN POSSESSION IS FIXED
        if(other.tag == "Player")
        {
            Destroy();
            Reset();
        }


    }

}
