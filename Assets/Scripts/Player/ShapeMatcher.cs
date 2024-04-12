using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMatcher : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public bool shadowFilled;
    public bool puzzlePiecesComplete;
    void Update()
    {
        if (shadowFilled == true && puzzlePiecesComplete == true)
        {
            PuzzleComplete();
        }
        else
        {
            shadowFilled = false;
            Debug.Log("shadow not filled");
        }
    }
    public void FreezeMovement()
    {
        foreach (GameObject piece in puzzlePieces)
        {
            Rigidbody rigidbody = piece.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezePositionX |
                                         RigidbodyConstraints.FreezePositionY |
                                         RigidbodyConstraints.FreezePositionZ;
            }
        }
    }
    public void PuzzleComplete()
    {
        FreezeMovement();
        Debug.Log("Puzzle complete! Congrats!");
    }
}