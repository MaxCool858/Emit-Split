using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public float timeValue = 10;

    Collider m_Collider;

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
            //Debug.Log("Time is: " + timeValue);
        }
        else
        {
            Explode();
            timeValue += 10;

        }



        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Explode();
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


        void Explode()
        {
            Emission();
            
            Destroy(this.gameObject);

        }
        void Emission()
        {
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;

        }



    }
}
