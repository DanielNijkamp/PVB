using Events;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player.Interaction
{
    public sealed class Interactable : EventTrigger
    {
        [field: SerializeField] public UnityEvent onInteraction { get; private set; } = new();
    }
}


