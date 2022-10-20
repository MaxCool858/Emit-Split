using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCharge : MonoBehaviour
{
    private int batteryLevel;
    private int maxCharge = 100;
    private float chargeTime = 60f;
    private bool isCharging;
    public bool lightOn;
    public GameObject lightSource;

    private void Awake()
    {

        batteryLevel = maxCharge;
    }

    void Update()
    {
        if (lightSource.activeSelf)
        {
            lightOn = true;
        }
        else
        {
            lightOn = false;
        }

        if (batteryLevel <= 0)
        {
            batteryLevel = 0;
            lightSource.SetActive(false);
        }
        else
        {
            lightSource.SetActive(true);
        }

        if (batteryLevel > maxCharge)
        {
            batteryLevel = maxCharge;
        }

        Debug.Log("Battery Level: " + BatteryManagement());

    }
    private int BatteryManagement()
    {
        if (lightOn == true && isCharging == false)
        {
            StartCoroutine(BatteryDecay());
        }

        if (isCharging == true)
        {
            if (batteryLevel < maxCharge)
            {
                StartCoroutine(BatteryCharge());
            }

            else if (batteryLevel >= maxCharge)
            {
                Debug.Log("Fully Charged!");
            }
        }

        return batteryLevel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "charger")
        {
            isCharging = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "charger")
        {
            isCharging = false;
        }
    }

    IEnumerator BatteryDecay()
    {
        yield return new WaitForSeconds(chargeTime);
        batteryLevel--;
    }

    IEnumerator BatteryCharge()
    {
        yield return new WaitForSeconds(chargeTime);
        batteryLevel++;
    }
}
