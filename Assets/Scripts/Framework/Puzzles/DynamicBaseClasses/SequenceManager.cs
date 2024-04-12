using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public interface SequenceManager<T>
{
    T[] Sequence { get; set; }
    T[] SubmittedSequence { get; set; }

    void SetSequence();
    void RecieveValue(T value);
    void CheckSubmittedSequence();
    T GetRandomElement()
    {
        Array enumValues = Enum.GetValues(typeof(T));
        System.Random random = new System.Random();
        return (T)enumValues.GetValue(random.Next(enumValues.Length));
    }
    bool IsElementinSequence(T element)
    {
       return Sequence.Any(X => X.Equals(element));
    }

}
