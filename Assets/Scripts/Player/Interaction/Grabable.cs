using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//TODO: namespace

[RequireComponent(typeof(Rigidbody))]
public sealed class Grabable : EventTrigger
{
    //
    
    [SerializeField, Required] private Transform grabbedPosition; 
    
    [SerializeField] private UnityEvent onGrab = new();
    [SerializeField] private InputAction grabAction; // (Key)F + (gamepad south)X 
    
    [ShowNonSerializedField] private bool isOwned;
    
    private void Enable(Collider other)
    {
        grabAction.Enable();
    }

    private void Disable(Collider other)
    {
        grabAction.Disable();
    }

    private void Grab()
    {
        isOwned = true;
        //positioning
    }
    //when in range allow for grabbing. 
    //when grabbed the object is owned by a player. 
    //player can press again to drop item at feet. 
    
    
}
