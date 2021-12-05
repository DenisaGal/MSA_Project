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
    [SerializeField] private float delay = 2f;
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

    public void UserSelect(string userAnswer)
    {

        if (userAnswer == currentQuestion.answer)
            result.text = "Correct!"; //should get xp here ? or at the end
        else result.text = "Wrong :(";

        StartCoroutine(TransitionToNextQuestion());
        
        //add colours green/red la raspunsuri
        //cum facem cu xp? cand primeste
    }
}
