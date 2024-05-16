using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public sealed class PuzzleCameras : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] puzzleCameras = new CinemachineVirtualCamera[2];
    public void SwitchCamera()
    {
        int highPriorityIndex = (puzzleCameras[0].Priority > puzzleCameras[1].Priority) ? 0 : 1;
        int lowPriorityIndex = 1 - highPriorityIndex;

        puzzleCameras[highPriorityIndex].Priority = 11;
        puzzleCameras[lowPriorityIndex].Priority = 9;
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
