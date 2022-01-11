using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//source https://www.youtube.com/watch?v=WX-5NQHmhVc

public class LessonController : MonoBehaviour
{
	[SerializeField]
	private Button[] lessons;

    [SerializeField]
    private Button[] lessonsLocks;

    //private Button piano;
    [SerializeField]
    private Button pianoLock;

	DB pianoDB;
    XP xpController;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
        xpController = GameObject.FindGameObjectWithTag("PXP").GetComponent<XP>();

        InitializeLessons();
        LoadLessons();
        unlockPiano();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadLessons(){
    	for(int i = 0; i < lessons.Length; i++){
    		if(i >= pianoDB.getNumberOfLessons()){
    			lessons[i].gameObject.SetActive(false);
                lessonsLocks[i].gameObject.SetActive(false);
    			continue;
    		}

    		lessons[i].gameObject.SetActive(true);
    		lessons[i].GetComponentInChildren<Text>().text = pianoDB.getLessonNameByID(i).Replace("Scene", "");
            lessonsLocks[i].gameObject.SetActive(xpController.lockLesson(i));
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
    	SceneManager.LoadScene(pianoDB.getLessonNameByID(lessonIndex));
    }

    private void unlockPiano(){
        pianoLock.gameObject.SetActive(xpController.lockPiano());
    }

    public void randomSong(){
        //add more songs and assign a random one
        SceneManager.LoadScene("Song1Scene");
        pianoDB.addXP(Login.currentUsername, 5); //for testing purposes; user should get xp for this, but based on how well he played
    }
}
