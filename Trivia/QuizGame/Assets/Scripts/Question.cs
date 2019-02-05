//Jeremy Sellers
//Game Programing

[System.Serializable]

public class Question {

    public string fact;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public string value;
    public string correctAnswer;
    public string category;


    public Question (string[] inStream)
    {
        //string[] inStream = _questions.Split(',');
        this.fact = inStream[0];
        this.answerA = inStream[1];
        this.answerB = inStream[2];
        this.answerC = inStream[3];
        this.answerD = inStream[4];
        this.correctAnswer = inStream[5];
        this.value = inStream[6];
        this.category = inStream[7];
    }
}
