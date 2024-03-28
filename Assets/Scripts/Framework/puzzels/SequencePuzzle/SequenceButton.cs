using UnityEngine;

public sealed class SequenceButton : SequenceItem<EnumColor> 
{
    [SerializeField] private EnumColor ButtonValue;

    public void Activate()
    {
        base.isActivated = true;
        base.onActivate?.Invoke(ButtonValue);
    }
}
