using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Declarations
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;
    //public Transform startPOS;
    //public GameObject enemy;
    public GameObject childPrefab;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;
    public float jumpThrust = 3f;
    public float velocityY = 0f;

    private float rotation_Y = 0f;
    private float rotation_Speed = 15f;
    private float feetDist = 0.1f;

    public bool isGrounded;
    #endregion

    // Start is called before the first frame update

    private void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

    }

    void Start()
    {
        //USE IF NEEDED
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        //KEEP THE CHILD PREFAB FROM DRIFTING;
        childPrefab.transform.position = gameObject.transform.position;
        childPrefab.transform.rotation = gameObject.transform.rotation;
      
        AnimatePlayerWalk();
        HandleAnimations();
        HandleInput();
    }

    private void FixedUpdate()
    {
        DetectMovement();
        DetectGround();

        RotatePlayer();
    }

    private void DetectGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, feetDist))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void HandleAnimations()
    {
        if (!isGrounded)
        {
            player_Anim.HandleUngrounded();
        }

        if (isGrounded)
        {
            player_Anim.HandleGrounded();
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            myBody.AddForce(transform.up * jumpThrust, ForceMode.Impulse);
        }
        else
        {
            return;
        }

    }

    void DetectMovement()
    {
        Vector3 m_Input = new Vector3(
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * -1,
            0,
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS));
        myBody.MovePosition(transform.position + m_Input * Time.deltaTime * walk_Speed);

        //OLD PHYSICS (POTENTIALLY CAUSED COLLIDER TO DRIFT:
        //myBody.velocity = new Vector3(
        //    Input.GetAxisRaw(Axis.VERTICAL_AXIS) * -z_Speed, 
        //    //0f,
        //    myBody.velocity.y,
        //    Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * walk_Speed); ;

    }

    void RotatePlayer()
    {

        //ROTATES THE PLAYER TO FACE LEFT OR RIGHT DEPENDING ON INPUT
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            //IF PLAYER IS FACING THE OTHER WAY:
            Quaternion rot = Quaternion.Euler(0f, rotation_Y, 0f);
            myBody.MoveRotation(rot);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            Quaternion rot = Quaternion.Euler(0f, 180f, 0f);
            myBody.MoveRotation(rot);

            //transform.rotation = Quaternion.Euler(0f, -rotation_Y, 0f);
        }
    }

    void AnimatePlayerWalk()
    {

        //ANIMATES THE PLAYER'S WALK IF MOVEMENT BUTTON PRESSED
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0
            ||
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0
            )
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }


    }
}