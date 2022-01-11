using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    DB pianoDB;

    public string lessonTitle;

    // Start is called before the first frame update
    void Start()
    {
        pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
        lessonTitle = SceneManager.GetActiveScene().name;
        if(lessonTitle.Contains("Lesson")){
            lessonTitle = lessonTitle.Substring(0, 7);
            lessonTitle = lessonTitle + "Scene";
        }
        else if(lessonTitle.Contains("Quiz")){
            lessonTitle = lessonTitle.Substring(0, 5);
            lessonTitle = lessonTitle + "Scene";
        }
        //Debug.Log(lessonTitle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void LoadScene(string SceneName){
        if(SceneName == "MainPage"){
            pianoDB.addXP(Login.currentUsername, pianoDB.getLessonMaxXP(lessonTitle));
        }
		SceneManager.LoadScene(SceneName);
	}

    public void GoToNextScene(string SceneName){
        pianoDB.addXP(Login.currentUsername, pianoDB.getLessonMaxXP(lessonTitle));
        SceneManager.LoadScene(SceneName);
    }
}
