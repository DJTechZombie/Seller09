//Jeremy Sellers
//Game Programing

[System.Serializable]

public class Question {

    public string fact;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public int value;
    public string correctAnswer;
    public string category;


    public Question (Question question)
    {
        fact = question.fact;
        answerA = question.answerA;
        answerB = question.answerB;
        answerC = question.answerC;
        answerD = question.answerD;
        correctAnswer = question.correctAnswer;
        value = question.value;
        category = question.category;
    }
}
