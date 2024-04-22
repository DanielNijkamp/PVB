using Events;
using UnityEngine;
using UnityEngine.Events;

//instead of loading scenes we can just do it with prefabs.

[RequireComponent(typeof(Collider))]
public sealed class Corridor : EventTrigger
{
    [SerializeField] private UnityEvent onPassage = new();
    
    [SerializeField] private PlayerManager playerManager;
    
    private bool allowPassage;
    private int playerCount;

    private void Awake()
    {
        onTriggerEnter.AddListener(CheckPassage);
        
        onTriggerEnter.AddListener(Add);
        onTriggerExit.AddListener(Remove);
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
    
    
    //load new puzzle/scene : sceneloader script. WIP
    //teleport player : teleporter script
    //if all players are there disable movement for a while. : playerManager?
    private void CheckPassage()
    {
        if (playerCount == playerManager.PlayerCount)
        {
            onPassage?.Invoke();
        }
    }
    
    

}
