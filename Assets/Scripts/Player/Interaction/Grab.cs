using System.Collections.Generic;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Interaction
{
    public sealed class Grab : EventTrigger
    {
        [SerializeField] private InputAction grabAction;
        
        
        [SerializeField, BoxGroup("Positions")] private Transform grabPosition;
        [SerializeField, BoxGroup("Positions")] private Transform dropPosition;
        
        private readonly List<Grabable> inRange = new();
        [CanBeNull] private Grabable heldObject;
        
        private void Awake()
        {
            grabAction.performed += _ => GrabObject();
            
            onTriggerEnterWithInfo.AddListener(AddObject);
            onTriggerExitWithInfo.AddListener(RemoveObject);
        }

        private void OnDestroy()
        {
            grabAction.performed -= _ => GrabObject();
            
            onTriggerEnterWithInfo.RemoveListener(AddObject);
            onTriggerExitWithInfo.RemoveListener(RemoveObject);
        }

        private void AddObject(Collider target)
        {
            if (!target.TryGetComponent<Grabable>(out var grabable)) return;

            if (grabable.isOwned) return;
            
            inRange.Add(grabable);
            
            Enable();
        }

        private void RemoveObject(Collider target)
        {
            if (!target.TryGetComponent<Grabable>(out var grabable)) return;
            
            inRange.Remove(grabable);
            
            Disable();
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
            var nearestObject = CalculateNearest();
            if (heldObject == null)
            {
                nearestObject.Grab();
                nearestObject.transform.position = grabPosition.position;
            }
            else
            {
                nearestObject.Release();
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