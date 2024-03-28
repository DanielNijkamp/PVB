using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public sealed class DirectionSetting
    {
        [field: SerializeField] public Direction Up { get; private set; }
        [field: SerializeField] public Direction Down { get; private set; }
        [field: SerializeField] public Direction Left { get; private set; }
        [field: SerializeField] public Direction Right { get; private set; }
    }
}