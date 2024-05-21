using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeToComplete = 300f;
    private float initialTime;
    [SerializeField] private UnityEvent sceneSwitcher = new UnityEvent();
    void Update()
    {
        if (timeToComplete > 0)
        {
            timeToComplete -= Time.deltaTime;
        }

        if (timeToComplete <= 0 && timeToComplete != -1)
        {
            timeToComplete = 0;
            timerText.color = Color.red;
            StartCoroutine(InvokeSceneSwitcherWithDelay(0.1f));
            timeToComplete = -1;
        }

        int minutes = Mathf.FloorToInt(timeToComplete / 60);
        int seconds = Mathf.FloorToInt(timeToComplete % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator InvokeSceneSwitcherWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        sceneSwitcher?.Invoke();
    }

    public void TimerReset()
    {
        timeToComplete = 300f;
        timerText.color = Color.white;
    }
}
