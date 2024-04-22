using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] menus;

    public void Startgame()
    {
        SceneLoader.LoadNextScene();
    }
    public void Play()
    {
        SceneLoader.AdditiveLoadNextScene();
    }

    public void RestGame()
    {
        SceneLoader.LoadOnIndex(0);
    }

    public void ToggleSettings()
    {
        foreach (var item in menus)
        {
            item.SetActive(!item.activeSelf);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}

