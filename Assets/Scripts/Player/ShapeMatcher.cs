using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShapeMatcher : MonoBehaviour
{
    public PilarCheck[] puzzlePieces;
    public bool puzzlePiecesComplete;
    public bool allPilarsInPlace;
    bool allPuzzlePiecesInPlace = false;
    public PilarCheck pilarCheck;

    void Start()
    {
        pilarCheck = FindObjectOfType<PilarCheck>();
        pilarCheck.pilarInPlace = false;
    }

    void Update()
    {
        if (puzzlePieces.All(x => x.pilarInPlace))
        {
            allPuzzlePiecesInPlace = true;
        }
        if (allPuzzlePiecesInPlace == pilarCheck.pilarInPlace == true)
        {
            allPilarsInPlace = true;
        }
        if (pilarCheck.pilarInPlace == true && allPilarsInPlace == true)
        {
            puzzlePiecesComplete = true;
        }
        if (puzzlePiecesComplete == true)
        {
            PuzzleComplete();
        }
        else
        {
            Debug.Log("puzzle not filled");
        }
    }
    public void PuzzleComplete()
    {
        Debug.Log("Puzzle complete! Congrats!");
    }
}