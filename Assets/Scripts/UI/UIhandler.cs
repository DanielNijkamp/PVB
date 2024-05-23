using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public sealed class UIhandler : MonoBehaviour
{
    [SerializeField] private Image inputIcon1;
    [SerializeField] private Image inputIcon2;

    [SerializeField] private Sprite controlerIcon;
    [SerializeField] private Sprite keyboardIcon;

    [SerializeField] private TextMeshProUGUI playerOneStatus;
    [SerializeField] private TextMeshProUGUI playerTwoStatus;

    public void SetIcon(int playerIndex,  InputDevice device)
    {
        Sprite input = device is Gamepad ? controlerIcon : keyboardIcon;
        if (playerIndex == 1)
        {
            inputIcon1.sprite = input;
            playerOneStatus.text = "Connected.";
        }
        else if (playerIndex == 2)
        {
            inputIcon2.sprite = input;
            playerTwoStatus.text = "Connected.";
        }
    }
}