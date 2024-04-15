using UnityEngine;

public sealed class SymbolTile : SequenceItem<EnumSymbols>
{
    [SerializeField] private EnumSymbols itemValue;
    [HideInInspector] public bool IsActive;
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
