using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Declarations
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;
    private GameObject startPosition;
    public GameObject childPrefab;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;
    public float jumpThrust = 3f;
    public float velocityY = 0f;

    private float rotation_Y = 0f;
    //private float rotation_Speed = 15f;
    private float feetDist = 0.1f;

    public bool isGrounded;

    public TimeUI time_UI;
    #endregion


    private void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
        startPosition = GameObject.Find("PlayerStartPosition");
    }

    void Start()
    {
        TimeUI.Instance.UnfreezeCharacters.AddListener(UnfreezePlayerMovement);
        GameManager.Instance.FreezeCharacters.AddListener(FreezePlayerMovement);
        GameManager.Instance.NewRound.AddListener(ResetPlayerPos);
        ResetPlayerPos();
    }
    
    private void ResetPlayerPos()
    {
        childPrefab.transform.position = transform.position;
        childPrefab.transform.rotation = transform.rotation;
        player_Anim.Play_IdleAnimation();
        player_Anim.Walk(false);

        transform.position = startPosition.transform.position;
        Quaternion rot = Quaternion.Euler(0f, rotation_Y, 0f);
        myBody.MoveRotation(rot);

        isGrounded = true;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerAttack>().enabled = false;
    }

    private void FreezePlayerMovement()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerAttack>().enabled = false;

    }

    private void UnfreezePlayerMovement()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<PlayerAttack>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
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