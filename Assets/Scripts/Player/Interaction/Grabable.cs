using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Interaction
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Grabable : MonoBehaviour
    {
        [SerializeField] private UnityEvent onGrab = new();
        [SerializeField] private UnityEvent onRelease = new();
        
        [field: ShowNonSerializedField] public bool IsOwned { get; private set; }
    
        private bool updatePosition;
        private new Rigidbody rigidbody;
        private new Collider collider;
        
        private Transform grabTransform;
    
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            collider = GetComponent<Collider>();
        }
        
        private void FixedUpdate()
        {
            if (!updatePosition) return;
            
            rigidbody.MovePosition(grabTransform.position);
            rigidbody.MoveRotation(grabTransform.rotation);
        }
        
        public void Grab(Transform grabTransform)
        {
            this.grabTransform = grabTransform;
            
            ToggleOwnership();
            TogglePhysics();
            ToggleTracking();
            onGrab?.Invoke();
        }
    
        public void Release()
        {
            ToggleOwnership();
            TogglePhysics();
            ToggleTracking();
            onRelease?.Invoke();
        }
    
        private void ToggleOwnership()
        {
            IsOwned = !IsOwned;
        }
        
        private void ToggleTracking()
        {
            updatePosition = !updatePosition;
        }
        
        private void TogglePhysics()
        {
            collider.enabled = !collider.enabled;
    
        }
        
    }
}

