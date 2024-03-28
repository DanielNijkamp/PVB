using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pressurePlate : MonoBehaviour 
{
    private int objectsOnPlate = 0;
    private Timer timer;
    public int buttonValue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public UnityEvent<int> onActivate => throw new System.NotImplementedException();
    private void Start()
    {
        // Find the GameObject with the Timer script and get its Timer component
        timer = FindObjectOfType<Timer>();
        UpdateDisplay();
    }
    public void Check()
    {
        if (objectsOnPlate == 0 && timer.RemainingTime <= 0)
        {
            GameOver();
        }
        else if (objectsOnPlate == 1)
        {
            GameWin();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is tagged as an object that activates the plate
        if (other.CompareTag("PressurePlateActivator"))
        {
            objectsOnPlate++;
            UpdateDisplay();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is tagged as an object that activates the plate
        if (other.CompareTag("PressurePlateActivator"))
        {
            objectsOnPlate--;
            UpdateDisplay();
        }
    }
    private void UpdateDisplay()
    {
        // Here you can implement the code to display the number of objects on the plate
        Debug.Log("Objects on the pressure plate: " + objectsOnPlate);
        Debug.Log("Remaining time: " + timer.RemainingTime);
    }
    void GameOver()
    {
        Debug.Log("Game over");
    }
    void GameWin()
    {
        Debug.Log("game won");
    }
}
