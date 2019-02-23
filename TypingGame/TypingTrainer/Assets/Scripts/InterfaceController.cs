using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour {

    public static InterfaceController uiController;
    public GameObject pauseMenu;
    public GameObject winScreen;

	// Use this for initialization
	void Start () {
        pauseMenu.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
	}

    public void resumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void DisplayWin()
    {
        winScreen.gameObject.SetActive(true);
    }
}
