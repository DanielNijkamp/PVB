using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NaughtyAttributes;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public sealed class PlayerManager : MonoBehaviour
{
    public int PlayerCount { get; private set; }

    public List<GameObject> players;

    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private InputAction joinAction;
    [ShowNonSerializedField] private int inputCount;
    
    private readonly List<InputDevice> registeredDevices = new();
    private ReadOnlyCollection<Movement> playerMovements;
    
    private void Awake()
    {
        inputManager.playerPrefab = playerPrefab;
        
        joinAction.Enable();
        joinAction.performed += RegisterPlayer;
    }

    private void OnDestroy()
    {
        joinAction.performed -= RegisterPlayer;
        joinAction.Disable();
    }
    
    private void RegisterPlayer(InputAction.CallbackContext context)
    {
        var device = context.control.device;
        if (registeredDevices.Contains(device) || registeredDevices.Count >= inputManager.maxPlayerCount) return;
        
        registeredDevices.Add(device);
        inputCount++;
    }

    public void SpawnPlayers()
    {
        List<GameObject> createdPlayers = new();
        List<Movement> movements = new();
        
        foreach (var device in registeredDevices)
        {
            var controlScheme = device is Gamepad ? "Gamepad" : "Keyboard&Mouse";
        
            var playerInstance = PlayerInput.Instantiate(playerPrefab, -1 ,controlScheme, -1,device);
        
            StartCoroutine(SetPlayerPosition(playerInstance.gameObject));
        
            movements.Add(playerInstance.GetComponent<Movement>());
        
            createdPlayers.Add(playerInstance.gameObject);
        }

        players = new List<GameObject>(createdPlayers);
        playerMovements = new ReadOnlyCollection<Movement>(movements);
        
        foreach (var player in players)
        {
            player.transform.position = spawnTransform.position;
        }

        PlayerCount = players.Count;
    }
    
    public void ToggleMovements()
    {
        foreach (var movement in playerMovements)
        {
            movement.ToggleFreeze();
        }
    }

    private IEnumerator SetPlayerPosition(GameObject gameObject)
    {
        gameObject.TryGetComponent<CharacterController>(out var controller);
        controller.enabled = false;
        yield return new WaitForSeconds(0.01f);
        controller.enabled = true;
    }
    
    
}
