using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIcontroller : MonoBehaviour
{
    [Header("Sliders")]
    public Slider FruitSize;
    public Slider BladeSize;
    public Slider LaunchSpeed;
    public Slider SpawnSpeed;
    public Slider Gravity;
    public Slider TimeLimit;

    public Dropdown fruitSelect;

    [Header("Slider Display Text")]
    public Text FruitSizeText;
    public Text BladeSizeText;
    public Text LaunchSpeedText;
    public Text SpawnSpeedText;
    public Text GravityText;
    public Text TimeLimitText;


    [Header("MISC")]
    public Toggle optionsToggle;

    public GameObject optionsPanel;

    public void DisplayOptionsPanel(bool _options)
    {
        optionsPanel.SetActive(_options);
    }
    #region ButtonMethods
    public void SetFruitSize()
    {
        switch (FruitSize.value)
        {
            case 2:
                GameManager.instance.fruitSizeMult = 1.5f;
                FruitSizeText.text = "150%";
                break;
            case 1:
                GameManager.instance.fruitSizeMult = 1;
                FruitSizeText.text = "100%";
                break;
            case 0:
                GameManager.instance.fruitSizeMult = 0.5f;
                FruitSizeText.text = "50%";
                break;
        }
    }

    public void SetBladeSize()
    {
        switch (BladeSize.value)
        {
            case 2:
                GameManager.instance.bladeSizeMult = 1.5f;
                BladeSizeText.text = "150%";
                break;
            case 1:
                GameManager.instance.bladeSizeMult = 1;
                BladeSizeText.text = "100%";
                break;
            case 0:
                GameManager.instance.bladeSizeMult = 0.5f;
                BladeSizeText.text = "50%";
                break;
        }
    }

    public void SetSpawnSpeed()
    {
        switch (SpawnSpeed.value)
        {
            case 2:
                GameManager.instance.SpawnSpeedMult = 1.5f;
                SpawnSpeedText.text = "150%";
                break;
            case 1:
                GameManager.instance.SpawnSpeedMult = 1;
                SpawnSpeedText.text = "100%";
                break;
            case 0:
                GameManager.instance.SpawnSpeedMult = 0.5f;
                SpawnSpeedText.text = "50%";
                break;
        }
    }

    public void SetGravity()
    {
        switch (Gravity.value)
        {
            case 2:
                GameManager.instance.gravityScaleMult = 1.5f;
                GravityText.text = "150%";
                break;
            case 1:
                GameManager.instance.gravityScaleMult = 1;
                GravityText.text = "100%";
                break;
            case 0:
                GameManager.instance.gravityScaleMult = 0.5f;
                GravityText.text = "50%";
                break;
        }
    }

    public void SetLaunchSpeed()
    {
        switch (LaunchSpeed.value)
        {
            case 2:
                GameManager.instance.fruitSpeedMult = 1.5f;
                LaunchSpeedText.text = "150%";
                break;
            case 1:
                GameManager.instance.fruitSpeedMult = 1;
                LaunchSpeedText.text = "100%";
                break;
            case 0:
                GameManager.instance.fruitSpeedMult = 0.5f;
                LaunchSpeedText.text = "50%";
                break;
        }
    }

    public void SetTimeLimit()
    {
        switch (TimeLimit.value)
        {
            case 2:
                GameManager.instance.timeLimitMult = 2f;
                TimeLimitText.text = "2:00";
                break;
            case 1:
                GameManager.instance.timeLimitMult = 1;
                TimeLimitText.text = "1:00";
                break;
            case 0:
                GameManager.instance.timeLimitMult = 0.5f;
                TimeLimitText.text = "0:30";
                break;
        }
    }

    public void SetFruitSelection()
    {
        GameManager.instance.fruitSelection = fruitSelect.value;

    }

    public void StartGame()
    {

        GameManager.instance.LoadNextLevel();
    }

    #endregion
}
