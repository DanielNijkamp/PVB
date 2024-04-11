using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

//TODO: namespace

[RequireComponent(typeof(Collider))]
public class EventTrigger : MonoBehaviour
{
    [SerializeField] private bool supplyInfo;
    
    [SerializeField, ShowIf("supplyInfo")] protected UnityEvent<Collider> onTriggerEnterWithInfo = new();
    [SerializeField, ShowIf("supplyInfo")] protected UnityEvent<Collider> onTriggerExitWithInfo = new();
    
    [SerializeField, HideIf("supplyInfo")] protected UnityEvent onTriggerEnter = new();
    [SerializeField, HideIf("supplyInfo")] protected UnityEvent onTriggerExit = new();
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (supplyInfo)
        {
            onTriggerEnterWithInfo?.Invoke(other);
        }
        else
        {
            onTriggerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (supplyInfo)
        {
            onTriggerExitWithInfo?.Invoke(other);
        }
        else
        {
            onTriggerExit?.Invoke();
        }
    }
}
