//Jeremy Sellers
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question[] finalQuestions = new Question[10];

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
    private Text falseAnswerText;

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
    private string selectedCategory;

    [SerializeField]
    private bool canCount;

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
            while (j < 21)
            {
                var split = strContent[j].Split(',');
                questions[j - 1] = new Question(split);
                j++;
            }

        
        
       clearText();
        //Load questions to Unanswered Questions List
       if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            //finalQuestions = questions.Where(question=> question.category != selectedCategory).ToArray();
            //unansweredQuestions = finalQuestions.ToList<Question>();
            unansweredQuestions = questions.ToList<Question>();
            score = 0;
            scoreText.text = "Score: 0000";
        }
        numAnswers = finalQuestions.Length;
        numQuestionsText.text = "Question: " + i.ToString() + " of " + numAnswers.ToString();

        SetCurrentQuestion();
        scoreText.text = "Score: " + score.ToString();

        timeLeft = 10.0f;
            //Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
        }
        else
        {
            canCount = false;
        }

    }
    private void Update()
    {
        
        if (timeLeft > 0.0f && canCount)
        {
            timeLeft = timeLeft - Time.deltaTime;
            timeLeftText.text = timeLeft.ToString("N0");
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

        /*       if(currentQuestion.isTrue)
               {
                   trueAnswerText.text = "CORRECT";
                   falseAnswerText.text = "WRONG";
               }else
               {
               trueAnswerText.text = "WRONG";
               falseAnswerText.text = "CORRECT";
               }
               */
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
    
   public void UserSelectA ()
    {
        //animator.SetTrigger("True");
        if(currentQuestion.correctAnswer == "A")
        {
            //Debug.Log("CORRECT!");
            score += 100;
            correctAnswers += 1;
            i += 1;
        }
        else
        {
            //Debug.Log("WRONG!");
            i += 1;
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    
    public void UserSelectB()
    {
       // animator.SetTrigger("False");
        if (currentQuestion.correctAnswer == "B")
        { 
            //Debug.Log("CORRECT!");
            score += 100;
            correctAnswers += 1;
            i += 1;
        }
        else
        {
            //Debug.Log("WRONG!");
            i += 1;
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectC()
    {
        // animator.SetTrigger("False");
        if (currentQuestion.correctAnswer == "C")
        {
            //Debug.Log("CORRECT!");
            score += 100;
            correctAnswers += 1;
            i += 1;
        }
        else
        {
            //Debug.Log("WRONG!");
            i += 1;
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectD()
    {
        // animator.SetTrigger("False");
        if (currentQuestion.correctAnswer == "D")
        {
            //Debug.Log("CORRECT!");
            score += 100;
            correctAnswers += 1;
            i += 1;
        }
        else
        {
            //Debug.Log("WRONG!");
            i += 1;
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void clearText()
    {
        finalScoreText.text = "FinalScore: " + score.ToString();
        correctAnswersText.text = "Answers Correct: " + correctAnswers.ToString() + "/" + numAnswers.ToString();
        trueAnswerText.text = "";
        falseAnswerText.text = "";
        factText.text = "";
        numQuestionsText.text = "";
    }


}
