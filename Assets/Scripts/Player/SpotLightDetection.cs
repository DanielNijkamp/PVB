using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class SpotLightDetection : MonoBehaviour
{
    public ShapeMatcher shapeMatcher;
    public ShapeMatcher[] puzzlePieces;

    [SerializeField] GameObject puzzlePiece;
    [SerializeField] GameObject shadowPlace;
    [SerializeField] float matchThreshold = 0.8f;
    [SerializeField] GameObject spotLight;
    [SerializeField] float capsuleRadius = 0.8f;
    [SerializeField] float capsuleHeight = 4f;

    private void Start()
    {
        GameObject shapeMatchCheck = GameObject.Find("shapeMatchCheck");
    }

    private void Update()
    {
        if (shapeMatcher == null)
        {
            return;
        }
        Vector3 start = spotLight.transform.position;
        Vector3 end = start + spotLight.transform.forward * capsuleHeight;
        bool isHit = Physics.CapsuleCast(start, end, capsuleRadius, spotLight.transform.forward, out RaycastHit hit);

        if (isHit)
        {
            if (hit.collider.CompareTag("ShadowObject"))
            {
                Debug.Log("Shadow object detected means shadow not filled: " + hit.collider.gameObject.name);
                shapeMatcher.shadowFilled = false;
            }
            else
            {
                Debug.Log("Shadow object not detected means shadow filled: " + hit.collider.gameObject.name);
                shapeMatcher.shadowFilled = true;
            }
        }
        if (shapeMatcher != null && shapeMatcher.shadowFilled == false)
        {
            Debug.Log("Shadow is not filled");
            ShadowCheck();
        }
        else
        {
            shapeMatcher.shadowFilled = true;
        }
    }
    private void ShadowCheck()
    {
        if (puzzlePieces.Length == 3)
        {
            Debug.Log("Puzzle pieces complete");
            shapeMatcher.puzzlePiecesComplete = true;
        }
        else
        {
            Debug.Log("Puzzle pieces not complete");
            shapeMatcher.puzzlePiecesComplete = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("puzzlePiece"))
        {
            Debug.Log("ALL PUZZLE PIECES DETECTED: " + other.gameObject.name);
        }
    }
}