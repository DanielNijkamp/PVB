using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public sealed class PillarManager : MonoBehaviour
{
    [SerializeField] private Pillar[] pillars;
    [SerializeField] private UnityEvent onCompletion = new();
    public void CheckCompletion()
    {
        if (pillars.All(x => x.Completed))
        {
            onCompletion?.Invoke();
        }
    }
}