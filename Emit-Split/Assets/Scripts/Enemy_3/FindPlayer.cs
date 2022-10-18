using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    //public GameObject PlayerLocation;

    public Transform playerTransform;

    public Vector3 position;

    public GameObject Bullet;

    float ForceAmount = 10.0f;// or any value you want

    private float speedofBullet = 5f;


    public bool isShooting = false;

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {

            LookAtPlayer();

            ShootAtPlayer();

            if(isShooting)
            {
                Shoot();
            }

        }

    }


    // Update is called once per frame
    void Update()
    {
      position = playerTransform.transform.position;



    }

    private void LookAtPlayer()
    {
        this.transform.LookAt(position);

    }


    
    private void ShootAtPlayer()
    {


        Instantiate(Bullet, GetComponent<Transform>().position, GetComponent<Transform>().rotation);

        isShooting = true;

    }


    IEnumerator Shoot()

    {
        Vector3 BullPos = Bullet.transform.position;
        BullPos.z += Bullet.transform.position.z * speedofBullet * Time.deltaTime;
        transform.position = BullPos;
        yield return null;
    }


}

