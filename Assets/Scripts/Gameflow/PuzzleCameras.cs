using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public sealed class PuzzleCameras : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] puzzleCameras = new CinemachineVirtualCamera[2];
    public void SwitchCamera()
    {
        if (puzzleCameras[0].Priority > puzzleCameras[1].Priority) puzzleCameras[1].Priority = 9;
        else puzzleCameras[1].Priority = 11;
    }

    public void ActivatePuzzleCamera()
    {
        puzzleCameras[0].Priority = 11;
        puzzleCameras[1].Priority = 10;
    }
    public void DeactivatePuzzleCamera()
    {
        puzzleCameras[0].Priority = 9;
        puzzleCameras[1].Priority = 9;
    }
}
