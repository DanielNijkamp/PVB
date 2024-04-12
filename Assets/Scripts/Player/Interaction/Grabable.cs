using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//TODO: namespace

[RequireComponent(typeof(Rigidbody))]
public sealed class Grabable : EventTrigger
{
    //should communicate outwards when it is ready to be grabable
    
    [BoxGroup("Events")]
    [SerializeField] private UnityEvent onGrab = new();
    [SerializeField] private UnityEvent onReadyForGrab = new();
    
    [ShowNonSerializedField] private bool isOwned;

    private void ToggleOwnership()
    {
        isOwned = !isOwned;
    }
    
    //when in range allow for grabbing. 
    //when grabbed the object is owned by a player. 
    //player can press again to drop item at feet. 
    
    
}
