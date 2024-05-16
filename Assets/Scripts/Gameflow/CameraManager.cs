using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace CameraSystem
{

    //TODO: add events and puzzleCameras with the cameras to the scene
    public sealed class CameraManager : MonoBehaviour
    {
        [SerializeField] private List<PuzzleCameras> puzzles = new List<PuzzleCameras>();
        [SerializeField] private UnityEvent<int> OnCameraAngleChanged = new ();
        private int playersEntered;
        private int currentPuzzle = 0;

        public void NextPuzzle()
        {
            playersEntered = 0;
            puzzles[currentPuzzle].DeactivatePuzzleCamera();
            currentPuzzle++;
            puzzles[currentPuzzle].ActivatePuzzleCamera();
        }

        public void EnteredPuzzle()
        {
            playersEntered++;
        }

        public void SwitchCamera(int direction)
        {
            if(playersEntered >= 2)
            {
                StartCoroutine(SwichCameras(direction));
            }
        }
        private IEnumerator SwichCameras(int direction)
        {
            puzzles[currentPuzzle].SwitchCamera();
            yield return new WaitForSeconds(1.5f);
            OnCameraAngleChanged?.Invoke(direction);
        }
    }
}