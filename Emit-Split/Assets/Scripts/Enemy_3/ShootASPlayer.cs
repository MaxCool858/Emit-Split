using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootASPlayer : MonoBehaviour
{

    public GameObject Bullet_Emitter;

    public GameObject Bullet;

    public float ForceAmount = 10.0f;


    NotStupid playerInput;
    Vector2 CurrentInput;//recieves player inputs
    Vector3 CurrentMovement;//coords where you want the player to move
    Vector3 CurrentRunMovement;
    //float RunMultiplier = 2.0f;
    public float smoothTurnTime = 0.1f;
    private float turnSmoothVelocity;
    bool isMoving; //detects button presses
    bool isRunPressed; //detects running
    bool isGliding;
    //float rotationPerFrame = 1.0f; //rotation speed of player
    int speed = 5; //player speed

    //public float angleForMove;

    public Transform cam;

    public GameObject CameraTarget;

    GameObject OriginPlayer; //always set to player's model

    CharacterController OriginController; //always set to player's controller

    PlayerInput InputMaps;

    public Transform shootpoint;//where the splitter raycast is launched from

    public GameObject player; //the player's current object

    public CharacterController playercontrol; //character controller attached to current "player"

    //variables for the jump
    bool isJumpPressed = false;
    float initialjumpvelocity;
    float maxJumpHeight = 0.01f;
    float maxJumpTime = 0.5f;
    bool isJumping = false;
    public Vector2 turn;


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

        //Cursor.lockState = CursorLockMode.Locked;

        playercontrol = GetComponent<CharacterController>(); //Sets player control to this script's character controller
        //playerInput.CharacterMove.Move.started += onMoveInput; //if the player is pressing WASD move them using onMoveInput
        //playerInput.CharacterMove.Move.canceled += onMoveInput; //same
        //playerInput.CharacterMove.Move.performed += onMoveInput; //same
        //playerInput.CharacterMove.Run.started += onRun;
       // playerInput.CharacterMove.Run.canceled += onRun;
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
       //    SetUpForJump();
    }
    // Update is called once per frame
    void Update()
    {

        //RotatePlayer();
        //Debug.Log(velocity);
        //onMoveInput();

        turn.x += Input.GetAxis("Mouse X");

        turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        if (playerInput.CharacterMove.FireWeapon.triggered && OriginPlayer.GetComponent<UIManagement>().Energy >= 10)//detects pressing fireweapon
        {
            ShootPlayer();
        }
        if (playerInput.CharacterMove.ReturntoOrigin.triggered && OriginPlayer.GetComponent<UIManagement>().Energy >= 0) //detects splitter
        {
            OriginReturn();
        }
        if (playerInput.CharacterMove.Interact.triggered && OriginPlayer.GetComponent<UIManagement>().LeverText2.activeInHierarchy) //detects splitter
        {
            OriginPlayer.GetComponent<UIManagement>().ActivateLever2();
        }
        if (playerInput.CharacterMove.Jump.triggered && isGrounded)
        {
            velocity.y = Mathf.Sqrt(maxJumpHeight * -2f * gravity);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <= 0)
        {
            velocity.y += groundGravity;
        }


        if (isRunPressed && OriginPlayer.GetComponent<UIManagement>().Energy >= 0.2)
        {
            isGliding = true;

        }
        else
        {
            isGliding = false;
            playercontrol.Move(CurrentMovement * Time.deltaTime * speed);
        }
        if (isGliding)
        {
            OriginPlayer.GetComponent<UIManagement>().Energy = OriginPlayer.GetComponent<UIManagement>().Energy - 0.1f;
            playercontrol.Move(CurrentMovement * Time.deltaTime * speed);
            velocity.y = -0.0001f;
        }
        if (!isGrounded && !isGliding)
        {
            velocity.y += gravity * Time.deltaTime;
        }


        playercontrol.Move(velocity);


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
    void FireSplitter()
    {

        ShootPlayer();
    }

    void OriginReturn()
    {
        OriginPlayer.GetComponent<UIManagement>().HideTutorial();
        playercontrol.enabled = false;
        player.tag = "Hurty";
        OriginController.enabled = true;
        CameraTarget.GetComponent<CameraFollow>().p1 = player.transform;
        CameraTarget.GetComponent<CameraFollow>().p2 = OriginPlayer.transform;
        CameraTarget.GetComponent<CameraFollow>().Transition();
        CameraTarget.GetComponent<CameraFollow>().player = OriginPlayer;
        this.GetComponent<Movee>().enabled = true;
        this.GetComponent<Movee>().player = OriginPlayer;
        this.GetComponent<Movee>().playercontrol = OriginController;

        this.GetComponent<Enemy2Movee>().enabled = false;
    }


    void OnEnable()//Activates player controls when you call this function
    {
        playerInput.CharacterMove.Enable();
        player = OriginPlayer;
        playercontrol = OriginController;
    }

    //shoots player 
    private void ShootPlayer()
    {



        GameObject Temporary_Buller_Handler;


        Temporary_Buller_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);

        Temporary_Buller_Handler.transform.Rotate(Vector3.left * 90);


        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Buller_Handler.GetComponent<Rigidbody>();


        Temporary_RigidBody.AddForce(transform.forward * ForceAmount);

        Destroy(Temporary_Buller_Handler, 10.0f);



    }

    //delay after every shot
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3);
    }

    /*
    void onRun(InputAction.CallbackContext ctx)//detects if the player uses Shift to run
    {
        isRunPressed = ctx.ReadValueAsButton();
    }

    */
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

}
