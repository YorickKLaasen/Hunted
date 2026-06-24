using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void SceneLoader(string sceneName = "")
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is empty or null.");
        }
    }
    
    public void OnQuitClick()
    {
        Application.Quit();
    }
}
