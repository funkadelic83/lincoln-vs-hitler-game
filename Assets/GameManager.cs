using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

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
    public Events.DeclareWinner EndGame;

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
    
    public int roundNumber = 1;
    public int playerWins;
    public int enemyWins;
    //private float secondsBetweenRounds = 3f;

    public TextMeshProUGUI statusText;

    #endregion

    private void Start()
    {
        roundNumber = 1;
        NewRound.Invoke(true);
    }

    #region PauseLogic
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

    #endregion

    public void EndRound(bool isPlayerWinner)
    {
        if (isPlayerWinner)
        {
            playerWins++;
        } else if (!isPlayerWinner) {
            enemyWins++;
        }

        roundNumber++;

        if (playerWins >= 2)
        {
            EndGame.Invoke("Player");
        } else if (enemyWins >= 2)
        {
            EndGame.Invoke("Enemy");
        } else
        {

            NewRound.Invoke(isPlayerWinner);
        }

    }

}
