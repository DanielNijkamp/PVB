using System.Collections.Generic;
using System.Collections.ObjectModel;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public sealed class PlayerManager : MonoBehaviour
{
    public int PlayerCount => players.Count;
    
    public ReadOnlyCollection<GameObject> players { get; private set; }

    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private InputAction joinAction;
    
    private readonly List<InputDevice> registeredDevices = new();
    
    private Movement[] movements;
    
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

    public void SpawnPlayers()
    {
        List<GameObject> createdPlayers = new();
        foreach (var device in registeredDevices)
        {
            var controlScheme = device is Gamepad ? "Gamepad" : "Keyboard&Mouse";
        
            var playerInstance = PlayerInput.Instantiate(playerPrefab);
            
            foreach (var pairedDevice in playerInstance.user.pairedDevices)
            {
                if (pairedDevice != null)
                {
                    playerInstance.user.UnpairDevice(pairedDevice);
                }
            }
            
            InputUser.PerformPairingWithDevice(device, playerInstance.user);
            playerInstance.SwitchCurrentControlScheme(controlScheme, device);
        
            createdPlayers.Add(playerInstance.gameObject);
        }
        players = new ReadOnlyCollection<GameObject>(createdPlayers);
    }

    private void RegisterPlayer(InputAction.CallbackContext context)
    {
        var device = context.control.device;
        if (registeredDevices.Contains(device) || registeredDevices.Count >= inputManager.maxPlayerCount) return;
        
        registeredDevices.Add(device);
    }
    
    public void ToggleMovements()
    {
        foreach (var movement in movements)
        {
            movement.ToggleFreeze();
        }
    }
    
    
}
