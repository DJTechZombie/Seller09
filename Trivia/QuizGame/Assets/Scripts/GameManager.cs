//Jeremy Sellers
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text answerAtext;
    [SerializeField]
    private Text answerBtext;
    [SerializeField]
    private Text answerCtext;
    [SerializeField]
    private Text answerDtext;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    private Text trueAnswerText;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    static int score;

    [SerializeField]
    public Text scoreText;

    [SerializeField]
    public Text finalScoreText;

    [SerializeField]
    private static int correctAnswers;

    [SerializeField]
    private Text correctAnswersText;

    [SerializeField]
    private static int numAnswers;

    [SerializeField]
    private Text numQuestionsText;

    [SerializeField]
    private Text timeLeftText;

    [SerializeField]
    private static int i = 1;

    [SerializeField]
    private float timeLeft = 10.0f;

    [SerializeField]
    private Text categoryText;


    [SerializeField]
    private bool canCount;

    public AudioSource correctFX;
    public AudioSource wrongFX;

    int j = 1;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Main")
        {
            canCount = true;
            var Line = LoadQuestions.LoadQuestion();
            List<string> strContent = new List<string>();
            while (!Line.EndOfStream)
            {
                strContent.Add(Line.ReadLine());
            }
            while (j < 11)
            {
                var split = strContent[j].Split(',');
                questions[j - 1] = new Question(split);
                j++;
            }
        }
        else
        {
            canCount = false;
        }

            clearText();
        //Load questions to Unanswered Questions List
       if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
            score = 0;
            scoreText.text = "Score: 0000";
        }
        numAnswers = questions.Length;
        numQuestionsText.text = "Question: " + i.ToString() + " of " + numAnswers.ToString();

        SetCurrentQuestion();
        Debug.Log(currentQuestion.fact);
        Debug.Log(currentQuestion.correctAnswer);
        scoreText.text = "Score: " + score.ToString();

        timeLeft = 10.0f; //Set time limit for each question

    }
    private void Update()
    {
        //Countdown timer for each question
        if (timeLeft > 0.0f && canCount)
        {
            timeLeft = timeLeft - Time.deltaTime;
            timeLeftText.text = timeLeft.ToString("N0");
        }
        else if(!canCount)
        {

        }
        else

            StartCoroutine(TransitionToNextQuestion());
    }
    void SetCurrentQuestion ()
        {
            int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            factText.text = currentQuestion.fact;
            answerAtext.text = currentQuestion.answerA;
            answerBtext.text = currentQuestion.answerB;
            answerCtext.text = currentQuestion.answerC;
            answerDtext.text = currentQuestion.answerD;
            categoryText.text = currentQuestion.category;

        }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        scoreText.text = "Score: " + score.ToString();

        yield return new WaitForSeconds(timeBetweenQuestions);

        if (unansweredQuestions.Count > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("END");
            clearText();
        }
    }
    

    // Select Answer
    // Optimally, get name of selected answer and use a switch instead of 4 different methods
    // get selected object is not working with MaterialUI buttons. Research work around or use unity UI buttons instead

   public void UserSelectA ()
    {
        
        if(currentQuestion.correctAnswer == "A")
        {
            score += 100;
            correctAnswers += 1;
            i += 1;
            animator.SetTrigger("Answered");
            trueAnswerText.text = "Correct";
            correctFX.Play();
        }
        else
        {
            animator.SetTrigger("Answered");
            trueAnswerText.text = "Incorrect";
            wrongFX.Play();
            i += 1;
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    
    public void UserSelectB()
    {
       
        if (currentQuestion.correctAnswer == "B")
        { 
            score += 100;
            correctAnswers += 1;
            i += 1;
            animator.SetTrigger("Answered");
            trueAnswerText.text = "Correct";
            correctFX.Play();
        }
        else
        {
            animator.SetTrigger("Answered");
            trueAnswerText.text = "Incorrect";
            wrongFX.Play();
            i += 1;
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectC()
    {
        
        if (currentQuestion.correctAnswer == "C")
        {
            score += 100;
            correctAnswers += 1;
            i += 1;
            animator.SetTrigger("Answered");
            trueAnswerText.text = "Correct";
            correctFX.Play();
        }
        else
        {
            animator.SetTrigger("Answered");
            trueAnswerText.text = "Incorrect";
            wrongFX.Play();
            i += 1;
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectD()
    {
        
        if (currentQuestion.correctAnswer == "D")
        {
            score += 100;
            correctAnswers += 1;
            i += 1;
            animator.SetTrigger("Answered");
            trueAnswerText.text = "Correct";
            correctFX.Play();
        }
        else
        {
            animator.SetTrigger("Answered");
            trueAnswerText.text = "Incorrect";
            wrongFX.Play();
            i += 1;
        }
        StartCoroutine(TransitionToNextQuestion());
    }


    // Clear text fields and instantiate score
    public void clearText()
    {
        finalScoreText.text = "FinalScore: " + score.ToString();
        correctAnswersText.text = "Answers Correct: " + correctAnswers.ToString() + "/" + numAnswers.ToString();
        trueAnswerText.text = "";
        factText.text = "";
        numQuestionsText.text = "";
    }


}
