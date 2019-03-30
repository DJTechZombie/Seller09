using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GUI_Manager : MonoBehaviour
{
    public static GUI_Manager guiMan;

    public GameObject pauseScreen;

    public GameObject heart1, heart2, heart3;

    public Text scoreText;

    private void Awake()
    {
        guiMan = this;
        scoreText.text = "Score: " + GameManager.manager.score;
    }


    void Start()
    {
        pauseScreen.gameObject.SetActive(false);

        //Intialize Life Display
        switch(GameManager.manager.lives)
        {
            case 3:
                {
                    heart3.SetActive(true);
                    heart2.SetActive(true);
                    heart1.SetActive(true);
                }
                break;
            case 2:
                {
                    heart3.SetActive(false);
                    heart2.SetActive(true);
                    heart1.SetActive(true);
                }
                break;
            case 1:
                {
                    heart3.SetActive(false);
                    heart2.SetActive(false);
                    heart1.SetActive(true);
                }
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

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
