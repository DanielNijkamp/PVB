using UnityEngine;

public sealed class SequenceButton : SequenceItem<EnumColor> 
{
    [SerializeField] private EnumColor buttonValue;

    public void Activate()
    {
        base.isActivated = true;
        base.onActivate?.Invoke(buttonValue);
    }
}
