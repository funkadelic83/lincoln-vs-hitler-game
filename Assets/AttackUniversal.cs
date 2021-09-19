using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{

    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy, attackMissed;
    public GameObject hit_FX;

    private void FixedUpdate()
    {
        DetectCollision();
    }

    public Events.PlaySfx PlaySound;

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length == 0)
        {
            attackMissed = true;
        }
    
        if (hit.Length > 0)
        {
            attackMissed = false;
            PlaySound.Invoke(SfxTags.HIT_SFX);

            if (is_Player)
            {

                //Vector3 hitFX_Pos = hit[0].transform.position;
                //hitFX_Pos.y += 1.3f;
                //if(hit[0].transform.forward.x > 0)
                //{
                //    hitFX_Pos.x += 0.3f;
                //} else if (hit[0].transform.forward.x < 0)
                //{
                //    hitFX_Pos.x -= 0.3f;
                //}
                //Instantiate(hit_FX, hitFX_Pos, Quaternion.identity);

                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].gameObject.GetComponent<HealthScript>().ApplyDamage(damage, "leftSide");
                }
                
                if (gameObject.CompareTag(Tags.RIGHT_ARM_TAG) || gameObject.CompareTag(Tags.RIGHT_LEG_TAG))
                {
                    hit[0].gameObject.GetComponent<HealthScript>().ApplyDamage(damage, "rightSide");
                }

                gameObject.SetActive(false);
            } 
            
            if(is_Enemy)
            {

                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, "leftSide");

                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(2f * damage, "rightSide");
                }

                gameObject.SetActive(false);

            } 

        }




    }

    private void OnDisable()
    {
        if (attackMissed)
        {
            PlaySound.Invoke(SfxTags.WHOOSH_SFX);
        }
    }

}
