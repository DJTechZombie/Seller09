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
}
