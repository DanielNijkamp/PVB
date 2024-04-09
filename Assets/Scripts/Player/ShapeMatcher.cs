using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMatcher : MonoBehaviour
{
    public GameObject[] puzzlePieces; // Array of puzzle piece game objects
    public bool shadowFilled;
    void Start()
    {
        if (puzzlePieces.Length == 3 && shadowFilled == true)
        {
            PuzzleComplete();
        }
    }

    public void PuzzleComplete()
    {

    }
}

