using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public float timeLimit = 60f;
    private bool canCount = true;
    public Slider timerDisplay;

    public GameObject LevelEndPanel;


    public Text ratioText;
    public Text ScoreText;
    public Text HitText;
    public Text MissText;
    public Text PlayerName;
    public Text LevelText;
    public Text StatsText;

    public static int currentLevel = 1;


    [Header("Debug Variable")]
    [SerializeField]
    private float MaxTime = 60f;
    [SerializeField]
    private float RequiredRatio = 50.00f;

    public Image fill;

    private void Start()
    {
        PlayerName.text = GameManager.instance.playerName;
        LevelText.text = "Level " + currentLevel;
        MaxTime *= GameManager.instance.timeLimitMult;
        timerDisplay.maxValue = MaxTime;
        timeLimit *= GameManager.instance.timeLimitMult;

    }

    private void Update()
    {
        if (timeLimit >= 0.0f && canCount)
        {
            timeLimit -= Time.deltaTime;
            timerDisplay.value = timeLimit;
            if (timeLimit <= 15f)
            {
                fill.color = Color.red;
            }
            else if(timeLimit <= 30f)
            {
                fill.color = Color.yellow;
            }
        }
        else if (timeLimit <= 0)
        {
            GameManager.instance.canSpawn = false;
            StartCoroutine("EndDelay");
            canCount = false;
        }

        ratioText.text = "Ratio: " + GameManager.instance.HitMissRatio.ToString("F2") + "%";
        HitText.text = "Hit: " + GameManager.instance.fruitSliced.ToString();
        MissText.text = "Miss: " + GameManager.instance.fruitMissed.ToString();
        ScoreText.text = "Score: " + GameManager.instance.score.ToString();
    }

    IEnumerator EndDelay()
    {
        yield return new WaitForSeconds(2);
        LevelOver();
        StopCoroutine("EndDelay");
    }

    public void LevelOver()
    {
        
        if (GameManager.instance.HitMissRatio > RequiredRatio)
        {
            LevelEndPanel.SetActive(true);
            DisplayStats();
        }
        else
        {
            Debug.Log("GameOver");
            GameManager.instance.GameOver();
        }
    }

    public void nextlevel()
    {
        #region Modify Required Ratio by Level
        if(currentLevel < 3)
        {
            RequiredRatio = 50.0f;
        }
        else if(currentLevel <= 5)
        {
            RequiredRatio = 60.0f;
        }
        else if(currentLevel <=8 )
        {
            RequiredRatio = 70.0f;
        }
        else if (currentLevel <= 10)
        {
            RequiredRatio = 80.0f;
        }
        else
        {
            RequiredRatio = 90.0f;
        }
        #endregion
        LevelEndPanel.SetActive(false);
        Restart();
        GameManager.instance.ReloadLevel();
    }
    public void MainMenu()
    {
        GameManager.instance.ResetAll();
        GameManager.instance.LoadTitleScreen();
    }

    public void QuitGame()
    {
        GameManager.instance.GameOver();
    }

    public void DisplayStats()
    {
        StatsText.text = "Fruit Sliced: " + GameManager.instance.fruitSliced + '\n'
            + "Fruit Missed: " + GameManager.instance.fruitMissed + '\n'
            + "Percent Sliced: " + GameManager.instance.HitMissRatio.ToString("F2") + "%" + '\n'
            + "Score: " + GameManager.instance.score;
    }

    public void Restart()
    {
        currentLevel++;
        PlayerName.text = GameManager.instance.playerName;
        LevelText.text = "Level " + currentLevel;
        MaxTime = 60f* GameManager.instance.timeLimitMult;
        timerDisplay.maxValue = MaxTime;
        timeLimit = 60f * GameManager.instance.timeLimitMult;
        canCount = true;
        GameManager.instance.canSpawn = true;
    }
}
