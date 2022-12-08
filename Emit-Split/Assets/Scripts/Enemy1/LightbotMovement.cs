using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightbotMovement : MonoBehaviour
{
    public GameObject spotlight;     
    public float speed = 10f;
    Vector2 botVector;
    private bool spotlightOn;

    private void Update()
    {
        transform.Translate(botVector.x * speed * Time.deltaTime, 0, botVector.y * speed * Time.deltaTime);

        if (spotlightOn && !GetComponent<Battery>().batteryDead)
        {
            spotlight.SetActive(true);
        }
        else
        {
            spotlight.SetActive(false);
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
  

        //Debug.Log(context);
        botVector = context.ReadValue<Vector2>();
        
    }
    public void SpotOn(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        if (context.performed)
        {
            if (spotlightOn)
            {
                spotlightOn = false;
                GetComponent<Battery>().lightOn = false;
            }
            else
            {
                if (!GetComponent<Battery>().batteryDead)
                { 
                    spotlightOn = true;               
                    GetComponent<Battery>().lightOn = true;
                }
                else
                {
                    print("Battery Dead");
                }
               
            }
        }
    }
}
