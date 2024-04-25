using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new();
    private int currentIndex;


    public void DisplayNextPuzzle()
    {
        for (int i = currentIndex; i < levels.Count; i++)
        {
            if(levels[i -2] != null)
            {
                levels[i - 2].SetActive(false);
            }
            //display next level
        }
    }
}
