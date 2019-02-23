using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;



public class WordGenerator : MonoBehaviour {

    public static WordGenerator wordGenerator;

    //public static string[] wordList;
    public static List<string> words;

    public static int currentWordIndex = 0;

        
    public static void LoadPhrases()
    {
        Debug.Log("Loading Phrases");
        string path = Application.dataPath + "/StreamingAssets/phrases.txt";

        if (path == null)
        {
            Debug.Log(path + " not found");
        }
        else
        {
            Debug.Log("reading " + path);

            var myFile = Resources.Load("Phrases", typeof(TextAsset)) as TextAsset;
            //var textFile = Application.dataPath + "/StreamingAssets/Phrases.txt";
            //wordList = myFile.text.Split('\n');
            words = myFile.text.Split('\n').ToList();

            for(int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].Trim();
                words[i] = words[i].Replace('\n', ' ');
                if(words[i] == " ")  
                { words.RemoveAt(i);    //NOT WORKING
                    i--;
                }
            }
            
            /*

            for(int i = 0; i<wordList.Length;i++)
            {
                wordList[i] = wordList[i].Trim();
                wordList[i] = wordList[i].Replace('\n',' ');
                if(wordList[i] == "hello hello")
                {
                    wordList[i] = null;
                }
            }
            */
        }
    }

    public static string GetNextWord()
    {
        if (currentWordIndex <= words.Count)
        {
            string nextword = words[currentWordIndex];
            currentWordIndex += 1;
            return nextword;
        }
        else
        {
            Time.timeScale = 0;
            InterfaceController.uiController.DisplayWin();
            
            return null;
        }
               
        
        
    }


public static string GetRandomWord()
    {
        Debug.Log("Trying to get random word");
     
        int randomIndex = Random.Range(0, words.Count);
        string randomWord = "";
     
        randomWord = words[randomIndex];
        return randomWord;
    }
}
