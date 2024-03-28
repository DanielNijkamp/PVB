using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float RemainingTime;
    private pressurePlate pressurePlate;
    [SerializeField] private UnityEvent onFinish = new UnityEvent();


    private void Start()
    {
        pressurePlate = FindObjectOfType<pressurePlate>();
    }

    void Update()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;

            // Ensure the timer doesn't go below 0
            if (RemainingTime < 0)
                RemainingTime = 0;
        }
        else
        {
            timerText.color = Color.red;
            if (pressurePlate != null)
            onFinish?.Invoke();
        }

        // Calculate minutes and seconds from remaining time
        int minutes = Mathf.FloorToInt(RemainingTime / 60);
        int seconds = Mathf.FloorToInt(RemainingTime % 60);

        // Update the timer text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}