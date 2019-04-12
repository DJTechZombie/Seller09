using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    void Start()
    {
    if(SceneManager.GetActiveScene().name == "TitleScreen" && GameManager.manager!=null)
        {
            GameManager.manager.score = 0;
            GameManager.manager.lives = 3;
        }
    }

    public void LoadScoresPage()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void StartGame()
    {
        GameManager.manager.lives = (int)GameManager.manager.maxLives;
        GameManager.manager.score = 0;
        GameManager.manager.fliesEaten = 0;
        GameManager.manager.levelsCleared = 0;
        SceneManager.LoadScene("Main");
        TitleMusic.titleMusic.StopTitleMusic();
    }

    public void LoadControlsPage()
    {
        SceneManager.LoadScene("Controls");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        if(!TitleMusic.titleMusic.titleSource.isPlaying)
        {
            TitleMusic.titleMusic.startMusic();
        }
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void GoToOCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
