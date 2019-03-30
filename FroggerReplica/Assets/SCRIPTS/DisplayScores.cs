using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour
{

    public TextMeshProUGUI _name1, _name2, _name3, _name4, _name5;
    public TextMeshProUGUI _score1, _score2, _score3, _score4, _score5;
    public GameObject _scorePanel;


    // Start is called before the first frame update

    void Start()
    {
        DisplayScorePanel();
        _scorePanel.gameObject.SetActive(true);

    }

    public void DisplayScorePanel()
    {
        _name1.text = GameManager.manager.HighScores[0].playerInitials;
        _name2.text = GameManager.manager.HighScores[1].playerInitials;
        _name3.text = GameManager.manager.HighScores[2].playerInitials;
        _name4.text = GameManager.manager.HighScores[3].playerInitials;
        _name5.text = GameManager.manager.HighScores[4].playerInitials;

        _score1.text = GameManager.manager.HighScores[0].finalScore.ToString();
        _score2.text = GameManager.manager.HighScores[1].finalScore.ToString();
        _score3.text = GameManager.manager.HighScores[2].finalScore.ToString();
        _score4.text = GameManager.manager.HighScores[3].finalScore.ToString();
        _score5.text = GameManager.manager.HighScores[4].finalScore.ToString();
    }

    public void sortScores()
    {
        GameManager.manager.HighScores.Sort(delegate (Scores x, Scores y)
        {
            return x.finalScore.CompareTo(y.finalScore);
        });
        GameManager.manager.HighScores.Reverse();
        }
    
}
