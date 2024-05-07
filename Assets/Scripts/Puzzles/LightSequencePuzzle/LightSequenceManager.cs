using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class LightSequenceManager : MonoBehaviour
{
    [SerializeField] private List<ObjectToggler> puzzleButtons = new();
    [SerializeField] private UnityEvent onFinshed = new();
    private bool isFinished;
    public void OnFinished()
    {
        if (CheckActiveButtons())
        {
            onFinshed?.Invoke();
        }
    }

    private bool CheckActiveButtons()
    {
        foreach (var button in puzzleButtons)
        {
            if (!button.GetActive())
            {
                print("false");
                return false;
            }
        }
        print("true");
        return true;
    }
}
