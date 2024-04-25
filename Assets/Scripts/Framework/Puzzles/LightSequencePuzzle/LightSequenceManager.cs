using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSequenceManager : MonoBehaviour
{
    [SerializeField] private List<ObjectToggler> puzzleButtons = new();
    [SerializeField] private UnityEvent onFinshed = new();
    private bool isFinished;
    public void CheckOnFinished()
    {
        isFinished = true;
        foreach (var button in puzzleButtons)
        {
            if (!button.GetActive())
            {
                isFinished = false;
                break;
            }
        }
        if (isFinished) 
            onFinshed?.Invoke();
    }
}
