using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Streak : MonoBehaviour
{
	DB pianoDB;

	public Text streak;

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
    	streak.text = "5";
        //streak.text = Convert.ToString(pianoDB.getUserStreak(Login.currentUsername));
    }
}
