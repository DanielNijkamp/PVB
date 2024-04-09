using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpotLightDetection : MonoBehaviour
{
    //public UnityEvent shadowFilled;
    private ShapeMatcher shapeMatcher;

    public GameObject shadowObject; // GameObject representing the area where the shadow should be matched
    public float matchThreshold = 0.8f; // Threshold for considering a match
    [SerializeField] GameObject spotLight;
    public float capsuleRadius = 0.8f; // Radius of the capsule cast
    public float capsuleHeight = 4f; // Height of the capsule cast

    private void Start()
    {
        shapeMatcher = GetComponentInChildren<ShapeMatcher>();
    }

    private void Update()
    {
        // Calculate the start and end positions for the capsule cast
        Vector3 start = spotLight.transform.position;
        Vector3 end = start + spotLight.transform.forward * capsuleHeight;

        // Perform the capsule cast
        RaycastHit[] hits = Physics.CapsuleCastAll(start, end, capsuleRadius, spotLight.transform.forward);

        // Iterate through all hits
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("PuzzlePiece"))
            {
                Debug.Log("Puzzle piece detected: " + hit.collider.gameObject.name);
            }
            else if (hit.collider.CompareTag("ShadowObject"))
            {
                if (shapeMatcher != null && shapeMatcher.shadowFilled)
                {
                    // Perform actions when shadow is filled
                    shapeMatcher.shadowFilled = false;
                    Debug.Log("Shadow is filled" + shapeMatcher.shadowFilled);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject entering the trigger is the one you want to detect.
        if (other.CompareTag("PuzzlePiece")) // Change "YourTag" to the tag of the object you want to detect.
        {
            // Perform actions when the object passes through the spotlight.
            Debug.Log("Puzzle Piece detected in spotlight: " + other.gameObject.name);

            // Example: Change the color of the object.
            Renderer renderer = other.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
        }
    }
}