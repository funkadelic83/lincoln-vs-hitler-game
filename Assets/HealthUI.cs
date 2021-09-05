using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image health_UI;
    public bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
        health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
        } else
        {
            health_UI = GameObject.FindWithTag(Tags.ENEMY_HEALTH_UI).GetComponent<Image>();
        }

    }

    public void DisplayHealth(float value)
    {
        value /= 100f;
        if (value < 0f)
        {
            value = 0f;
        }

        health_UI.fillAmount = value;
    }
}
