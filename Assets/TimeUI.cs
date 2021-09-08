using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI time_UI;
    public float timeRemaining;
    private GameObject player;
    private GameObject enemy;
   // public bool combatActive;

    void Start()
    {
        //combatActive = true;
        enemy = GameObject.FindWithTag(Tags.ENEMY_TAG);
        player = GameObject.FindWithTag(Tags.PLAYER_TAG);
        timeRemaining = 60f;
        time_UI.text = timeRemaining.ToString();
        GameManager.Instance.NewRound.AddListener(ResetClock);
        //GameManager.Instance.NewRound.AddListener(ToggleCombatTimer);
        //GameManager.Instance.EndCurrentRound.AddListener(ToggleCombatTimer);
    }
    void ResetClock()
    {
        timeRemaining = 63f;
    }

    //void ToggleCombatTimer()
    //{
    //    combatActive = !combatActive;
    //    Debug.Log("Combat active is " + combatActive);
    //}
    // Update is called once per frame
    void Update()
    {

        //if(combatActive)
        //{
        timeRemaining -= Time.deltaTime;
        time_UI.text = Mathf.Round(timeRemaining).ToString();

        if(timeRemaining <= 0)
        {
            if (player.GetComponent<HealthScript>().health >
                enemy.GetComponent<HealthScript>().health)
            {
                GameManager.Instance.EndRound(true);
            } else if (
                player.GetComponent<HealthScript>().health <
                enemy.GetComponent<HealthScript>().health)
            {
                GameManager.Instance.EndRound(false);
            } else
            {
                Debug.Log("TIE");
                GameManager.Instance.EndRound(false);
            }
        }

        //}
    }
}
