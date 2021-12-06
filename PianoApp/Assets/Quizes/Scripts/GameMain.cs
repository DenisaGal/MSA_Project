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
    [SerializeField] private string nextScene;
    
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
        correctAnswers = 0;
        yield return new WaitForSeconds(delay-0.5f);

        currentQuestion.displayedNote.SetActive(false);
        SceneManager.LoadScene(nextScene);
    }

    public void UserSelect(string userAnswer)
    {
        //correct answer
        if (userAnswer == currentQuestion.answer){
            result.text = "Correct!"; 
            //+5xp
            correctAnswers++;
            
            if(correctAnswers >= 5)
                StartCoroutine(TransitionToNextQuiz());
        }
        //wrong answer
        else{
            result.text = "Wrong :(";
            correctAnswers--;
        }
        
        if(correctAnswers < 5)
            StartCoroutine(TransitionToNextQuestion());
        
        //add colours green/red la raspunsuri si make stuff pretty
        //cum facem cu xp? cand primeste
    }
}
