using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DoNotDestroyOnLoad : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<DoNotDestroyOnLoad>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
