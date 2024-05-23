using System.Collections.Generic;
using Events;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player.Interaction
{
    public sealed class Interactor : EventTrigger
    {
        [SerializeField] private UnityEvent onInteract = new();
        
        [SerializeField, BoxGroup("Input")] private InputActionAsset playerActions;
        [SerializeField, BoxGroup("Input")] private string actionName;
        [SerializeField, BoxGroup("Input")] private PlayerInput playerInput;
        
        private readonly List<Interactable> inRange = new();
        private InputAction interactAction;
        private void Awake()
        {
            InputActionAsset playerActions = playerInput.actions;
            interactAction = playerActions.FindAction(actionName);
            
            interactAction.performed += _ => Interact();
            
            onTriggerEnterWithInfo.AddListener(AddCollider);
            onTriggerExitWithInfo.AddListener(RemoveCollider);
        }

        private void OnDestroy()
        {
            interactAction.performed -= _ => Interact();
            
            onTriggerEnterWithInfo.RemoveListener(AddCollider);
            onTriggerExitWithInfo.RemoveListener(RemoveCollider);
            
        }
        private void AddCollider(Collider target)
        {   
            if (!target.TryGetComponent<Interactable>(out var interactable) || (inRange.Contains(interactable))) return;

            AddInteractable(interactable);
            
            Enable();
        }

        private void RemoveCollider(Collider target)
        {
            if (!target.TryGetComponent<Interactable>(out var interactable)) return;
            
            RemoveInteractable(interactable);
            
            Disable();
        }
        private void AddInteractable(Interactable interactable)
        {
            inRange.Add(interactable);
        }

        private void RemoveInteractable(Interactable interactable)
        {
            inRange.Remove(interactable);
        }
        
        private void Enable() 
        {
            interactAction.Enable();
        }

        private void Disable()
        {
            if (inRange.Count != 0) return;
            
            interactAction.Disable();
        }
    
        private void Interact()
        {
            var nearestObject = CalculateNearest();
            if (nearestObject != null)
            {
                nearestObject.onInteraction?.Invoke();
                onInteract?.Invoke();
            }
        }
        
        private Interactable CalculateNearest()
        {
            Interactable closestObject = null;
            float closestDistanceSqr = Mathf.Infinity;
            
            foreach (var obj in inRange)
            {
                Vector3 directionToTarget = obj.transform.position - transform.position;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestObject = obj;
                }
            }
            return closestObject;
        }
    }
}

