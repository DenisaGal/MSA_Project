using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Streak : MonoBehaviour
{
	DB pianoDB;

	public Text streak;
	public Image streakIcon;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>(); 
    	
        showStreak();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showStreak(){
        streak.text = Convert.ToString(pianoDB.getUserStreak(Login.currentUsername));

        if(!earnedXPToday(Login.currentUsername)){
        	streakIcon.GetComponent<Image>().color = new Color32(118,118,118,255);//grey out the streak icon if the user did not gain xp today
        }
    }

    //dummy function so we do not get errors
    public bool earnedXPToday(string username){
    	return false;
    }
}
