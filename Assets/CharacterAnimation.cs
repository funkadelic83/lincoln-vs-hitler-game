using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private AnimatorStateInfo stateInfo;
    private Transform parentTransform;
    private bool rootMotionOn;

    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponentInParent<Rigidbody>();
    }

    private void Start()
    {
        GameManager.Instance.NewRound.AddListener(Play_IdleAnimation);
    }
    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }

    public void Play_IdleAnimation()
    {
        anim.Play(AnimationTags.IDLE_ANIMATION);
 

    }

    public void Punch_1()
    {
        anim.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }

    public void Punch_2()
    {
        anim.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }

    public void Punch_3()
    {
        anim.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }

    public void Kick_1()
    {
        anim.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    public void Kick_2()
    {
        anim.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }

    public void Kick_3()
    {
        anim.SetTrigger(AnimationTags.KICK_3_TRIGGER);
    }

    public void Death()
    {
        anim.SetBool(AnimationTags.DEATH_TRIGGER, true);
    }

    private void OnAnimatorMove()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsTag("Death"))
        {
            anim.ApplyBuiltinRootMotion();
            rootMotionOn = true;

        } else if (!stateInfo.IsTag("Death") && rootMotionOn)
        {
            rootMotionOn = false;
            transform.position = transform.parent.position;
            transform.rotation = transform.parent.rotation;
        }
    }


    public void KnockDown()
    {
        anim.SetTrigger(AnimationTags.KNOCKDOWN_TRIGGER);
    }

    public void Hit()
    {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void SpecialMove1Attacker()
    {
        anim.SetTrigger(AnimationTags.SPECIAL_MOVE_1_TRIGGER);
    }

    public void SpecialMove1Victim()
    {
        anim.SetTrigger(AnimationTags.SPECIAL_MOVE_1_VICTIM);
    }

    public void VictoryDance()
    {
        anim.SetTrigger(AnimationTags.VICTORY_DANCE);
    }

    public void HandleUngrounded()
    {
        anim.SetBool("isGrounded", false);
        anim.SetFloat("velocityY", 1 * Mathf.Sign(rb.velocity.y));
    }

    public void HandleGrounded()
    {
        anim.SetBool("isGrounded", true);
        anim.SetFloat("velocityY", 0);
    }

    public void EnemyAttack(int attack)
    {
    if(attack == 0)
        {
            anim.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
        }

    if(attack == 1)
        {
            anim.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
        }

    if(attack == 2)
        {
            anim.SetTrigger(AnimationTags.ATTACK_3_TRIGGER); ;
        }
    }

    //public void Jump()
    //{
    //    anim.SetTrigger(AnimationTags.JUMP_ANIMATION);
    //}

    //public void Land()
    //{
    //    anim.SetTrigger(AnimationTags.LAND_ANIMATION);
    //}
}


