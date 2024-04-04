using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsGame : MonoBehaviour
{
    public GameObject[] otherObjectsToToggle; // Array to hold references to other objects to toggle
    public bool toggleState = true; // Initial toggle state

    void Start()
    {
        // Set the initial state of the GameObject
        gameObject.SetActive(toggleState);
    }

    void Update()
    {
        // Toggle the boolean variable of this GameObject
        if (Input.GetMouseButtonDown(0)) // Check for right mouse button click
        {
            toggleState = !toggleState;
            gameObject.SetActive(toggleState);

            // Toggle the boolean variable of another random GameObject
            ToggleRandomObject();
        }
    }

    void ToggleRandomObject()
    {
        // Choose a random object from the array of other objects
        int randomIndex = Random.Range(0, otherObjectsToToggle.Length);
        GameObject objectToToggle = otherObjectsToToggle[randomIndex];

        // Toggle the boolean variable of the chosen object
        LightsGame otherToggleScript = objectToToggle.GetComponent<LightsGame>();
        if (otherToggleScript != null)
        {
            otherToggleScript.toggleState = !otherToggleScript.toggleState;
            objectToToggle.SetActive(otherToggleScript.toggleState);
        }
    }
}
