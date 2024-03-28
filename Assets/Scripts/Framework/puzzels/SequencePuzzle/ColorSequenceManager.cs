using UnityEngine;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

public sealed class ColorSequenceManager : MonoBehaviour, SequenceManager<EnumColor>
{
    public EnumColor[] Sequence { get; set; }  = new EnumColor[5];
    public EnumColor[] SubmittedSequence { get; set; } = new EnumColor[5];

    [SerializeField] private UnityEvent onSolved = new UnityEvent();
    [SerializeField] private UnityEvent onReset = new UnityEvent();


    

    private int sequenceLength = 3;

    #region Manage Sequence
    public void StartSequence()
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
                if (CheckFinalSequenceInput(i))
                        CheckSubmittedSequence();
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
    public bool CheckFinalSequenceInput(int currentLength)
    {
        if (currentLength + 1 == sequenceLength) return true;
        else return false;
    }
    public void CheckSubmittedSequence()
    {
        bool isCorrect = true;
        for (int i = 0; i < sequenceLength; i++)
        {
            if (SubmittedSequence[i] != Sequence[i])
            {
                isCorrect = false;
                onReset?.Invoke();
                break;
            }   
        }
        if (isCorrect)
        {
            if (sequenceLength == Sequence.Length) onSolved?.Invoke();
            else NextRound();
        }
        ResetSubmittedSequence();
    }
    #endregion
}
