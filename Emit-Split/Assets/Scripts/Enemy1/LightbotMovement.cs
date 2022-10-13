using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightbotMovement : MonoBehaviour
{
    public GameObject spotlight;
    private Rigidbody LightbotRb;
    private void Awake()
    {
        spotlight.SetActive(false);
    }
    private void Update()
    {

    }
    public void Movement(InputAction.CallbackContext context)
    {
        float speed = 100f;

        Debug.Log(context);
        Vector2 playerVector = context.ReadValue<Vector2>();
        LightbotRb.AddForce(new Vector3(playerVector.x, 0, playerVector.y) * speed, ForceMode.Force);
    }
}
