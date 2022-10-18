using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25.0f;
    private Rigidbody rb;
    private Vector2 screenBounds;

    public GameObject Player;

    public Transform playerTransform;

    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(position.x,position.y, speed) ;
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

        position = playerTransform.transform.position;




        /*
        if (transform.position.y > screenBounds.y * -4)
        {
            Destroy(this.gameObject);
        }
        */
    }

    //kill enemy with bullet
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }

}