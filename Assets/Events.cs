using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class NewRoundEvent : UnityEvent { };

    [System.Serializable] public class StartGameEvent : UnityEvent { };

    [System.Serializable] public class PlaySfx : UnityEvent<string> { };

    [System.Serializable] public class FreezeCombatEvent : UnityEvent { };

    [System.Serializable] public class UnfreezeCharactersEvent : UnityEvent { };

    [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { };
    [System.Serializable] public class EndRoundEvent : UnityEvent<bool> { };
    [System.Serializable] public class DeclareWinner : UnityEvent<string> { };
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { };
}
