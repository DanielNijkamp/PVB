using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using System;

public sealed class Pillar: MonoBehaviour
{
    public bool Completed { get; private set; }

    [SerializeField] private Transform lockPosition;
    [SerializeField] private GameObject pillar;
    [SerializeField] private UnityEvent onCompleted = new();

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
            }
    }
}