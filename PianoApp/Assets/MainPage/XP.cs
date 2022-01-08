using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=z0WpUwkvkOM

public class XP : MonoBehaviour
{
	private int xpPerLevel; //should increase as the player levels up

    DB pianoDB;

    public Image XPBar;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();   
    	xpPerLevel = 15;
        showXP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool lockLesson(int lessonID){
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
    	//int totalUserXP = pianoDB.getUserXP(Login.currentUsername) + pianoDB.getUserLevel(Login.currentUsername) * xpPerLevel; 
    	if(pianoDB.getUserXP(Login.currentUsername) >= pianoDB.getLessonRequiredLevel(lessonID)){
    		return false;
    	}
    	return true;
    }

    public void showXP(){
        int userXP = pianoDB.getUserXP(Login.currentUsername);

        if(userXP >= xpPerLevel){
            pianoDB.levelUp(Login.currentUsername);
            userXP = userXP - xpPerLevel;
            //pianoDB.updateUserXP(Login.currentUsername);
        }

        XPBar.fillAmount = (float)userXP/xpPerLevel;

        
    }
}
