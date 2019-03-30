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

    private bool isPaused = false;

    private void Awake() //singleton design
    {


        if (!File.Exists(Application.persistentDataPath + "/scores.dat"))
        {
            InitializeScores();
            Debug.Log(Application.persistentDataPath + "/scores.dat created");
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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/scores.dat");

        List<Scores> _scores = new List<Scores>();
        _scores.Add(new Scores("SUE", 1000));
        _scores.Add(new Scores("BOB", 800));
        _scores.Add(new Scores("JOE", 600));
        _scores.Add(new Scores("JAN", 400));
        _scores.Add(new Scores("MOE", 200));

        bf.Serialize(file, _scores);
        file.Close();
    }


    public void SaveScores()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/scores.dat");

        List<Scores> _scores = new List<Scores>();
        _scores = HighScores;
        bf.Serialize(file, _scores);
        file.Close();
    }

    public void LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + "/scores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/scores.dat", FileMode.Open);
            List<Scores> _scores = (List<Scores>)bf.Deserialize(file);
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
}

[Serializable]
public class Scores //: IComparable<Scores>
{
    public string playerInitials;
    public int  finalScore;
    public Scores(string _init, int _score)
    {
        playerInitials = _init;
        finalScore = _score;
    }
}

[Serializable]
public class ScoreList
{
    public List<Scores> highScores = new List<Scores>();
}

