using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attached object acts as the battery for lightbot
public class Battery : MonoBehaviour
{
    private float batteryLevel;
    private int maxCharge = 20;
    private float decayTime = 1;
    private float chargeTime = 2;

    public bool lightOn;
    public bool batteryDead;
    private bool batteryFull;
    private void Awake()
    {
        batteryLevel = maxCharge;    
    }
    
    private void Update()
    {
        if(batteryLevel <= 0)
        {
            batteryLevel = 0;
            lightOn = false;
            batteryDead = true;
            print("Battery Dead");
        }
        else
        {
            batteryDead = false;
        }

        if(batteryLevel >= maxCharge && !batteryFull)
        {
            batteryLevel = maxCharge;
            print("Battery Full");
            batteryFull = true;
        }

        if(batteryLevel == maxCharge / 4)
        {
            print("Battery Level" + batteryLevel);
        }

        if (lightOn)
        {
            batteryLevel -= decayTime * Time.deltaTime;
            Debug.Log("Battery Level: " + batteryLevel);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "charger")
        {
            if(batteryLevel <= maxCharge)
            {
                batteryLevel += chargeTime * Time.deltaTime;
                Debug.Log("battery level " + batteryLevel);
            }
            else
            {
                print("Charge complete!");
            }
           
        }
    }




}
