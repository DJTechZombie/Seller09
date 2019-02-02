//Jeremy Sellers
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

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
    private static int i = 1;

    void Start()
    {
        clearText();
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
            score = 0;
            scoreText.text = "Score: 0000";
        }
        numAnswers = questions.Length;
        numQuestionsText.text = "Question: " + i.ToString() + " of " + numAnswers.ToString();

        SetCurrentQuestion();
        scoreText.text = "Score: " + score.ToString();
        
        //Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);

    }

    void SetCurrentQuestion ()
        {
            int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            factText.text = currentQuestion.fact;

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
    /*
   public void UserSelectTrue ()
    {
        animator.SetTrigger("True");
        if(currentQuestion.isTrue)
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
    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
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
*/
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
