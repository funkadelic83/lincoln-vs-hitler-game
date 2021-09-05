using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI time_UI;
    public float timeRemaining;
    void Start()
    {
        timeRemaining = 60f;
        time_UI.text = timeRemaining.ToString();
        GameManager.Instance.NewRound.AddListener(ResetClock);
    }

    void ResetClock(bool isPlayerWinner)
    {
        timeRemaining = 60f;
    }
    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        time_UI.text = Mathf.Round(timeRemaining).ToString();

        // if time is zero, reset;
    }
}
