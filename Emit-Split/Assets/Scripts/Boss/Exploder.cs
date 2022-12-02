using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public float timeValue = 2;

    Collider m_Collider;


    //Ring Spawn
    public GameObject Ring;
    public GameObject RingSpawner;



    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(Explode());

        }


      


        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Explode());
               // Destroy(other.gameObject);
            }

            if (other.tag == "Boss")
            {
                Debug.Log("code");
                //check if colors match

            }


        }

        void Radius()
        {
            m_Collider.enabled = true;
        }


        IEnumerator Explode()
        {
            this.GetComponent<EnemyFollow>().enabled = false;

            this.GetComponent<MeshRenderer>().enabled = false;

            Instantiate(Ring, RingSpawner.transform.position, RingSpawner.transform.rotation);

            yield return new WaitForSeconds(.75f);

            Destroy(this.gameObject);

        }
      


    }
}
