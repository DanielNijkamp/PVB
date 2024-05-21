using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public sealed class Transition : MonoBehaviour
{
    [SerializeField] private float interval;

    [SerializeField] private UnityEvent[] steps = {};

    [ShowNonSerializedField] private bool isTransitioning;
    [ShowNonSerializedField] private int stepCount;
    
    public void StartTransition()
    {
        if (isTransitioning) return;
      
        StartCoroutine(DoSteps());
    }

    private IEnumerator DoSteps()
    {
        isTransitioning = true;
        while (stepCount < steps.Length)
        {
            yield return DoStep();
        }
        stepCount = 0;
        isTransitioning = false;
    }
    
    private IEnumerator DoStep()
    {
        steps[stepCount]?.Invoke();
        yield return new WaitForSeconds(interval);
        stepCount++;
    }
    
}
