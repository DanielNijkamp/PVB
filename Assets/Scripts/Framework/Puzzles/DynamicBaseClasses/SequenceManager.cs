using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SequenceManager<T>
{
    T[] Sequence { get; set; }
    T[] SubmittedSequence { get; set; }

    void StartSequence();
    void RecieveValue(T value);
    void CheckSubmittedSequence();

}
