using UnityEngine.Events;
using UnityEngine;

public abstract class SequenceItem<T> : MonoBehaviour
{
    protected bool isActivated { get; set; }

    [SerializeField]
    protected UnityEvent<T> onActivate = new UnityEvent<T>();

}
