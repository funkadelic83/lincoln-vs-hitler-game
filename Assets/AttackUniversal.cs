﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{

    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy;
    public GameObject hit_FX;

    private void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
    
        if (hit.Length > 0)
        {
            if(is_Player)
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
                //LEFT ARM AND LEG KNOCK THE ENEMY DOWN
                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG)) {
                    Debug.Log(hit[0].name);
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                } else
                {
                    Debug.Log(hit[0].name);
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }
            if(is_Enemy)
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                Debug.Log(hit[0].name);
            }
            gameObject.SetActive(false);
        }
    
    }


}
