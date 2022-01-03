using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=z0WpUwkvkOM

public class XP : MonoBehaviour
{
	public int xpPerLvl; //should increase as the player levels up

    DB pianoDB;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool unlockLesson(int lessonID){
    	/*if(pianoDB.getUserXP(userID) >= pianoDB.getLessonReqXP(lessonID)){
    		return true;
    	}*/
    	return false;
    }
}
