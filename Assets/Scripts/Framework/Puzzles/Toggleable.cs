using UnityEngine;
using UnityEngine.Events;

public sealed class Toggleable : MonoBehaviour
{
    [SerializeField] private Toggleable[] targets;
    [SerializeField] private UnityEvent onToggle;
    
    public void Toggle()
    {
        onToggle?.Invoke();
        
        if (targets.Length == 0) return;
        
        foreach (var toggable in targets)
        {
            toggable.onToggle?.Invoke();
        }
    }
}
