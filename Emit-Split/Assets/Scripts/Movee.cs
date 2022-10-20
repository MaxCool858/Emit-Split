using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movee : MonoBehaviour
{
    NotStupid playerInput;

    Vector2 CurrentInput;//recieves player inputs
    Vector3 CurrentMovement;//coords where you want the player to move
    Vector3 CurrentRunMovement;
    float RunMultiplier = 3.0f;
    bool isMoving; //detects button presses
    bool isRunPressed; //detects running
    float rotationPerFrame = 1.0f; //rotation speed of player
    int speed = 5; //player speed

    public Transform shootpoint;//where the splitter raycast is launched from

    public GameObject Fist;//object with hitbox that works as melee attack

    GameObject player; //the player's gameobject

    CharacterController playercontrol; //character controller attached to player

    //variables for the jump
    bool isJumpPressed = false;
    float initialjumpvelocity;
    float maxJumpHeight = 1.0f;
    float maxJumpTime = 0.5f;
    bool isJumping = false;


    //gravity
    float gravity = -9.8f;
    float groundGravity = -.05f;


    private void Awake()
    {
        playerInput = new NotStupid(); //creates a unique ControlScheme for this script
        playercontrol = GetComponent<CharacterController>(); //Sets player control to this script's character controller
        playerInput.CharacterMove.Move.started += onMoveInput; //if the player is pressing WASD move them using onMoveInput
        playerInput.CharacterMove.Move.canceled += onMoveInput; //same
        playerInput.CharacterMove.Move.performed += onMoveInput; //same
        playerInput.CharacterMove.Run.started += onRun;
        playerInput.CharacterMove.Run.canceled += onRun;
        playerInput.CharacterMove.Jump.started += onJump;
        playerInput.CharacterMove.Jump.canceled += onJump;
        player = GameObject.Find("Playber"); //sets the player object to an object in the scene with name "Playber"
        shootpoint = GameObject.Find("shootpoint").transform; //finds the shootpoint on the player.
        //Fist = GameObject.Find("Fist");
        SetUpForJump();
    }

    void SetUpForJump() //calculates the path for the player to take while moving.
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight / Mathf.Pow(timeToApex, 2));
        initialjumpvelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void FireWeapon() //activates the fist for a moment
    {
        player.GetComponent<UIManagement>().LoseEnergy(10);
        Fist.SetActive(true);
        StartCoroutine(HitDelay());
        //Fist.SetActive(false);
    }

    IEnumerator HitDelay() //Sets the fist to false again after the attack
    {
        yield return new WaitForSeconds(1);
        Fist.SetActive(false);
    }

    void FireSplitter() //detects a left click and will fire raycast. switch the player into the enemy if it detects one.
    {
        player.GetComponent<UIManagement>().LoseEnergy(0);
        Ray ray = new Ray(shootpoint.position, transform.forward); //shoots ray out of shootpoint transform.
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Debug.DrawRay(ray.origin, ray.direction * 10);
        Debug.Log(hit.point);
        Debug.Log(hit.collider);
        if (hit.collider != null && hit.collider.gameObject.tag == "Hurty")
        {
            SwapTo(hit); //if you hit an enemy (tagged as Hurty) switch to that enemy
        }
    }

    private void SwapTo(RaycastHit hit) //swaps you to the enemy you hit with splitter
    {
        player.GetComponent<UIManagement>().enabled = false; //deactivates the current UIManagement script.
        hit.collider.gameObject.tag = "Player"; //sets enemy tag to player
        player = hit.collider.gameObject; //sets player object to enemy
        player.GetComponent<UIManagement>().enabled = true; //enables enemy UIManagement
        playercontrol.enabled = false; //disables the current control scheme
        playercontrol = hit.collider.gameObject.GetComponent<EnemyClass>().enemycontrol;  //sets enemy character controller to the player controller.
        playercontrol.enabled = true; //activates the enemy controller (now called playercontrol)


    }

    void onMoveInput(InputAction.CallbackContext ctx) //if the player presses WASD detect which keys they are pressing and set that to the input.
    {
        CurrentInput = ctx.ReadValue<Vector2>();
        CurrentMovement.x = CurrentInput.x;
        CurrentMovement.z = CurrentInput.y;
        CurrentRunMovement.x = CurrentInput.x * RunMultiplier;
        CurrentRunMovement.z = CurrentInput.y * RunMultiplier;
        isMoving = CurrentInput.x != 0 || CurrentInput.y != 0;
    }

    void onRun(InputAction.CallbackContext ctx)//detects if the player uses Shift to run
    {
        isRunPressed = ctx.ReadValueAsButton();
    }

    void onJump(InputAction.CallbackContext ctx) //detects if the player presses the jump button
    {
        isJumpPressed = ctx.ReadValueAsButton();
    }

    void RotatePlayer() //rotates the player model towards the direction they are pressing.
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
    
    void ExecuteJump()
    {
        if (!isJumping && playercontrol.isGrounded && isJumpPressed)
        {
            isJumping = true;
            CurrentMovement.y = initialjumpvelocity;
            CurrentRunMovement.y = initialjumpvelocity;
        }
        else if (!isJumpPressed && isJumping && playercontrol.isGrounded) 
        {
            isJumping = false;
        }
    }


    void activeGravity() //detects if player is "grounded" and gives them gravity appropriately
    {
        if (playercontrol.isGrounded)
        {
            CurrentMovement.y = groundGravity;
            
        }
        else
        {
            //float previousYVelo = CurrentMovement.y;
            //float newYVelocity = CurrentMovement.y - (gravity * Time.deltaTime);
            //float nextYVelocity = (previousYVelo + newYVelocity) * .5f; //variable to ensure player's framerate doesn't effect jump arc.
            CurrentMovement.y += gravity * Time.deltaTime;
            CurrentRunMovement.y += gravity * Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        if (playerInput.CharacterMove.FireWeapon.triggered && player.GetComponent<UIManagement>().Energy >= 10)//detects pressing fireweapon
        {
            FireWeapon();
        }
        if (playerInput.CharacterMove.FireSplitter.triggered && player.GetComponent<UIManagement>().Energy >= 50) //detects splitter
        {
            FireSplitter();
        }
        if (isRunPressed && player.GetComponent<UIManagement>().Energy >= 1) 
        {
            playercontrol.Move(CurrentRunMovement * Time.deltaTime * speed);
            player.GetComponent<UIManagement>().Energy = player.GetComponent<UIManagement>().Energy - 0.1f;
        }
        else
        {
            playercontrol.Move(CurrentMovement * Time.deltaTime * speed);
        }
        
        RotatePlayer();


        activeGravity();
        ExecuteJump();
    }

    void OnEnable()//Activates player controls when you call this function
    {
        playerInput.CharacterMove.Enable();
    }

    void OnDisable() //deactivates player controls when you call this function
    {
        playerInput.CharacterMove.Disable();
    }


}
