using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace CameraSystem
{

    //TODO: add events and puzzleCameras with the cameras to the scene
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private List<PuzzleCameras> puzzles = new List<PuzzleCameras>();
        [SerializeField] private UnityEvent<int> OnCameraAngleChanged = new ();

        private int currentPuzzle;

        public void NextPuzzle()
        {
            puzzles[currentPuzzle].DeactivatePuzzleCamera();
            currentPuzzle++;
            puzzles[currentPuzzle].ActivatePuzzleCamera();
        }

        public void SwitchCamera(int direction)
        {
            puzzles[currentPuzzle].SwitchCamera();
            OnCameraAngleChanged?.Invoke(direction);
        }
    }
}