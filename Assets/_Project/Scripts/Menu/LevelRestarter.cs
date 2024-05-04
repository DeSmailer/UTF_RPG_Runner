using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
  public void Restart()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);

    //string currentSceneName = SceneManager.GetActiveScene().name;

    //// Unload the current scene
    //SceneManager.UnloadSceneAsync(currentSceneName);

    //// Load the current scene again
    //SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);
  }
}
