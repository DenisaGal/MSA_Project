using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//source https://www.youtube.com/watch?v=WX-5NQHmhVc

public class LessonController : MonoBehaviour
{
	[SerializeField]
	private Button[] lessons;

	DB pianoDB;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();

        InitializeLessons();
        LoadLessons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadLessons(){
    	for(int i = 0; i < lessons.Length; i++){
    		if(i >= pianoDB.getNumberOfLessons()){
    			lessons[i].gameObject.SetActive(false);
    			continue;
    		}

    		lessons[i].gameObject.SetActive(true);
    		lessons[i].GetComponentInChildren<Text>().text = pianoDB.getLessonNameByID(i);
    	}
    }

    private void InitializeLessons(){
    	for(int i = 0; i < lessons.Length; i++){
    		Button lesson = lessons[i];

    		int lessonIndex = i;
    		lesson.onClick.AddListener(() => GoToLesson(lessonIndex));
    	}
    }

    private void GoToLesson(int lessonIndex){
    	Debug.Log("To be implemented");
    	//this should redirect to the lesson with index lessonIndex
    	//!!!!!!!!!lessonName/title should be the name of the scene!!!!!!!!!
    }
}
