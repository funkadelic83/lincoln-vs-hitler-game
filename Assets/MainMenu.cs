using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public Events.EventFadeComplete OnMainMenuFadeComplete;
    [SerializeField] private Animation _mainMenuAnimation;
    [SerializeField] private AnimationClip _fadeOutAnimation;
    [SerializeField] private GameObject button;
    void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        GameManager.Instance.StartGameNow.AddListener(FadeOut);
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            //FadeOut();
        } 
        
        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.PREGAME)
        {
            //FadeIn();
        }
    }

    public void FadeIn()
    {

    }

    public void FadeOut()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _fadeOutAnimation;
        _mainMenuAnimation.Play();
    }

    public void OnFadeInComplete()
    {
        //button.GetComponent<Button>().interactable = false;
        OnMainMenuFadeComplete.Invoke(false);
        UI_Manager.Instance.SetDummyCameraActive(true);
    }

    public void OnFadeOutComplete()
    {
        //button.SetActive(false);
        OnMainMenuFadeComplete.Invoke(true);
    }
}
