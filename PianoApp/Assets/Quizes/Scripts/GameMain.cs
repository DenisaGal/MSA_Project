//Thank you Brackeys <3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    public Question[] questions;
    private Question currentQuestion;
    public Text result;
    private static int correctAnswers = 0;
    [SerializeField] private float delay = 3f;
    
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

    IEnumerator TransitionToNextQuestion()
    {
        yield return new WaitForSeconds(delay);
        
        currentQuestion.displayedNote.SetActive(false);
        result.text = "";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    IEnumerator TransitionToNextQuiz()
    {
        result.text = "Good job!";
        yield return new WaitForSeconds(delay-0.5f);

        currentQuestion.displayedNote.SetActive(false);
        SceneManager.LoadScene("Quiz1.2Scene");
    }

    public void UserSelect(string userAnswer)
    {

        if (userAnswer == currentQuestion.answer){
            result.text = "Correct!"; 
            //+5xp
            correctAnswers++;
            if(correctAnswers >= 3)
                StartCoroutine(TransitionToNextQuiz());
        }
        else{
            result.text = "Wrong :(";
            correctAnswers--;
        }
        
        if(correctAnswers < 3)
            StartCoroutine(TransitionToNextQuestion());
        
        //add colours green/red la raspunsuri
        //cum facem cu xp? cand primeste
    }
}
