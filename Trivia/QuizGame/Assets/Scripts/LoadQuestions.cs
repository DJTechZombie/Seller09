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
        string path = "Assets/Questions/Spanish.csv";

        if (path == null)
        {
            Debug.Log("Trivia.CSV not found");
        }
        /*else
          if(path != null)
              {
                  Debug.Log("Trivia.CSV file found.");
            }
            */
            var _question = new List<string>();
            var _answerA = new List<string>();
            var _answerB = new List<string>();
            var _answerC = new List<string>();
            var _answerD = new List<string>();
            var _correct = new List<string>();
            var _value = new List<string>();
            var _category = new List<string>();

            StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF7);
            return sr;
        
        
    }
}
