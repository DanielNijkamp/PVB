using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public sealed class InputActionDebugger : MonoBehaviour
{
    [Serializable]
    private struct KeyActionPair
    {
        [field: SerializeField] public InputAction InputAction { get; private set; }
        [field: SerializeField] public UnityEvent Event { get; private set; }

    }

    [SerializeField] private KeyActionPair[] keyActionPairs;
    
    private void OnEnable()
    {
        foreach (var mapping in keyActionPairs)
        {
            var action = mapping.InputAction;

            if (action == null)
            {
                Debug.LogWarning("InputAction was null");
                continue;
            };
            
            action.performed += _ => mapping.Event?.Invoke();
            action.Enable();
        }
    }

    private void OnDisable()
    {
        foreach(var mapping in keyActionPairs)
        {
            var action = mapping.InputAction;
            action?.Disable();
        }
    }
}
