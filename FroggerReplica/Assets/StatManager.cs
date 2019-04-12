using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public Text statText;
    
    // Start is called before the first frame update
    void Start()
    {
        statText.text = "Stats" + '\n' + '\n' + "Total Score: " + GameManager.manager.score + '\n' + '\n' +
            "Levels Cleared: " + GameManager.manager.levelsCleared + '\n' + '\n' +
            "Flies Eaten: " + GameManager.manager.fliesEaten;
    }


}

