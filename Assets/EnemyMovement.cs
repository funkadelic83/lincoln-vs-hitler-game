using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;
    public float speed = 1.8f;
    private Transform playerTarget;
    private GameObject startPosition;
    public float attack_Distance = 1.3f;
    private float chase_Player_After_Attack = 1f;
    private float current_Attack_Time;
    private float default_Attack_Time = 2f;
    private float freezeBetweenRoundDuration = 3f;
    private EnemyMovement enemyMove;
    private Transform parentTransform;


    private bool frozen;
    private bool followPlayer, attackPlayer;
    public GameObject childPrefab;


    private void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
        followPlayer = true;
        enemyMove = GetComponent<EnemyMovement>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
        startPosition = GameObject.Find("EnemyStartPosition");
    }

    private void Start()
    {
        TimeUI.Instance.UnfreezeCharacters.AddListener(UnfreezeEnemyMovement);
        GameManager.Instance.NewRound.AddListener(ResetPosition);
        attackPlayer = false;
        followPlayer = false;
        ResetPosition();
    }

    private void ResetPosition()
    {
        enemyAnim.Play_IdleAnimation();
        enemyAnim.Walk(false);
        attackPlayer = false;

        transform.position = startPosition.transform.position;
        Quaternion rot = Quaternion.Euler(0f, 180f, 0f);
        myBody.MoveRotation(rot);

        gameObject.GetComponent<EnemyMovement>().enabled = false;
    }

 

    void UnfreezeEnemyMovement()
    {
        followPlayer = true;
        attackPlayer = true;
        gameObject.GetComponent<EnemyMovement>().enabled = true;
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void Update()
    {
        
        Attack();
    }

    void FollowTarget()
    {
        if (!followPlayer)
        {
            return;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {

            Vector3 lookVector = playerTarget.position - transform.position;
            lookVector.y = 0;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

            myBody.velocity = transform.forward * speed;

            if (myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }

        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);
            followPlayer = false;
            attackPlayer = true;
        }
    }

    void Attack()
    {
        if (!attackPlayer)
            return;
        current_Attack_Time += Time.deltaTime;

        if (current_Attack_Time > default_Attack_Time)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            current_Attack_Time = 0f;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) >
            attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}