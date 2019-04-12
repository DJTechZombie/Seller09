using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    private float frogSizeMult;
    private float carSizeMult;
    private float carSpeedMult;
    private float spawnSpeedMult;

    public Slider livesSlider;
    public Slider carSizeSlider;
    public Slider frogSizeSlider;
    public Slider carSpeedSlider;
    public Slider spawnSpeedSlider;
    public Text lifeDisplay;

    public void SetCarSpeed()
    {
        switch (carSpeedSlider.value)
        {
            case 3:
                carSpeedMult = 1;
                break;
            case 2:
                carSpeedMult = 0.66f;
                break;
            case 1:
                carSpeedMult = 0.33f;
                break;
        }

        GameManager.manager.carSpeed = carSpeedMult;
    }

    public void SetLives()
    {
        GameManager.manager.maxLives = livesSlider.value;
        lifeDisplay.text = livesSlider.value.ToString();
    }

    public void SetCarSize()
    {
        switch(carSizeSlider.value)
        {
            case 3: carSizeMult = 1;
                break;
            case 2: carSizeMult = 0.66f;
                break;
            case 1:  carSizeMult = 0.33f;
                break;
        }
        GameManager.manager.carSize = carSizeMult;
    }

    public void SetFrogSize()
    {
        switch (frogSizeSlider.value)
        {
            case 3:
                frogSizeMult = 1;
                break;
            case 2:
                frogSizeMult = 0.66f;
                break;
            case 1:
                frogSizeMult = 0.33f;
                break;
        }

        GameManager.manager.frogSize = frogSizeMult;
    }

    public void SetSpawnSpeed()
    {
        switch (spawnSpeedSlider.value)
        {
            case 3:
                spawnSpeedMult = 1;
                break;
            case 2:
                spawnSpeedMult = 1.5f;
                break;
            case 1:
                spawnSpeedMult = 2f;
                break;
        }

        GameManager.manager.spawnSpeed = spawnSpeedMult;
    }
    
}
