using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolTile : SequenceItem<EnumSymbols>
{
    [SerializeField] private EnumSymbols itemValue;
    [HideInInspector] public bool isActive;
    public void Activate()
    {
        if (isActivated)
        {
            base.isActivated = true;
            base.onActivate?.Invoke(itemValue);
        }
    }
    public void ToggleActiveState()
    {
        isActivated = !isActivated;
    }
}
