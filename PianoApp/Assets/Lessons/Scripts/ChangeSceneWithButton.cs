using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
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
	
	public void LoadScene(string SceneName){
        if(SceneName == "MainPage"){
            //some delay should be added here so we can hear the last sound
            pianoDB.addXP(Login.currentUsername, 5);
        }
		SceneManager.LoadScene(SceneName);
	}
}
