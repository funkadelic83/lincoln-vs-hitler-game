using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class NewRoundEvent : UnityEvent { };
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { };
}
