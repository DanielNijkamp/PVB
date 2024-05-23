using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using NaughtyAttributes;
public class PlayerRegister : MonoBehaviour
{
    public readonly List<InputDevice> registeredDevices = new();
    [SerializeField] private UnityEvent<int, InputDevice> OnPlayerConnected = new();
    [SerializeField] private UnityEvent OnPlayersReady = new();
    [SerializeField] private InputAction joinAction;
    [ShowNonSerializedField] private int inputCount;
    private PlayerInputManager inputManager;

    private void Awake()
    {
        inputManager = FindAnyObjectByType<PlayerInputManager>();
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
        if (registeredDevices.Count == inputManager.maxPlayerCount) OnPlayersReady?.Invoke();
    }
}
