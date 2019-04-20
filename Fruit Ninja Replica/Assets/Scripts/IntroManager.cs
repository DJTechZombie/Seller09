using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public InputField playerNameInput;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = GameManager.instance.scoreManager.DisplayScores();
    }

    public void SetPlayerName()
    {
        GameManager.instance.playerName = playerNameInput.text;
    }

    public void LoadNextScene()
    {
        if (GameManager.instance.playerName == "")
        {
            GameManager.instance.playerName = "Anonymous";
        }
        GameManager.instance.LoadNextLevel();
    }
    public void MainTitle()
    {
        GameManager.instance.LoadTitleScreen();
    }
}
