using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordManager : MonoBehaviour {
    //public static WordManager wordManager;

    public List<Word> words;
    public GameObject heart1, heart2, heart3;

    public WordSpawner wordSpawner;

    [SerializeField]
    public static int lives = 3;
    public int myLives = 3;

    //[SerializeField]
    public int score = 0;
    [SerializeField]
    public Text scoreText;

    [SerializeField] public bool hasActiveWord;
    public Word activeWord;

    [SerializeField] public static int numWords = 0;

    public bool godMode = false;

    private void Start()
    {
        WordGenerator.LoadPhrases();
        //score = 0;
        lives = 3;
        myLives = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString("000");
        switch (lives)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
        
        }
        if (Input.GetKey(KeyCode.Tab))
        {
            hasActiveWord = false;
        }
        myLives = lives;
        if(myLives <=0)
        {
            if (godMode)
            {

            }
            else
            {
                Debug.Log("Game Over");
                //SceneManager.GetSceneByName("END");
                SceneManager.LoadScene("END");
            }
         
        }
    }

    public void AddWord()
    {
        if (numWords < 10)
        {

            Word word = new Word(WordGenerator.GetNextWord(), wordSpawner.SpawnWord());
            //Debug.Log(word.word);

            words.Add(word);
            numWords += 1;
        }
    }

    public void TypeLetter(char letter)
    {
        if(hasActiveWord)
        {
            //check if letter is next
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
                //remove from word
        }
        else
        {
            foreach(Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            numWords -= 1;
            score += 100;
        }

    }

    public void DestoryWord()
    {
        activeWord = null;
        words.Remove(activeWord);
        
        Destroy(gameObject);
    }

}
