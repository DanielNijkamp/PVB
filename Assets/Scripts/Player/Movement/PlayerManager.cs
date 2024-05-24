using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerManager : MonoBehaviour
{
    public int PlayerCount { get; private set; }

    [HideInInspector] public List<GameObject> players;
    private PlayerInputManager inputManager;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnTransform;

    private ReadOnlyCollection<Movement> playerMovements;
    private PlayerRegister playerRegister;
   
    private void Awake()
    {
        inputManager = FindAnyObjectByType<PlayerInputManager>();
        inputManager.playerPrefab = playerPrefab;
        playerRegister = FindAnyObjectByType<PlayerRegister>();
    }
    private void Start()
    {
        SpawnPlayers();
    }

    public void SpawnPlayers()
    {
        List<GameObject> createdPlayers = new();
        List<Movement> movements = new();
        
        foreach (var device in playerRegister.registeredDevices)
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
