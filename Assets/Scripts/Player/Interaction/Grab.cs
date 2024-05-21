using System.Collections.Generic;
using Events;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player.Interaction
{
    public sealed class Grab : EventTrigger
    {
        [SerializeField, BoxGroup("Input")] private InputActionAsset playerActions;
        [SerializeField, BoxGroup("Input")] private string actionName;
        [SerializeField, BoxGroup("Input")] private PlayerInput playerInput;
        
        [SerializeField, BoxGroup("Positions")] private Transform grabPosition;
        [SerializeField, BoxGroup("Positions")] private Transform dropPosition;
        
        private readonly List<Grabable> inRange = new();
        private Grabable heldObject;
        private InputAction grabAction;
        
        private void Awake()
        {
            InputActionAsset playerActions = playerInput.actions;
            grabAction = playerActions.FindAction(actionName);
            
            grabAction.performed += _ => GrabObject();
            
            onTriggerEnterWithInfo.AddListener(AddCollider);
            onTriggerExitWithInfo.AddListener(RemoveCollider);
        }

        private void OnDestroy()
        {
            grabAction.performed -= _ => GrabObject();
            
            onTriggerEnterWithInfo.RemoveListener(AddCollider);
            onTriggerExitWithInfo.RemoveListener(RemoveCollider);
        }

        private void AddCollider(Collider target)
        {   
            if (!target.TryGetComponent<Grabable>(out var grabable) || (grabable.IsOwned || inRange.Contains(grabable))) return;

            AddGrabable(grabable);
            
            Enable();
        }

        private void RemoveCollider(Collider target)
        {
            if (!target.TryGetComponent<Grabable>(out var grabable)) return;
            
            RemoveGrabable(grabable);
            
            Disable();
        }

        private void AddGrabable(Grabable grabable)
        {
            inRange.Add(grabable);
            grabable.onForceRelease += () => RemoveGrabable(grabable);
        }

        private void RemoveGrabable(Grabable grabable)
        {
            inRange.Remove(grabable);
            grabable.onForceRelease -= () => RemoveGrabable(grabable);
        }
        
        private void Enable() 
        {
            grabAction.Enable();
        }

        private void Disable()
        {
            if (inRange.Count != 0) return;
            
            grabAction.Disable();
        }

        private void GrabObject()
        {
            if (heldObject == null)
            {
                var nearestObject = CalculateNearest();
                if (nearestObject != null)
                {
                    nearestObject.Grab(grabPosition);
                    heldObject = nearestObject;
                }
            }
            else
            {
                heldObject.Release();
                heldObject.transform.position = dropPosition.position;
                heldObject = null;
            }
        }
        
        private Grabable CalculateNearest()
        {
            Grabable closestObject = null;
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