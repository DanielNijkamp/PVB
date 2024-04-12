using UnityEngine;
using UnityEngine.Events;
public class SpotlightDDetectionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent onDetected = new();
    [SerializeField] private UnityEvent onDetectionLost= new();

    private bool isFound;
    public void OnDetected()
    {
        if (!isFound)
        {
            isFound = true;
            onDetected?.Invoke();
        }
    }
    public void OnDetectionLost()
    {
        isFound = false;
        onDetectionLost?.Invoke();
    }
}
