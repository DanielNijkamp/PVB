using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public sealed class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] menus;
    [SerializeField] private GameObject playButton;

    public void Startgame()
    {
        SceneLoader.LoadNextScene();
    }

    public void RestGame()
    {
        SceneLoader.LoadOnIndex(0);
    }

    public void ToggleMenu(int index)
    {
        foreach (var item in menus)
        {
            item.SetActive(false);
        }
        menus[index].SetActive(true);
    }

    public void RevealPlayButton()
    {
        playButton.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

