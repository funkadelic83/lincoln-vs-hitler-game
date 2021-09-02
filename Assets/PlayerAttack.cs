using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2,
    KICK_3
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private bool activateTimerToReset;
    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;
    private ComboState current_ComboState;

    private void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_ComboState = ComboState.NONE;
    }

    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Fire1"))
        {
            if (current_ComboState == ComboState.PUNCH_3 ||
                current_ComboState == ComboState.KICK_1 ||
                current_ComboState == ComboState.KICK_2 ||
                current_ComboState == ComboState.KICK_3)
                return;
            current_ComboState++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_ComboState == ComboState.PUNCH_1)
            {
                player_Anim.Punch_1();
            }

            if(current_ComboState == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }

            if(current_ComboState == ComboState.PUNCH_3)
            {
                player_Anim.Punch_3();
            }
        }
        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire2"))
        {
            if (
                current_ComboState == ComboState.PUNCH_3 ||
                current_ComboState == ComboState.KICK_3
                )
                return;
            if (current_ComboState == ComboState.NONE ||
                current_ComboState == ComboState.PUNCH_1 ||
                current_ComboState == ComboState.PUNCH_2
                )
            {
                current_ComboState = ComboState.KICK_1;
            } else if (current_ComboState == ComboState.KICK_1)
            {
                current_ComboState++;
            }
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;
            if (current_ComboState == ComboState.KICK_1)
            {
                player_Anim.Kick_1();
            }
            if (current_ComboState == ComboState.KICK_2)
            {
                player_Anim.Kick_2();
            }
            if (current_ComboState == ComboState.KICK_3)
            {
                player_Anim.Kick_3();
            }
        }

        //TEMPORARY TEST - NEEDS BETTER KEY COMBO TRIGGER
        if (Input.GetKeyDown(KeyCode.C))
        {

            player_Anim.SpecialMove1Attacker();
        }
    }

    void ResetComboState()
    {
        if(activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;
            if(current_Combo_Timer <= 0f)
            {
                current_ComboState = ComboState.NONE;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
}
