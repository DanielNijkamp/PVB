using System;
using System.Linq;
public interface SequenceManager<T>
{
    public T[] Sequence { get; set; }
    public T[] SubmittedSequence { get; set; }

   public void SetSequence();
    public void RecieveValue(T value);
    public void CheckSubmittedSequence();
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
