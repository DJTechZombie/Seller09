using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ScoreManager : MonoBehaviour
{
    private string dataPath = Application.streamingAssetsPath;

    [SerializeField] public List<Scores> HighScores = new List<Scores>();

    public void CheckForScores()
    {
        if (!File.Exists(dataPath + "/scores.txt"))
        {
            InitializeScores();
            Debug.Log(dataPath + "/scores.txt created");
        }


        LoadScores();
    }

    public void InitializeScores()
    {
        List<Scores> _scores = new List<Scores>();
        _scores.Add(new Scores("Chuck Norris", 999999999));
        _scores.Add(new Scores("Rocky", 500));
        _scores.Add(new Scores("Colt", 400));
        _scores.Add(new Scores("Tum Tum", 350));
        _scores.Add(new Scores("Donatello", 300));
        _scores.Add(new Scores("Michelangelo", 250));
        _scores.Add(new Scores("Raphael", 200));
        _scores.Add(new Scores("Leonardo", 150));
        _scores.Add(new Scores("Splinter", 50));
        _scores.Add(new Scores("Johnny", 25));

        StreamWriter sw = new StreamWriter(dataPath + "/Scores.txt");

        for (int i = 0; i < _scores.Count; i++)
        {
            sw.WriteLine(String.Join(",", _scores[i].playerName.ToString(), _scores[i].finalScore.ToString()));
        }

        sw.Close();
    }


    public void SaveScores()
    {
        List<Scores> _scores = new List<Scores>();
        _scores = HighScores;

        StreamWriter sw = new StreamWriter(dataPath + "/Scores.txt");  //StreamWriter Save

        for (int i = 0; i < _scores.Count; i++)
        {
            sw.WriteLine(String.Join(",", _scores[i].playerName.ToString(), _scores[i].finalScore.ToString()));
        }

        sw.Close();

    }

    public void LoadScores()
    {
        if (File.Exists(dataPath + "/scores.txt"))
        {
            FileStream file = File.Open(dataPath + "/scores.txt", FileMode.Open);
            StreamReader sr = new StreamReader(file);
            List<Scores> _scores = new List<Scores>();
            while (!sr.EndOfStream)
            {
                string inputString = sr.ReadLine();
                string[] elements = inputString.Split(',');
                string inName = elements[0];
                int inScore = Convert.ToInt32(elements[1]);
                Scores currentScore = new Scores(inName, inScore);
                _scores.Add(currentScore);
            }
            sr.Close();
            file.Close();

            HighScores = _scores;
        }
    }
    public void AddScore(string _init, int _score)
    {
        Scores score = new Scores(_init, _score);
        HighScores.Add(score);
        sortScores();
    }
    public static int SortByScore(Scores p1, Scores p2)
    {
        return p1.finalScore.CompareTo(p2.finalScore);
    }

    public string DisplayScores()
    {
        string allScores = "";
        FileStream file = File.Open(dataPath + "/scores.txt", FileMode.Open);
        StreamReader sr = new StreamReader(file);

        for (int i = 0; i < 10; i++)
        {
            allScores += i+1 + ". " + sr.ReadLine() + '\n';
        }
        sr.Close();
        file.Close();
        allScores = allScores.Replace(",", " : ");
        return allScores;
        
    }
    
    public void sortScores()
    {
        HighScores.Sort(delegate (Scores x, Scores y)
        {
            return x.finalScore.CompareTo(y.finalScore);
        });
        HighScores.Reverse();
        SaveScores();
    }

}

public class Scores //: IComparable<Scores>
{
    public string playerName;
    public int finalScore;
    public Scores(string _init, int _score)
    {
        playerName = _init;
        finalScore = _score;
    }
}

public class ScoreList
{
    public List<Scores> highScores = new List<Scores>();
}

