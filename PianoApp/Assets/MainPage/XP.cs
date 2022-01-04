using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=z0WpUwkvkOM

public class XP : MonoBehaviour
{
	private int xpPerLvl; //should increase as the player levels up

    DB pianoDB;
    Login currentUser;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();        
    	currentUser = GameObject.FindGameObjectWithTag("Login").GetComponent<Login>();
    	xpPerLvl = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool unlockLesson(int lessonID){
    	if(pianoDB.getUserXP(currentUser.getCurrentUserID()) >= pianoDB.getLessonRequiredLevel(lessonID)){
    		return true;
    	}
    	return false;
    }
}
