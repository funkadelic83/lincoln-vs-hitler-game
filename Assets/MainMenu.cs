using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public Events.EventFadeComplete OnMainMenuFadeComplete;
    [SerializeField] private Animation _mainMenuAnimation;
    [SerializeField] private AnimationClip _fadeOutAnimation;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        GameManager.Instance.StartGameNow.AddListener(FadeOut);
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            FadeOut();
        } 
        
        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.PREGAME)
        {
            FadeIn();
        }
    }

    public void FadeIn()
    {
        // fade in the animator
    }

    public void FadeOut()
    {
        Debug.Log("Fade out was called");
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _fadeOutAnimation;
        _mainMenuAnimation.Play();
    }

    public void OnFadeInComplete()
    {
        
        OnMainMenuFadeComplete.Invoke(false);
        UI_Manager.Instance.SetDummyCameraActive(true);

    }

    public void OnFadeOutComplete()
    {
        OnMainMenuFadeComplete.Invoke(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
