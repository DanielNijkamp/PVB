using UnityEngine;
using System;
using System.Collections.Generic;

public class ColorSequenceManager : MonoBehaviour, SequenceManager<EnumColor>
{
    public List<SequenceItem<EnumColor>> sequenceButtons = new List<SequenceItem<EnumColor>>();
    public EnumColor[] Sequence { get; set; }  = new EnumColor[5];
    public EnumColor[] SubmittedSequence { get; set; } = new EnumColor[5];

    private int sequenceLength = 3;
    void Start()
    {
        SetSequence();
    }
    #region Manage Sequence
    public void SetSequence()
    {
        for (int i = 0; i < sequenceLength; i++)
        {
            EnumColor color;
            color = GetRandomColor();
            while(IsColorInSequence(color) || color == EnumColor.Unassigned)
            {
                color = GetRandomColor();
            }
            Sequence[i] = color;
        }
    }
    public void NextRound()
    {
        sequenceLength++;
        for (int i = 0; i < sequenceLength; i++)
        {
            if (Sequence[i] != EnumColor.Unassigned) continue;

            EnumColor color;
            color = GetRandomColor();
            while (IsColorInSequence(color) || color == EnumColor.Unassigned)
            {
                color = GetRandomColor();
            }
            Sequence[i] = color;
            break;
        }
    }
    public void RecieveValue(EnumColor value)
    {
        for (int i = 0; i < SubmittedSequence.Length; i++)
        {
            if(SubmittedSequence[i] == EnumColor.Unassigned)
            {
                SubmittedSequence[i] = value;
                break;
            }
        }
    }
    public void ResetSubmittedSequence()
    {
        for (int i = 0; i < SubmittedSequence.Length; i++)
        {
            SubmittedSequence[i] = EnumColor.Unassigned; 
        }
    }
    #endregion

    #region checks
    private EnumColor GetRandomColor()
    {
        Array enumValues = Enum.GetValues(typeof(EnumColor));
        System.Random random = new System.Random();
        return (EnumColor)enumValues.GetValue(random.Next(enumValues.Length));
    }

    private bool IsColorInSequence(EnumColor color)
    {
        foreach (EnumColor c in Sequence)
        {
            if (c == color)
            {
                return true;
            }
        }
        return false;
    }
    #endregion
}
