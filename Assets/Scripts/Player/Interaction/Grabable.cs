using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Interaction
{
    [RequireComponent(typeof(Collider))]
    public sealed class Grabable : MonoBehaviour
    {
        [SerializeField] private UnityEvent onGrab = new();
        [SerializeField] private UnityEvent onRelease = new();
        public Action onForceRelease;
        
        [field: ShowNonSerializedField] public bool IsOwned { get; private set; }
    
        private bool updatePosition;
        private Collider collider;
        
        private Transform grabTransform;
    
        private void Awake()
        {
            collider = GetComponent<Collider>();
        }
        
        private void FixedUpdate()
        {
            if (!updatePosition) return;

            this.transform.position = grabTransform.position;
            this.transform.rotation = grabTransform.rotation;
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
        public void ForceRelease()
        {
            Release();
            onForceRelease();
            Destroy(this);
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

