using UnityEngine;

public class SequenceButton : SequenceItem<EnumColor> 
{
    public EnumColor ButtonValue;

    public void Activate()
    {
        base.isActivated = true;
        base.onActivate?.Invoke(ButtonValue);
    }
}
