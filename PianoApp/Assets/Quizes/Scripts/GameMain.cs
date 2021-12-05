using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameMain : MonoBehaviour
{
    public Question[] questions;
    private Question currentQuestion;
    public Text result;
    void Start()
    {
        GetRandomQuestion();
        //Debug.Log(currentQuestion.answer);
    }

    void GetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questions.Length);
        currentQuestion = questions[randomQuestionIndex];
        currentQuestion.displayedNote.SetActive(true);
    }

    public void UserSelect(string userAnswer)
    {
        if (userAnswer == currentQuestion.answer)
            result.text = "Correct!"; //should get xp here ? or at the end
        else result.text = "Wrong :(";
    }
}
