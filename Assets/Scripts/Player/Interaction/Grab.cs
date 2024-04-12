using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Interaction
{
    public class Grab : EventTrigger
    {
        //this script should handle the grabbing and owning of grabbable object
        
        [SerializeField] private InputAction grabAction; // (Key)F + (gamepad south)X 
        
        //collision is triggered with a object that can be picked up.
        //check for closest grabable object and grab it when pickedup.
        private void Awake()
        {
            onTriggerEnter.AddListener(Enable);
            onTriggerExit.AddListener(Disable);
        }

        private void OnDestroy()
        {
            onTriggerEnter.RemoveListener(Enable);
            onTriggerExit.RemoveListener(Disable);
        }
        
        private void Enable() 
        {
            grabAction.Enable();
        }

        private void Disable()
        {
            grabAction.Disable();
        }

        private void GrabNearest()
        {
            
        }
        
        
    }
}