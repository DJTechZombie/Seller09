using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    public TextMeshProUGUI highScoresText;
    public TextMeshProUGUI playerStatsText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        highScoresText.text = GameManager.instance.scoreManager.DisplayScores();
        playerStatsText.text = GameManager.instance.playerName + '\n' + "Score: " + GameManager.instance.score + '\n'
            + "Best Percentage: " + GameManager.instance.bestRatio.ToString("F2") + "%" + '\n'
            + "Total Fruit Slided: " + GameManager.instance.TotalSliced + '\n'
            + "Total Fruit Missed: " + GameManager.instance.TotalMissed + '\n'
            + "Overall Percentage: " + GameManager.instance.totalRatio.ToString("F2") + "%";
    }
    public void GotoMain()
    {
        GameManager.instance.LoadTitleScreen();
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }
}
