using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NaughtyAttributes;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public sealed class PlayerManager : MonoBehaviour
{
    public int PlayerCount { get; private set; }

    public List<GameObject> players;
    private PlayerInputManager inputManager;
    [SerializeField] private GameObject playerPrefab;
    private Transform spawnTransform;
    [SerializeField] private InputAction joinAction;
    [ShowNonSerializedField] private int inputCount;
    private UIhandler uIhandler;

    private readonly List<InputDevice> registeredDevices = new();
    private ReadOnlyCollection<Movement> playerMovements;
    [SerializeField] private UnityEvent<int, InputDevice> OnPlayerConnected = new();
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    } 
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TryFindComponents();
    }
    private void TryFindComponents()
    {
        inputManager = FindAnyObjectByType<PlayerInputManager>();
        spawnTransform = GameObject.FindWithTag("Spawn").transform;
        uIhandler = FindAnyObjectByType<UIhandler>();
    }
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
        OnPlayerConnected?.Invoke(inputCount, device);
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
