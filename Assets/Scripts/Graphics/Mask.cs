using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Mask : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.renderQueue = 3002;
    }            
}
