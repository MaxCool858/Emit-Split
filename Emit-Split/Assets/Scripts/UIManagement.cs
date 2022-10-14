using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{

    GameObject player;
    int Health = 10;
    public float Energy = 100;
    public Text healthtext;
    GameObject EnergyBar;
    GameObject HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Playber");
        EnergyBar = GameObject.Find("EnergyBar");
        HealthBar = GameObject.Find("HealthBar");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hurty") 
        {
            Health = Health - 1;
            healthtext.text = "Health: " + Health.ToString();
            HealthBar.GetComponent<Scrollbar>().size = Health * 0.1f;
        }
    }

    public void LoseEnergy(int energysubtract)
    {
        Energy = Energy - energysubtract;
       
        //Debug.Log(Energy);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnergyBar.GetComponent<Scrollbar>().size = Energy * 0.01f;
        if (Energy < 100)
        {
            Energy = Energy + 0.1f;
        }
        
    }
}
