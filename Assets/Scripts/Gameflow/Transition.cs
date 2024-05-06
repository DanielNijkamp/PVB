using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public sealed class Transition : MonoBehaviour
{
    [SerializeField] private float interval;
    
    [SerializeField] private UnityEvent onStart = new();
    [SerializeField] private UnityEvent onEnd = new();
    
    public void DoTransition()
    {
        StartCoroutine(TransitionCoroutine());
    }

    private IEnumerator TransitionCoroutine()
    {
        onStart?.Invoke();
        yield return new WaitForSeconds(interval);
        onEnd?.Invoke();
    }
    
}
