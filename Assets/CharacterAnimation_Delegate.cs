using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation_Delegate : MonoBehaviour
{
    public GameObject left_Arm_Attack_Point, right_Arm_Attack_Point, left_Leg_Attack_Point, right_Leg_Attack_Point;

    private CharacterAnimation animationScript;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whoosh_Sound, fall_Sound, ground_Hit_Sound, dead_Sound;

    private EnemyMovement enemy_Movement;

    private ShakeCamera shakeCamera;

    // Start is called before the first frame update
    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();
        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
    
        if(gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemy_Movement = GetComponentInParent<EnemyMovement>();
        }
    }

    void Left_Arm_Attack_On()
    {
        if (!left_Arm_Attack_Point.activeInHierarchy)
        {
            left_Arm_Attack_Point.SetActive(true);
        }
    }

    void Left_Leg_Attack_On()
    {
        if(!left_Leg_Attack_Point.activeInHierarchy)
        {
            Debug.Log("Left Leg Attack Point Activated");
            left_Leg_Attack_Point.SetActive(true);
        }
    }

    void right_Arm_Attack_On()
    {
        if(!right_Arm_Attack_Point.activeInHierarchy)
        {
        right_Arm_Attack_Point.SetActive(true);

        }
    }

    void right_Leg_Attack_On()
    {
        if(!right_Leg_Attack_Point.activeInHierarchy) 
        {
        right_Leg_Attack_Point.SetActive(true);

        }
    }

    void Left_Arm_Attack_Off()
    {
        if(left_Arm_Attack_Point.activeInHierarchy)
        {
        left_Arm_Attack_Point.SetActive(false);

        }
    }

    void Left_Leg_Attack_Off()
    {
        if (left_Arm_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    }

    void right_Arm_Attack_Off()
    {
        if (right_Arm_Attack_Point.activeInHierarchy)
        {
            right_Arm_Attack_Point.SetActive(false);
        }
    }

    void right_Leg_Attack_Off()
    {
        if (right_Leg_Attack_Point.activeInHierarchy)
        {
            right_Leg_Attack_Point.SetActive(false);
        }
    }

    void tag_Right_Arm()
    {
        right_Arm_Attack_Point.tag = Tags.RIGHT_ARM_TAG;
    }

    void untag_Right_Arm()
    {
        right_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void tag_Right_Leg()
    {
        right_Leg_Attack_Point.tag = Tags.RIGHT_LEG_TAG;
    }

    void untag_Right_Leg()
    {
        right_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void tag_Left_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }

    void untag_Left_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void tag_Left_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.LEFT_LEG_TAG;
    }

    void untag_Left_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    //void faceEnemy()
    //{
    //    lookVector = playerTarget
    //    Quaternion rot = Quaternion.LookRotation(transform.rotation, rot, 1);
    //}

    //FACE ENEMY AFTER LANDING
    //Use RotateTowards or LookAt to face the enemy after attacking
    //Call this function using an animation event


}
