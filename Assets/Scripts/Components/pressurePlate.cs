using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pressurePlate : MonoBehaviour ,Ibutton<int>
{
    private int objectsOnPlate = 0;

    public int buttonValue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public UnityEvent<int> onActivate => throw new System.NotImplementedException();

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
    }
}
