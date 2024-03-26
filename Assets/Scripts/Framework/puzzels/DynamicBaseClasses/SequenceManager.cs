using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SequenceManager<T>
{
    T[] Sequence { get; set; }
    T[] SubmittedSequence { get; set; }

    void SetSequence();
    void RecieveValue(T value);

}
