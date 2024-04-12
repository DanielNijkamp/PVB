using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

//TODO: namespace

[RequireComponent(typeof(Rigidbody))]
public sealed class Grabable : MonoBehaviour
{
    [SerializeField] private UnityEvent onGrab = new();
    [SerializeField] private UnityEvent onRelease = new();
    
    [field: ShowNonSerializedField] public bool isOwned { get; private set; }

    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void ToggleOwnership()
    {
        isOwned = !isOwned;
    }

    public void Grab()
    {
        ToggleOwnership();
        onGrab?.Invoke();
        
        //freeze physics
        
    }

    public void Release()
    {
        ToggleOwnership();
        onRelease?.Invoke();
        
        //enable physics again
    }
    
}
