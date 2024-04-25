using UnityEngine;
using UnityEngine.Events;

public sealed class Pillar: MonoBehaviour
{
    public bool Completed { get; private set; }

    [SerializeField] private Transform lockPosition;
    [SerializeField] private GameObject pillar;
    [SerializeField] private UnityEvent onCompleted = new();

    private Quaternion initialRotation;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject == pillar)
        {
            Completed = true;
            Lock(other.gameObject);
            onCompleted?.Invoke();
        }
    }
    private void Lock(GameObject obj)
    {
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
    
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            initialRotation = obj.transform.rotation;
        }
    }
