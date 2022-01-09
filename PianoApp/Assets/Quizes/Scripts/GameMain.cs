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
    [SerializeField] private float delay = 2f;
    [SerializeField] private string nextScene;

	DB pianoDB;
    
    void Start()
    {
		pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();

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

		//quiz is completed and u get xp
		if(nextScene == "MainPage")
			pianoDB.addXP(Login.currentUsername, 10); //maxXp?

        SceneManager.LoadScene(nextScene);
    }

    public void UserSelect(string userAnswer)
    {
        //correct answer
        if (userAnswer == currentQuestion.answer){
            result.text = "Correct!"; 
			
            correctAnswers++;
            
            var button = GameObject.FindGameObjectWithTag(userAnswer).GetComponent<Button>();
            button.GetComponent<Image>().color = Color.green;

            if(correctAnswers >= 5)
                StartCoroutine(TransitionToNextQuiz());
        }
        //wrong answer
        else{
            result.text = "Wrong :(";
            correctAnswers--;
            
            var button = GameObject.FindGameObjectWithTag(userAnswer).GetComponent<Button>();
            button.GetComponent<Image>().color = Color.red;
        }
        
        if(correctAnswers < 5)
            StartCoroutine(TransitionToNextQuestion());
        
        //add colours green/red la raspunsuri si make stuff pretty
        //cum facem cu xp? cand primeste
    }
}
