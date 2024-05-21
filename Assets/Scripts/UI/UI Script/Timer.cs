using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeToComplete = 300f;
    private float initialTime;
    void Update()
    {
        if (timeToComplete > 0)
        {
            timeToComplete -= Time.deltaTime;
        }

        if (timeToComplete <= 0)
        {
            timeToComplete = 0;
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(timeToComplete / 60);
        int seconds = Mathf.FloorToInt(timeToComplete % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void TimerReset()
    {
        timeToComplete = 300f;
    }
}
