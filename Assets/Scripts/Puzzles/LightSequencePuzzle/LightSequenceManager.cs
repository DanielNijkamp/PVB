using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class LightSequenceManager : MonoBehaviour
{
    [SerializeField] private List<ObjectToggler> puzzleButtons = new();
    [SerializeField] private UnityEvent onFinshed = new();
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
                return false;
            }
        }
        return true;
    }
}
