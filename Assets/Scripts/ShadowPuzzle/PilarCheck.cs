using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PilarCheck : MonoBehaviour
{
    public bool pilarInPlace;
    public GameObject pilarPlace;
    public GameObject pilar;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pilar)
        {
            pilarInPlace = true;
            FreezeMovement(other.gameObject);
        }
    }
    public void FreezeMovement(GameObject obj)
    {
        {
            Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezePositionX |
                                         RigidbodyConstraints.FreezePositionY |
                                         RigidbodyConstraints.FreezePositionZ;
            }
        }
    }
}