using Events;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public sealed class Corridor : EventTrigger
{
    [SerializeField] private UnityEvent onPassage = new();
    
    [SerializeField] private PlayerManager playerManager;
    
    private bool allowPassage;
    private int playerCount;

    private void Awake()
    {
        onTriggerEnter.AddListener(Add);
        onTriggerExit.AddListener(Remove);
        
        onTriggerEnter.AddListener(CheckPassage);
    }

    private void OnDestroy()
    {
        onTriggerEnter.RemoveAllListeners();
        onTriggerExit.RemoveAllListeners();
    }
    
    public void ToggleAllowance()
    {
        allowPassage = !allowPassage;
    }

    private void Add()
    {
        playerCount++;
    }

    private void Remove()
    {
        playerCount--;
    }
    
    private void CheckPassage()
    {
        if (allowPassage && (playerCount == playerManager.PlayerCount))
        {
            onPassage?.Invoke();
        }
    }
}
