using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour
{
    public TextMeshProUGUI _player;
    public GameObject playerInput;
    public string userInit;

    public GameObject scoreDisplay;
    public DisplayScores displayScores;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.gameObject.SetActive(false);
        playerInput.gameObject.SetActive(true);
    }

    public void setPlayerInit()
    {
        userInit = _player.text;
        GameManager.manager.AddScore(userInit, GameManager.manager.score);
        sortScores();
        GameManager.manager.SaveScores();
        ActivateScorePanel();
    }

    public void sortScores()
    {
        GameManager.manager.HighScores.Sort(delegate (Scores x, Scores y)
        {
            return x.finalScore.CompareTo(y.finalScore);
        });
        GameManager.manager.HighScores.Reverse();
        
    }
    public void ActivateScorePanel()
    {
        displayScores.DisplayScorePanel();
        scoreDisplay.gameObject.SetActive(true);
        playerInput.gameObject.SetActive(false);
            
    }
}
