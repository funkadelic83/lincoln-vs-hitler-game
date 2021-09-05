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
    public GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animationScript = GetComponentInChildren<CharacterAnimation>();
        health_UI = GetComponent<HealthUI>();
        enemyMovement = GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        GameManager.Instance.NewRound.AddListener(ResetHealth);
    }

    public void ResetHealth(bool isPlayerWinner)
    {
        health = 100f;
        health_UI.DisplayHealth(health);
    }
    public void ApplyDamage (float damage, bool knockDown)
    {
        if(characterDied)
        {
            return;
        }

        health -= damage;
        health_UI.DisplayHealth(health);


        if (health <= 0f)
        {
            animationScript.Death();
            enemyMovement.enabled = false;
            characterDied = true;
            if(is_Player)
            {
                //GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<CharacterAnimation>().enabled = false;
                GameManager.Instance.EndRound(false);
            }
            if(!is_Player)
            {
                //GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<CharacterAnimation>().VictoryDance();
                GameManager.Instance.EndRound(true);
            }

            return;
        }


        if(!is_Player)
        {
            if(knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
                else
                {
                    if(Random.Range(0, 3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            }
        }

    }
}
