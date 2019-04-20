using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; //singleton design
    public ScoreManager scoreManager;

    public string playerName;
    public int score = 0;
    public int fruitSliced = 0;
    public int fruitMissed = 0;
    public float HitMissRatio = 0;
    public int level;
    public int totalFruit;

    public int TotalSliced = 0;
    public int TotalMissed = 0;
    public float bestRatio = 0f;
    public int allFruit;
    public float timeLimit = 60f;

    public bool canSpawn = true;

    [Header("Game Options")]
    public float fruitSizeMult = 1f;
    public float bladeSizeMult = 1f;
    public float gravityScaleMult = 1f;
    public float fruitSpeedMult = 1f;
    public float SpawnSpeedMult = 1f;
    public float timeLimitMult = 1f;
    public int fruitSelection = 0;

    
    void Awake()
    {
        
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        scoreManager.CheckForScores();
    }

    private void Update()
    {
        CalculateRatio();
        
    }
    public void IncreaseScore()
    {
        fruitSliced += 1;
        score += 1;
    }

    public void MissedFruit()
    {
        fruitMissed += 1;
    }

    public void CalculateRatio()
    {
        HitMissRatio = ((float)fruitSliced / (float)totalFruit) * 100;
    }

    public void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
    public void ReloadLevel()
    {
        UpdateStats();
        totalFruit = 0;
        fruitMissed = 0;
        fruitSliced = 0;
        HitMissRatio = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadTitleScreen()
    {
        ResetAll();
        SceneManager.LoadScene("Title");
    }

    public void UpdateStats()
    {
        if (bestRatio < HitMissRatio)
        {
            bestRatio = HitMissRatio;
        }

        TotalSliced += fruitSliced;
        TotalMissed += fruitMissed;
        allFruit += totalFruit;
    }

    public void ResetAll()
    {
        TotalSliced = 0;
        TotalMissed = 0;
        allFruit = 0;
        bestRatio = 0.0f;
        fruitMissed = 0;
        fruitSliced = 0;
        HitMissRatio = 0;
        playerName = null;
        canSpawn = true;
    }

    public void GameOver()
    {
        UpdateStats();
        scoreManager.AddScore(playerName, score);
        SceneManager.LoadScene("EndScene");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
