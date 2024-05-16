using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public sealed class Transition : MonoBehaviour
{
    [SerializeField] private float interval;

    [SerializeField] private UnityEvent[] steps = {};

    private int stepCount;
    private bool isTransitioning;
    
  public void StartTransition()
  {
      if (isTransitioning) return;
      
      StartCoroutine(DoSteps());
  }

    private IEnumerator DoSteps()
    {
        isTransitioning = true;
        while (stepCount <= steps.Length)
        {
            yield return DoStep();
        }
        isTransitioning = false;
    }
  
    private IEnumerator DoStep()
    {
        steps[stepCount]?.Invoke();
        yield return new WaitForSeconds(interval);
        stepCount++;
    }
    
}
