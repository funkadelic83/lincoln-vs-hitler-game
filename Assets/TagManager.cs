using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTags  
{
    public const string MOVEMENT = "Walk";
    public const string IDLE_ANIMATION = "Idle";
    public const string JUMP_ANIMATION = "Jump";
    public const string LAND_ANIMATION = "Land";

    public const string PUNCH_1_TRIGGER = "Punch1";
    public const string PUNCH_2_TRIGGER = "Punch2";
    public const string PUNCH_3_TRIGGER = "Punch3";

    public const string KICK_1_TRIGGER = "Kick1";
    public const string KICK_2_TRIGGER = "Kick2";
    public const string KICK_3_TRIGGER = "Kick3";

    public const string DEATH_TRIGGER = "Death";
    public const string KNOCKDOWN_TRIGGER = "KnockDown";
    public const string HIT_TRIGGER = "Hit";
    public const string SPECIAL_MOVE_1_TRIGGER = "S1Trigger";
    public const string SPECIAL_MOVE_1_VICTIM = "S1Victim";
    public const string VICTORY_DANCE = "VictoryDance";

    public const string ATTACK_1_TRIGGER = "Punch1";
    public const string ATTACK_2_TRIGGER = "Kick2";
    public const string ATTACK_3_TRIGGER = "Kick3";
}

public class Axis
{
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class Tags
{
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string HEALTH_UI = "HealthUI";
    public const string ENEMY_HEALTH_UI = "EnemyHealthUI";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string LEFT_ARM_TAG = "LeftArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string RIGHT_ARM_TAG = "RightArm";
    public const string RIGHT_LEG_TAG = "RightLeg";
    public const string UNTAGGED_TAG = "Untagged";
}