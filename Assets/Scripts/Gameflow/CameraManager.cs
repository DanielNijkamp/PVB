using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace CameraSystem
{

    //TODO: add events and puzzleCameras with the cameras to the scene
    public sealed class CameraManager : MonoBehaviour
    {
        [SerializeField] private List<PuzzleCameras> puzzles = new List<PuzzleCameras>();
        [SerializeField] private UnityEvent<int> OnCameraAngleChanged = new ();
        [SerializeField] private int controlSet;
        private int playersEntered;
        private int currentPuzzle;

        public void NextPuzzle()
        {
            puzzles[currentPuzzle].DeactivatePuzzleCamera();
            currentPuzzle++;
            puzzles[currentPuzzle].ActivatePuzzleCamera();
        }

        public void EnteredPuzzle()
        {
            playersEntered++;
        }

        public void SwitchCamera()
        {
            if(playersEntered >= 2)
            {
                puzzles[currentPuzzle].SwitchCamera();
                OnCameraAngleChanged?.Invoke(controlSet);
            }
        }
    }
}