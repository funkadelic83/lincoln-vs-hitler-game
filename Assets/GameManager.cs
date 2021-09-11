using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    #region Declarations

    public MainMenu mainMenu;
    public Animation _mainMenuAnimator;
    public AnimationClip _fadeOutAnimation;
  

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
    private float secondsBetweenRounds = 3f;

    public TextMeshProUGUI statusText;

    public TimeUI time_UI;

    #endregion

    private void Start()
    {
        _mainMenuAnimator = mainMenu.GetComponent<Animation>();
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

    public void StartGame()
    {

        roundNumber = 1;
        NewRound.Invoke();
    }


    public IEnumerator delayBetweenRounds()
    {
        yield return new WaitForSeconds(secondsBetweenRounds);

        roundNumber++;

        if (playerWins >= 2)
        {
            EndGame.Invoke("Player");
        }
        else if (enemyWins >= 2)
        {
            EndGame.Invoke("Enemy");
        }
        else
        {
            
            NewRound.Invoke();
        }

    }

    public void EndRound(bool isPlayerWinner)
    {
        time_UI.combatActive = false;
        if (isPlayerWinner)
        {
            playerWins++;
        } else if (!isPlayerWinner) {
            enemyWins++;
        }
        StartCoroutine("delayBetweenRounds");
        
    }

}
