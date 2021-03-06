using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;
    private bool characterDied;
    public bool is_Player;
    private HealthUI health_UI;

    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
        health_UI = GetComponent<HealthUI>();
        enemyMovement = GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        GameManager.Instance.NewRound.AddListener(ResetHealth);
    }

    public void ResetHealth()
    {
        health = 100f;
        health_UI.DisplayHealth(health);
        characterDied = false;
    }

    public void ApplyDamage (float damage, string whichSide)
    {
        if (characterDied)
        {
            return;
        }

        health -= damage;
        health_UI.DisplayHealth(health);

        if (health <= 0f)
        {
            animationScript.Death();
            //enemyMovement.enabled = false;
            characterDied = true;
            if(is_Player)
            {
                GameManager.Instance.EndRound(false);
            }
            if(!is_Player)
            {
                GameManager.Instance.EndRound(true);
            }

            return;
        }

        if (whichSide == "rightSide")
        {
            animationScript.GetHitRight();
        }

        if (whichSide == "leftSide")
        {
            animationScript.GetHitLeft();
        }




        if (!is_Player)
        {
            if(whichSide == "rightSide")
            {
                animationScript.GetHitRight();
            }
            
            if(whichSide == "leftSide")
            {
                animationScript.GetHitLeft();
            }
        }

    }
}
