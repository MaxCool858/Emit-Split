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
    float RunMultiplier = 2.0f;
    public float smoothTurnTime = 0.1f;
    private float turnSmoothVelocity;
    bool isMoving; //detects button presses
    bool isRunPressed; //detects running
    //float rotationPerFrame = 1.0f; //rotation speed of player
    int speed = 5; //player speed

    //public float angleForMove;

    public Transform cam;

    public GameObject CameraTarget;

    GameObject OriginPlayer; //always set to player's model

    CharacterController OriginController; //always set to player's controller

    PlayerInput InputMaps;

    public Transform shootpoint;//where the splitter raycast is launched from

    public GameObject Fist;//object with hitbox that works as melee attack

    public GameObject player; //the player's current object

    public CharacterController playercontrol; //character controller attached to current "player"

    //variables for the jump
    bool isJumpPressed = false;
    float initialjumpvelocity;
    float maxJumpHeight = 0.01f;
    float maxJumpTime = 0.5f;
    bool isJumping = false;


    //gravity
    float gravity = -9.8f;
    float groundGravity = -.05f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;


    private void Awake()
    {
        playerInput = new NotStupid(); //creates a unique ControlScheme for this script


        playercontrol = GetComponent<CharacterController>(); //Sets player control to this script's character controller
        //playerInput.CharacterMove.Move.started += onMoveInput; //if the player is pressing WASD move them using onMoveInput
        //playerInput.CharacterMove.Move.canceled += onMoveInput; //same
        //playerInput.CharacterMove.Move.performed += onMoveInput; //same
        playerInput.CharacterMove.Run.started += onRun;
        playerInput.CharacterMove.Run.canceled += onRun;
        //playerInput.CharacterMove.Jump.started += onJump;
        //playerInput.CharacterMove.Jump.canceled += onJump;


        cam = GameObject.Find("Main Camera").GetComponent<Transform>();

        CameraTarget = GameObject.Find("Camera Target");

        //general Player Set-Up
        player = GameObject.Find("Playber"); //sets the player object to an object in the scene with name "Playber"
        shootpoint = GameObject.Find("shootpoint").transform; //finds the shootpoint on the player.
        InputMaps = player.GetComponent<PlayerInput>();
        
        OriginPlayer = player;
        OriginController = playercontrol;
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
        OriginPlayer.GetComponent<UIManagement>().LoseEnergy(10);
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
        OriginPlayer.GetComponent<UIManagement>().LoseEnergy(0);
        Ray ray = new Ray(shootpoint.position, transform.forward); //shoots ray out of shootpoint transform.
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Debug.DrawRay(ray.origin, ray.direction * 10);
        //Debug.Log(hit.point);
        Debug.Log(hit.collider);
        if (hit.collider != null &&  hit.collider.gameObject.tag == "Hurty")
        {
            Debug.Log("EnemyDetected");
            SwapTo(hit); //if you hit an enemy (tagged as Hurty) switch to that enemy
        }
    }

    private void SwapTo(RaycastHit hit) //swaps you to the enemy you hit with splitter
    {
        hit.collider.gameObject.tag = "Player"; //sets enemy tag to player
        player = hit.collider.gameObject; //sets player object to enemy
        playercontrol.enabled = false; //disables the current control scheme
        //playercontrol = hit.collider.gameObject.GetComponent<EnemyClass>().enemycontrol;  //sets enemy character controller to the player controller.
        playercontrol.enabled = true; //activates the enemy controller (now called playercontrol)
        int EnemyType = hit.collider.GetComponent<EnemyClass>().EnemyTypeNum;
        Debug.Log("EnemySwapping");
        if (EnemyType == 2)
        {
            OriginPlayer.GetComponent<UIManagement>().Enemy2Tutorial();
            GameObject tempenemy = hit.collider.gameObject;
            CharacterController tempenemycontrol = hit.collider.gameObject.GetComponent<EnemyClass>().enemycontrol;
            Transform tempgroundcheck = hit.collider.gameObject.GetComponent<EnemyClass>().groundcheck;
            tempenemycontrol.enabled = true;
            playercontrol.enabled = false;
            
            CameraTarget.GetComponent<CameraFollow>().p1 = player.transform;
            CameraTarget.GetComponent<CameraFollow>().p2 = tempenemy.transform;
            CameraTarget.GetComponent<CameraFollow>().Transition();
            CameraTarget.GetComponent<CameraFollow>().player = tempenemy;
            
            this.GetComponent<Enemy2Movee>().enabled = true;
            this.GetComponent<Enemy2Movee>().player = tempenemy;
            this.GetComponent<Enemy2Movee>().playercontrol = tempenemycontrol;
            this.GetComponent<Enemy2Movee>().groundCheck = tempgroundcheck;
            this.GetComponent<Movee>().enabled = false;
        }

        if (EnemyType == 99)
        {
            //OriginPlayer.GetComponent<UIManagement>().Enemy3Tutorial();
            GameObject tempenemy = hit.collider.gameObject;
            CharacterController tempenemycontrol = hit.collider.gameObject.GetComponent<EnemyClass>().enemycontrol;
            Transform tempgroundcheck = hit.collider.gameObject.GetComponent<EnemyClass>().groundcheck;
            tempenemycontrol.enabled = true;
            playercontrol.enabled = false;

           CameraTarget.GetComponent<CameraFollow>().p1 = player.transform;
            CameraTarget.GetComponent<CameraFollow>().p2 = tempenemy.transform;
            CameraTarget.GetComponent<CameraFollow>().Transition();
            CameraTarget.GetComponent<CameraFollow>().player = tempenemy;

            this.GetComponent<Enemy3Movee>().enabled = true;
            this.GetComponent<Enemy3Movee>().player = tempenemy;
            this.GetComponent<Enemy3Movee>().playercontrol = tempenemycontrol;
            this.GetComponent<Enemy3Movee>().groundCheck = tempgroundcheck;
            this.GetComponent<Movee>().enabled = false;
        }


        if (EnemyType == 3)
        {
            //OriginPlayer.GetComponent<UIManagement>().Enemy3Tutorial();
            GameObject tempenemy = hit.collider.gameObject;
            CharacterController tempenemycontrol = hit.collider.gameObject.GetComponent<EnemyClass>().enemycontrol;
            Transform tempgroundcheck = hit.collider.gameObject.GetComponent<EnemyClass>().groundcheck;
            tempenemycontrol.enabled = true;
            playercontrol.enabled = false;

            CameraTarget.GetComponent<CameraFollow>().p1 = player.transform;
            CameraTarget.GetComponent<CameraFollow>().p2 = tempenemy.transform;
            CameraTarget.GetComponent<CameraFollow>().Transition();
            CameraTarget.GetComponent<CameraFollow>().player = tempenemy;

            this.GetComponent<Enemy3Movee>().enabled = true;
            this.GetComponent<Enemy3Movee>().player = tempenemy;
            this.GetComponent<Enemy3Movee>().playercontrol = tempenemycontrol;
            this.GetComponent<Enemy3Movee>().groundCheck = tempgroundcheck;
            this.GetComponent<Movee>().enabled = false;
        }


    }

    void onMoveInput() //if the player presses WASD detect which keys they are pressing and set that to the input.
    {

        CurrentInput = playerInput.CharacterMove.Move.ReadValue<Vector2>();
        //CurrentInput = ctx.ReadValue<Vector2>();
        CurrentMovement.x = CurrentInput.x;
        CurrentMovement.z = CurrentInput.y;

        Vector3 moveVector = new Vector3(CurrentInput.x, 0f, CurrentInput.y).normalized;
        //Vector3 runMoveVector = new Vector3(CurrentInput.x, 0f, CurrentInput.y).normalized;

        if (moveVector.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //float targetRunAngle = Mathf.Atan2(runMoveVector.x, runMoveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            CurrentMovement = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            //CurrentRunMovement = Quaternion.Euler(0f, targetRunAngle, 0f) * Vector3.forward;
            //playercontrol.Move(moveDir * Time.deltaTime * speed);
        }


        isMoving = CurrentInput.x != 0 || CurrentInput.y != 0;

    }

    void onRun(InputAction.CallbackContext ctx)//detects if the player uses Shift to run
    {
        isRunPressed = ctx.ReadValueAsButton();
    }

    void onJump() //detects if the player presses the jump button
    {
        isJumpPressed = true;
    }

    void RotatePlayer() //rotates the player model towards the direction they are pressing.
    {
        //Vector3 PositionFacing;
        //PositionFacing.x = CurrentMovement.x;
        //PositionFacing.y = 0.0f;
        //PositionFacing.z = CurrentMovement.z;
        //Quaternion currentAngle=transform.rotation;
        //if (isMoving)
        //{
        //    Quaternion targetAngle = Quaternion.LookRotation(PositionFacing);
        //    transform.rotation = Quaternion.Slerp(currentAngle, targetAngle, rotationPerFrame*Time.deltaTime*speed);
        //}

        CurrentInput = playerInput.CharacterMove.Move.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3(CurrentInput.x, 0f, CurrentInput.y).normalized;
        if (isMoving)
        {
            float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //float targetRunAngle = Mathf.Atan2(runMoveVector.x, runMoveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //angleForMove = targetAngle;
            //CurrentMovement = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //CurrentRunMovement = Quaternion.Euler(0f, targetRunAngle, 0f) * Vector3.forward;
        }



    }

    
    void ExecuteJump()
    {
        if (!isJumping && isJumpPressed)
        {
            isJumping = true;
            CurrentMovement.y = initialjumpvelocity;
            CurrentRunMovement.y = initialjumpvelocity;
            
        }
        else if (isJumping && playercontrol.isGrounded) 
        {
            isJumping = false;
            isJumpPressed = false;
        }
    }


    void activeGravity() //detects if player is "grounded" and gives them gravity appropriately
    {
        if (playercontrol.isGrounded)
        {
            CurrentMovement.y += groundGravity;

        }
        else
        {
            //float previousYVelo = CurrentMovement.y;
            //float newYVelocity = CurrentMovement.y - (gravity * Time.deltaTime);
            //float nextYVelocity = (previousYVelo + newYVelocity) * .5f; //variable to ensure player's framerate doesn't effect jump arc.

                CurrentMovement.y += gravity * Time.deltaTime;
                CurrentRunMovement.y += gravity * Time.deltaTime;

                //CurrentMovement.y += (gravity * 0.1f) * Time.deltaTime;
        }

        //float Y_Value = CurrentMovement.y;

        //return Y_Value;
    }

    // Update is called once per frame
    void Update()
    {
        //RotatePlayer();
        //Debug.Log(velocity);
        onMoveInput();
        
        

        if (playerInput.CharacterMove.FireWeapon.triggered && OriginPlayer.GetComponent<UIManagement>().Energy >= 10)//detects pressing fireweapon
        {
            FireWeapon();
        }
        if (playerInput.CharacterMove.FireSplitter.triggered && OriginPlayer.GetComponent<UIManagement>().Energy >= 50) //detects splitter
        {
            FireSplitter();
        }
        if (playerInput.CharacterMove.DismissOpening.triggered && OriginPlayer.GetComponent<UIManagement>().Energy >= 50) //detects splitter
        {
            RemoveOpening();
        }
        if (playerInput.CharacterMove.Interact.triggered && OriginPlayer.GetComponent<UIManagement>().DoorText2.activeInHierarchy)
        {
            RevealEnding();
        }
        if (playerInput.CharacterMove.Jump.triggered && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(maxJumpHeight * -2f * gravity);
        }

        if (isRunPressed && OriginPlayer.GetComponent<UIManagement>().Energy >= 0.1)
        {
            playercontrol.Move(CurrentMovement * Time.deltaTime * speed * RunMultiplier);
            OriginPlayer.GetComponent<UIManagement>().Energy = OriginPlayer.GetComponent<UIManagement>().Energy - 0.1f;
        }
        else
        {
            playercontrol.Move(CurrentMovement * Time.deltaTime * speed);
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <= 0)
        {
            velocity.y += groundGravity;
        }
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        
        playercontrol.Move(velocity);

        
    }

    void RemoveOpening()
    {
        OriginPlayer.GetComponent<UIManagement>().Opening.SetActive(false);
    }

    void RevealEnding()
    {
        OriginPlayer.GetComponent<UIManagement>().StartEnding();
    }

    void OnEnable()//Activates player controls when you call this function
    {
        playerInput.CharacterMove.Enable();
        player = OriginPlayer;
        playercontrol = OriginController;
    }

    void OnDisable() //deactivates player controls when you call this function
    {
        playerInput.CharacterMove.Disable();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            OriginController.GetComponent<UIManagement>().AddCoin(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Door")
        {
            OriginController.GetComponent<UIManagement>().DoorTextReveal();
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            OriginController.GetComponent<UIManagement>().DoorTextHide();
        }
    }




}
