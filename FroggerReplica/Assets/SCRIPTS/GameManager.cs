using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public string playerInit;
    public int lives = 3;
    public bool isDead = false;
    [SerializeField] public List<Scores> HighScores = new List<Scores>();

    public int score = 0;
    public int lifeScore = 0;
    public int fliesEaten = 0;
    public int levelsCleared = 0;

    private bool isPaused = false;


    [Header("Game Options")]
    public float frogSize = 1;
    public float carSize = 1;
    public float carSpeed = 1;
    public float maxLives = 3;
    public float spawnSpeed = 1;

    // Save to streaming Assets for Assignment
    private string dataPath = Application.streamingAssetsPath;

    private void Awake() //singleton design
    {

        // Save Scores file in build specific user data - Windows : C:\Users\USERNAME\AppData\LocalLow\DefaultCompany\FroggerReplica 
        /*
         if (!File.Exists(Application.persistentDataPath + "/scores.dat"))
        {
            InitializeScores();
            Debug.Log(Application.persistentDataPath + "/scores.dat created");
        }
        */
        // Save to streaming Assets for Assignment
        if (!File.Exists( dataPath + "/scores.txt"))
        {
            InitializeScores();
            Debug.Log(dataPath + "/scores.txt created");
        }


        LoadScores();

        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                GUI_Manager.guiMan.DisablePauseScreen();
                BGMcontroller.bgm.PlayMusic();
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                GUI_Manager.guiMan.EnablePauseScreen();
                BGMcontroller.bgm.StopMusic();
            }
        }
    }
    public void InitializeScores()
    {
        //BinaryFormatter bf = new BinaryFormatter(); // encode score data

        //FileStream file = File.Create(Application.persistentDataPath + "/scores.dat");   //Build Specific location

        List<Scores> _scores = new List<Scores>();
        _scores.Add(new Scores("SUE", 1000));
        _scores.Add(new Scores("BOB", 800));
        _scores.Add(new Scores("JOE", 600));
        _scores.Add(new Scores("JAN", 400));
        _scores.Add(new Scores("MOE", 200));

        //bf.Serialize(file, _scores); write file using BinaryFormatter

        StreamWriter sw = new StreamWriter(dataPath+"/Scores.txt");

        for (int i = 0; i < _scores.Count; i++)
        {
            sw.WriteLine(String.Join(",", _scores[i].playerName.ToString(), _scores[i].finalScore.ToString()));
        }
       
        sw.Close();
    }


    public void SaveScores()
    {
        //BinaryFormatter bf = new BinaryFormatter(); encode score data

        //FileStream file = File.Create(Application.persistentDataPath + "/scores.dat");

        List<Scores> _scores = new List<Scores>();
        _scores = HighScores;
        //bf.Serialize(file, _scores); write file using binary formater
        //file.Close();

        StreamWriter sw = new StreamWriter(dataPath + "/Scores.txt");  //StreamWriter Save

        for (int i = 0; i < _scores.Count; i++)
        {
            sw.WriteLine(String.Join(",", _scores[i].playerName.ToString(), _scores[i].finalScore.ToString()));
        }

        sw.Close();

    }

    public void LoadScores()
    {
        //if (File.Exists(Application.persistentDataPath + "/scores.dat"))
        if (File.Exists(dataPath + "/scores.txt"))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(Application.persistentDataPath + "/scores.dat", FileMode.Open);
            FileStream file = File.Open(dataPath + "/scores.txt", FileMode.Open);
            //  FIXME
            //List<Scores> _scores = (List<Scores>)bf.Deserialize(file);
            //List<Scores> _scores = (List<Scores>)bf.Deserialize(file); //read score from binary formatter
            StreamReader sr = new StreamReader(file);
            List<Scores> _scores = new List<Scores>();
            while(!sr.EndOfStream)
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
        for(int i =0; i <10; i++)
        {
            allScores += sr.ReadLine() + '\n';
        }
        sr.Close();
        file.Close();
        allScores = allScores.Replace(',', '\t');
        return allScores;
    }
}

[Serializable]
public class Scores //: IComparable<Scores>
{
    public string playerName;
    public int  finalScore;
    public Scores(string _init, int _score)
    {
        playerName = _init;
        finalScore = _score;
    }
}

[Serializable]
public class ScoreList
{
    public List<Scores> highScores = new List<Scores>();
}

