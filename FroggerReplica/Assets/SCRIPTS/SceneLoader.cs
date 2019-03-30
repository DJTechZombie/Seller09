using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    string currentSceneName;
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
