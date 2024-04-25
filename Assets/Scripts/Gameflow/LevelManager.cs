using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Vector3 = UnityEngine.Vector3;

public sealed class LevelManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onCompletion = new();
    [SerializeField] private Level[] levels = {};
    private bool[] used;
    private int currentIndex;
    
    private void Start()
    {
        used = new bool[levels.Length];
        if (levels.Any())
        {
            levels[0].gameObject.SetActive(true);
            used[0] = true;
            currentIndex = 1;
            levels[0].gameObject.transform.position = Vector3.zero;
        }
    }

    public void SpawnLevel()
    {
        var nonUsedIndices = Enumerable.Range(0, levels.Length).Where(i => !used[i]).ToList();

        if (!nonUsedIndices.Any())
        {
            onCompletion?.Invoke();
            return;
        }

        var index = nonUsedIndices[Random.Range(0, nonUsedIndices.Count)];
        used[index] = true;

        Level newLevel = levels[index];

        if (currentIndex > 0)
        {
            Level currentLevel = levels[currentIndex - 1];
            SetPosition(newLevel, currentLevel);
        }

        newLevel.gameObject.SetActive(true);
        currentIndex++;
    }

    private void SetPosition(Level newLevel, Level currentLevel)
    {
        newLevel.transform.position = currentLevel.spawnPosition.position;
    }
    
    public void DeSpawnOld()
    {
        if (currentIndex > 1)
        {
            levels[currentIndex - 2].gameObject.SetActive(false);
        }
        
    }
    
}
