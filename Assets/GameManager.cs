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
    public Events.NewRoundEvent NewRound;

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
    
    public int roundNumber;
    public int playerWins;
    public int enemyWins;

    #endregion

    private void Start()
    {
        roundNumber = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
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

    public void EndRound(bool isPlayerWinner)
    {
        Debug.Log("End Round. Player wins =" + isPlayerWinner);

        if (isPlayerWinner)
        {
            playerWins++;
        } else if (!isPlayerWinner) {
            enemyWins++;
        }

        roundNumber++;

        if (playerWins >= 2)
        {
            Debug.Log("the game is over. player wins!");
        } else if (enemyWins >= 2)
        {
            Debug.Log("the enemy wins. game over!");
        } else
        {
            NewRound.Invoke(isPlayerWinner);
        }


    }



}
