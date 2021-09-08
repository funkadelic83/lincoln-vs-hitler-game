using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUI : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.NewRound.AddListener(ShowRoundNumber);
        GameManager.Instance.EndGame.AddListener(ShowWinner);
        ShowRoundNumber();
    }

    void ShowRoundNumber()
    {
        statusText.text = "Round " + GameManager.Instance.roundNumber.ToString();
        statusText.enabled = true;
        Invoke("ShowFightText", 2f);
    }

    void ShowFightText()
    {
        statusText.text = "Fight!";
        Invoke("HideStatus", 1f);
    }

    void HideStatus()
    {
        statusText.enabled = false;
    }

    void ShowWinner(string winner)
    {
        statusText.text = winner + " Wins.";
        statusText.enabled = true;
    }

}
