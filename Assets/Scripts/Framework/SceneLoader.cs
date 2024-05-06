using UnityEngine;
using UnityEngine.SceneManagement;
public sealed class SceneLoader : MonoBehaviour
{
  public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void AdditiveLoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }
    public static void LoadOnIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
