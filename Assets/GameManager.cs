using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region Declarations

    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED
    }

    GameState _currentGameState = GameState.PREGAME;

    public Events.EventGameState OnGameStateChanged;
    public Events.NewRoundEvent newRound;

    public GameState CurrentGameState
    {
        get
        {
            return _currentGameState;
        }
        private set
        {
            _currentGameState = value;
        }
    }

    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            //Debug.Log("Paused");
        }
    }

    private void TogglePause()
    {
        UpdateState(_currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }

    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;
        switch (_currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1f;
                break;
            case GameState.RUNNING:
                Time.timeScale = 1f;
                break;
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
            default:
                break;
        }
        Debug.Log(_currentGameState);
        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
    }

    //public int matchRound;
    //private int playerWins, enemyWins;
    //private GameObject player, enemy;
    //private Transform playerStartPos, enemyStartPos;

    ////THIS IS ALL TIGHTLY COUPLED CODE. IT NEEDS TO BE REDONE.

    //private void Awake()
    //{
    //    player = GameObject.FindWithTag(Tags.PLAYER_TAG);
    //    enemy = GameObject.FindWithTag(Tags.ENEMY_TAG);
    //    playerStartPos = GameObject.Find("PlayerStartPosition").transform;
    //    enemyStartPos = GameObject.Find("EnemyStartPosition").transform;
    //}

    //private void Start()
    //{
    //    matchRound = 0;
    //    playerWins = 0;
    //    enemyWins = 0;
    //    StartRound();
    //    Debug.Log("Let the games begin!");
    //}

    //public void EndRound()
    //{
    //    if (player.GetComponent<HealthScript>().health > enemy.GetComponent<HealthScript>().health)
    //    {
    //        playerWins++;
    //        Debug.Log("Player Wins");
    //    } else if (player.GetComponent<HealthScript>().health < enemy.GetComponent<HealthScript>().health)
    //    {
    //        enemyWins++;
    //        Debug.Log("Enemy Wins");
    //    } else
    //    {
    //        Debug.Log("It's a tie!");
    //    }

    //    if (matchRound < 3)
    //    {
    //        StartRound();
    //    } else if (matchRound >= 3)
    //    {
    //        CallMatch();
    //    }
    //}

    //public void StartRound()
    //{
    //    matchRound++;
    //    player.transform.position = playerStartPos.position;
    //    enemy.transform.position = enemyStartPos.position;
    //    player.GetComponent<HealthScript>().health = 100;
    //    enemy.GetComponent<HealthScript>().health = 100;
    //    Debug.Log("Round " + matchRound + ". Fight!");
    //    player.GetComponentInChildren<CharacterAnimation>().enabled = true;
    //    enemy.GetComponentInChildren<CharacterAnimation>().enabled = true;
    //    //player.GetComponentInChildren<CharacterAnimation>().Play_IdleAnimation;
    //    //enemy.GetComponentInChildren<CharacterAnimation>().Play_IdleAnimation;
    //}

    //public void CallMatch()
    //{
    //    if(playerWins > enemyWins)
    //    {
    //        Debug.Log("Player Wins!");
    //    } else if (enemyWins > playerWins)
    //    {
    //        Debug.Log("Enemy Wins!");
    //    }
    //}


}
