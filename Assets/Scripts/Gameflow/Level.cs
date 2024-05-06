using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public sealed class Level : MonoBehaviour
{
    [field: SerializeField] public Transform spawnPosition { get; private set; }
    public bool Used { get; set; }
}
