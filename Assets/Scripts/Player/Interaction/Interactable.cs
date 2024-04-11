using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//TODO: namespace

public sealed class Interactable : EventTrigger
{
    [SerializeField] private UnityEvent onInteraction = new();
    [SerializeField] private InputAction interactAction;

    [ShowNonSerializedField] private int collisionCount;
    private void Awake()
    {
        interactAction.performed += _ => Interact();
        onTriggerEnter.AddListener(Enable);
        onTriggerExit.AddListener(Disable);
    }

    private void OnDestroy()
    {
        interactAction.performed -= _ => Interact();
        onTriggerEnter.RemoveListener(Enable);
        onTriggerExit.RemoveListener(Disable);
    }

    private void Enable()
    {
        collisionCount++;
        interactAction.Enable();
    }

    private void Disable()
    {
        var result = collisionCount--;
        if (result == 0)
        {
            interactAction.Disable();
        }
    }
    
    private void Interact()
    {
        onInteraction?.Invoke();
    }
    
}
