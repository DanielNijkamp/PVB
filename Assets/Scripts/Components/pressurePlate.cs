using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pressurePlate : MonoBehaviour 
{
    private int objectsOnPlate = 0;

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
