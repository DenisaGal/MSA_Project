using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//https://www.youtube.com/watch?v=z0WpUwkvkOM

public class XP : MonoBehaviour
{
	private int xpPerLevel = 20; //should increase as the player levels up

    DB pianoDB;

    public Image XPBar;
    public Text level;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();   
    	//xpPerLevel = 20;
        showXP();
        showLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool lockLesson(int lessonID){
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
    	int totalUserXP = pianoDB.getUserXP(Login.currentUsername) + (pianoDB.getUserLevel(Login.currentUsername) - 1) * xpPerLevel;
    	if(totalUserXP >= pianoDB.getLessonRequiredLevel(lessonID)){
    		return false;
    	}
    	return true;
    }

    public bool lockPiano(){
        if(pianoDB.getUserLevel(Login.currentUsername) == 1 && pianoDB.getUserXP(Login.currentUsername) == 5){
            return true;
        }
        return false;
    }

    public void showXP(){
        int userXP = pianoDB.getUserXP(Login.currentUsername);

        if(userXP >= xpPerLevel){
            pianoDB.levelUp(Login.currentUsername);
            userXP = userXP - xpPerLevel;
            pianoDB.updateXP(Login.currentUsername, userXP);
        }

        XPBar.fillAmount = (float)userXP/xpPerLevel;
 
    }

    public void showLevel(){
        level.text = Convert.ToString(pianoDB.getUserLevel(Login.currentUsername)) + " lvl";
    }
}
