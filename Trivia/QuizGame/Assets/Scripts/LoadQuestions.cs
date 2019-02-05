using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class LoadQuestions {
    public TextAsset csvFile;
    int i = 0;    


    public static StreamReader LoadQuestion()
    {
        Debug.Log("Start of Log");
        string path = "Assets/Questions/trivia.csv";

        if(path == null)
        {
            Debug.Log("Trivia.CSV not found");
        }
        else
        if(path != null)
        {
            Debug.Log("Trivia.CSV file found.");
        }
        var _question = new List<string>();
        var _answerA = new List<string>();
        var _answerB = new List<string>();
        var _answerC = new List<string>();
        var _answerD = new List<string>();
        var _correct = new List<string>();
        var _value = new List<string>();
        var _category = new List<string>();

        StreamReader sr = new StreamReader(path);
        return sr;
        /*using (StreamReader sr = new StreamReader(path))
        {
            /*while(! sr.EndOfStream)
            {
               var split = sr.ReadLine().Split(',');
               _question.Add(split[0]);
               _answerA.Add(split[1]);
               _answerB.Add(split[2]);
               _answerC.Add(split[3]);
               _answerD.Add(split[4]);
               _correct.Add(split[5]);
               _value.Add(split[6]);
               _category.Add(split[7]);
            }
       
            return sr;
      }
      */
        
    }
}
