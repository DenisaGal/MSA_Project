using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=z0WpUwkvkOM

public class XP : MonoBehaviour
{
	private int xpPerLvl; //should increase as the player levels up

    DB pianoDB;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();   
    	xpPerLvl = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool lockLesson(int lessonID){
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
    	//need to figure out how to get the total user xp taking into account the level as well
    	if(pianoDB.getUserXP(Login.currentUsername) >= pianoDB.getLessonRequiredLevel(lessonID)){
    		return false;
    	}
    	return true;
    }
}
