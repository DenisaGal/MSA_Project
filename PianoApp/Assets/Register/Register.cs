using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
	public InputField email;
	public InputField username;
	public InputField password;
	public InputField confirmPassword;

	DB pianoDB;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
        pianoDB.CreatePianoDB();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //!!!!!!!!DO NOT FORGET TO HASH PWD!!!!!!!!
    //!!!!!!!!DO NOT FORGET TO HANDLE CONSTRAINT VIOLATIONS VIA POP UPS!!!!!!!!
    public void RegisterUser(){//(string email, string username, string password, string confirmPassword){
    	if(string.Equals(password.text, confirmPassword.text)){
    		pianoDB.AddUser(pianoDB.getLastUserID() + 1, email.text, username.text, password.text);
    		Debug.Log("User added.\n");
    	}
    	else{
    		Debug.Log("Passwords did not match!");
    	}
    }
}
