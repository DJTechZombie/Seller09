using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GUI_Manager : MonoBehaviour
{
    public static GUI_Manager guiMan;

    public GameObject pauseScreen;

    public GameObject heart1, heart2, heart3, heart4, heart5;

    public Text scoreText;
    public Text lifeScoreText;
    public Text levelText;

    private void Awake()
    {
        guiMan = this;
        scoreText.text = "Total Score: " + GameManager.manager.score;
        lifeScoreText.text = "Score This Life: " + GameManager.manager.lifeScore;
    }


    void Start()
    {
        pauseScreen.gameObject.SetActive(false);

        //Intialize Life Display
        switch(GameManager.manager.lives)
        {
            case 5:
                {
                }
                break;

            case 4:
                {
                    heart5.SetActive(false);
                }
                break;


            case 3:
                {
                    heart5.SetActive(false);
                    heart4.SetActive(false);
                }
                break;
            case 2:
                {
                    heart5.SetActive(false);
                    heart4.SetActive(false);
                    heart3.SetActive(false);
                }
                break;
            case 1:
                {
                    heart5.SetActive(false);
                    heart4.SetActive(false);
                    heart3.SetActive(false);
                    heart2.SetActive(false);
                }
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = (GameManager.manager.levelsCleared + 1).ToString();
    }

    public void EnablePauseScreen()
    {
        pauseScreen.gameObject.SetActive(true);
    }
    public void DisablePauseScreen()
    {
        pauseScreen.gameObject.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void  DisplayLives(int _lives)
    {
        if(_lives == 2)
        {
            heart3.SetActive(false);
        }
        else if(_lives == 1)
        {
            heart2.SetActive(false);
        }
    }
}
