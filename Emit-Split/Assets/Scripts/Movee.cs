using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movee : MonoBehaviour
{
    NotStupid playerInput;

    Vector2 CurrentInput;
    Vector3 CurrentMovement;
    bool isMoving;
    float rotationPerFrame = 1.0f;
    int speed = 5;

    public Transform shootpoint;

    public GameObject Fist;

    GameObject player;

    CharacterController playercontrol;


    private void Awake()
    {
        playerInput = new NotStupid();
        playercontrol = GetComponent<CharacterController>();
        playerInput.CharacterMove.Move.started += onMoveInput;
        playerInput.CharacterMove.Move.canceled += onMoveInput;
        playerInput.CharacterMove.Move.performed += onMoveInput;
        player = GameObject.Find("Player");
        shootpoint = GameObject.Find("shootpoint").transform;
        //Fist = GameObject.Find("Fist");
    }
    
    void FireWeapon()
    {
        player.GetComponent<UIManagement>().LoseEnergy(10);
        Fist.SetActive(true);
        StartCoroutine(HitDelay());
        //Fist.SetActive(false);
    }

    IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(1);
        Fist.SetActive(false);
    }
    
    void FireSplitter()
    {
        player.GetComponent<UIManagement>().LoseEnergy(0);
        Ray ray = new Ray(shootpoint.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Debug.DrawRay(ray.origin, ray.direction * 10);
        Debug.Log(hit.point);
        Debug.Log(hit.collider);
        if (hit.collider != null && hit.collider.gameObject.tag == "Hurty")
        {
            SwapTo(hit);
        }
    }

    private void SwapTo(RaycastHit hit)
    {
        player.GetComponent<UIManagement>().enabled = false;
        hit.collider.gameObject.tag = "Player";
        player = hit.collider.gameObject;
        player.GetComponent<UIManagement>().enabled = true;
        playercontrol.enabled = false;
        playercontrol = hit.collider.gameObject.GetComponent<EnemyClass>().enemycontrol;
        playercontrol.enabled = true;


    }

    void onMoveInput(InputAction.CallbackContext ctx)
    {
        CurrentInput = ctx.ReadValue<Vector2>();
        CurrentMovement.x = CurrentInput.x;
        CurrentMovement.z = CurrentInput.y;
        isMoving = CurrentInput.x != 0 || CurrentInput.y != 0;
    }

    void RotatePlayer()
    {
        Vector3 PositionFacing;
        PositionFacing.x = CurrentMovement.x;
        PositionFacing.y = 0.0f;
        PositionFacing.z = CurrentMovement.z;
        Quaternion currentAngle=transform.rotation;

        

        if (isMoving)
        {
            Quaternion targetAngle = Quaternion.LookRotation(PositionFacing);
            transform.rotation = Quaternion.Slerp(currentAngle, targetAngle, rotationPerFrame*Time.deltaTime*speed);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if (playerInput.CharacterMove.FireWeapon.triggered && player.GetComponent<UIManagement>().Energy >= 10)
        {
            FireWeapon();
        }

        /*
        if (playerInput.CharacterMove.FireSplitter.triggered && player.GetComponent<UIManagement>().Energy >= 50)
        {
            FireSplitter();
        }
        */
        playercontrol.Move(CurrentMovement*Time.deltaTime*speed);
        RotatePlayer();
        
    }

    void OnEnable()
    {
        playerInput.CharacterMove.Enable();
    }

    void OnDisable()
    {
        playerInput.CharacterMove.Disable();
    }


}
