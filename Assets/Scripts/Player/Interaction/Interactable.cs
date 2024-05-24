using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Interaction
{
    public sealed class Interactable : EventTrigger
    {
        [field: SerializeField] public UnityEvent onInteraction { get; private set; } = new();
    }
}


