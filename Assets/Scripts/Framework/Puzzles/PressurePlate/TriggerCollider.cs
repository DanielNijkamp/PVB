using UnityEngine;
using UnityEngine.Events;

public sealed class TriggerCollider : MonoBehaviour 
{
    [SerializeField] private UnityEvent onTriggerEnter = new();
    [SerializeField] private UnityEvent onTriggerExit = new();
    
    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        onTriggerExit?.Invoke();
    }
}
