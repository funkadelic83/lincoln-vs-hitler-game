using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : Singleton<TimeUI>
{
    public TextMeshProUGUI time_UI;
    public float timeRemaining;
    private GameObject player;
    private GameObject enemy;
    public bool combatActive;
    public float freezeBetweenRoundsDuration = 2f;

    public Events.UnfreezeCharactersEvent UnfreezeCharacters;

    void Start()
    {
        combatActive = false;
        enemy = GameObject.FindWithTag(Tags.ENEMY_TAG);
        player = GameObject.FindWithTag(Tags.PLAYER_TAG);
        timeRemaining = 60f;
        time_UI.text = timeRemaining.ToString();
        GameManager.Instance.NewRound.AddListener(ResetClock);
    }

    IEnumerator CombatDelay()
    {
        yield return new WaitForSeconds(freezeBetweenRoundsDuration);
        UnfreezeCharacters.Invoke();
        combatActive = true;
    }

    void ResetClock()
    {
        timeRemaining = 60f;
        time_UI.text = Mathf.Round(timeRemaining).ToString();
        StartCoroutine("CombatDelay");
    }

    void Update()
    {

        if (combatActive)
        {
        
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
                GameManager.Instance.EndRound(false);
            }
        }

        }
    }
}
