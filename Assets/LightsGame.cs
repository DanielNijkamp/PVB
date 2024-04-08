using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*TODO: 
 * Prefab met seperate game object voor mesh
 * Seperate input script
 * Deze script aleen method met togglen van zichzelf en andere
 * */
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
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray intersects with any object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object is one of the objects to toggle
                foreach (GameObject obj in otherObjectsToToggle)
                {
                    if (hit.collider.gameObject == obj)
                    {
                        LightsGame otherToggleScript = obj.GetComponent<LightsGame>();
                        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
                        if (otherToggleScript != null)
                        {
                            otherToggleScript.toggleState = !otherToggleScript.toggleState;

                            renderer.enabled = !renderer.enabled;
                            otherToggleScript.toggleState = renderer.enabled;
                        }
                    }
                }
            }
        }
    }
}
