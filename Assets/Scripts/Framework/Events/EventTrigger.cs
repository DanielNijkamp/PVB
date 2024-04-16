using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    [RequireComponent(typeof(Collider))]
    public class EventTrigger : MonoBehaviour
    {
        [SerializeField] private bool supplyInfo;
    
        [SerializeField, ShowIf("supplyInfo")] protected UnityEvent<Collider> onTriggerEnterWithInfo = new();
        [SerializeField, ShowIf("supplyInfo")] protected UnityEvent<Collider> onTriggerExitWithInfo = new();
    
        [SerializeField, HideIf("supplyInfo")] protected UnityEvent onTriggerEnter = new();
        [SerializeField, HideIf("supplyInfo")] protected UnityEvent onTriggerExit = new();

        [SerializeField, BoxGroup("Sorting")] private bool withTag;
        [SerializeField,Tag, EnableIf("withTag"), BoxGroup("Sorting")] protected string tag;
    
        private void OnTriggerEnter(Collider other)
        {
            if (withTag && !other.CompareTag(tag)) return;
            
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
            if (withTag && !other.CompareTag(tag)) return;      
            
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
}


