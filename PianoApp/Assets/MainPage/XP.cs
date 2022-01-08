using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=z0WpUwkvkOM

public class XP : MonoBehaviour
{
	private float xpPerLvl = 20; //should increase as the player levels up

    DB pianoDB;

    public Image XPBar;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();   
    	//xpPerLvl = 20;
        showXP();
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

    public void showXP(){
        XPBar.fillAmount = (float)pianoDB.getUserXP(Login.currentUsername)/xpPerLvl;
    }
}
