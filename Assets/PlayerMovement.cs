using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterAnimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;
    public float jumpThrust = 3f;
    public float velocityY = 0f;

    private float rotation_Y = 0f;
    private float rotation_Speed = 15f;
    private float feetDist = 0.1f;


    public bool isGrounded;


    // Start is called before the first frame update

    private void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();


    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
        HandleAnimations();
        HandleInput();

    }

    private void FixedUpdate()
    {
        DetectMovement();
        DetectGround();
    }

    void DetectGround()
    {
        if(Physics.Raycast(transform.position, Vector3.down, feetDist))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
    }

    void HandleAnimations()
    {
        if(!isGrounded)
        {
            player_Anim.HandleUngrounded();
        }

        if(isGrounded)
        {
            player_Anim.HandleGrounded();

        }
    }





    void Jump()
    {
        if(isGrounded)
        {
            myBody.AddForce(transform.up * jumpThrust, ForceMode.Impulse);
        } else
        {
            return;
        }

    }

    void DetectMovement()
    {
        myBody.velocity = new Vector3(
            //Input.GetAxisRaw(Axis.VERTICAL_AXIS) * -z_Speed, 
            0f,
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * walk_Speed); ;
   
    }




    void RotatePlayer()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0 )
        {
            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);
        } else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0 ){
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 
            //||
            //Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0 
            )
        {
            player_Anim.Walk(true);
        } else
        {
            player_Anim.Walk(false);
        }


    }
}
