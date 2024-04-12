using UnityEngine;
using UnityEngine.Events;
public class SymbolSequenceManager : MonoBehaviour , SequenceManager<EnumSymbols>
{
    public EnumSymbols[] Sequence { get; set; } = new EnumSymbols[4];
    public EnumSymbols[] SubmittedSequence { get; set; } = new EnumSymbols[4];

    [SerializeField] private UnityEvent onSolved = new ();
    [SerializeField] private UnityEvent onReset = new ();
    private int sequenceLength = 2;

    #region Manage Sequence
    private void Start()
    {
        SetSequence();
    }
    private void Update()
    {
        foreach (var item in Sequence)
        {
            Debug.Log("Sequence " + item.ToString());
        }
        foreach (var item in SubmittedSequence)
        {
            Debug.Log("Submitted " + item.ToString());
        }

    }
    public void SetSequence()
    {
        for (int i = 0; i < sequenceLength; i++)
        {
            EnumSymbols symbol = ((SequenceManager<EnumSymbols>)this).GetRandomElement();
            while (((SequenceManager<EnumSymbols>)this).IsElementinSequence(symbol) || symbol == EnumSymbols.Unassigned)
            {
                symbol = ((SequenceManager<EnumSymbols>)this).GetRandomElement();
            }
            Sequence[i] = symbol;   
        }
    }
    public void NextRound()
    {
        sequenceLength++;
        ResetPuzzle();
        SetSequence();
    }
    public void RecieveValue(EnumSymbols value)
    {
        print("recieved" + value);
        for (int i = 0; i < SubmittedSequence.Length; i++)
        {
            if (SubmittedSequence[i] == EnumSymbols.Unassigned)
            {
                SubmittedSequence[i] = value;
                if (CheckFinalSequenceInput(i))
                    CheckSubmittedSequence();
                break;
            }
        }
    }
    #endregion
    #region checks 
    public void CheckSubmittedSequence()
    {
        bool isCorrect = true;
        for (int i = 0; i < sequenceLength; i++)
        {
            if (SubmittedSequence[i] != Sequence[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect && sequenceLength == Sequence.Length)
        {
            onSolved?.Invoke();
            return; 
        }

        if (isCorrect)
        {
            NextRound();
        }
        else
        {
            onReset?.Invoke();
        }
    }
    public bool CheckFinalSequenceInput(int currentLength)
    {
        return (currentLength + 1 == sequenceLength);
    }
    public void ResetPuzzle()
    {
        for (int i = 0; i < SubmittedSequence.Length; i++)
        {
            SubmittedSequence[i] = EnumSymbols.Unassigned;

        }
    }
    #endregion
}
