using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class CreditLoader : MonoBehaviour
{
    public Text creditText;
    private string dataPath = Application.streamingAssetsPath;
    private void Start()
    {
        ReadCredits();
    }

    public void ReadCredits()
    {
        StreamReader sr = new StreamReader(dataPath + "/Credits.txt");

        creditText.text = sr.ReadToEnd();
        sr.Close();
    }
}
