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
	//EncryptPassword hashPassword;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
        pianoDB.CreatePianoDB();

        //hashPassword = GameObject.FindGameObjectWithTag("Encrypt").GetComponent<EncryptPassword>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //!!!!!!!!DO NOT FORGET TO HANDLE CONSTRAINT VIOLATIONS VIA POP UPS!!!!!!!!
    //!!!!!!!!CHECK IF EMAIL ADDRESS SEEMS VALID!!!!!!!!
    public void RegisterUser(){
    	if(checkConstraints()){
			Debug.Log("Please try again.\n"); //should be a pop up?
			//reset the values of the input fields?
    	}
    	else if(string.Equals(password.text, confirmPassword.text)){
    		pianoDB.AddUser(pianoDB.getLastUserID() + 1, email.text, username.text, EncryptPassword.HashString(password.text));
    		Debug.Log("User added.\n");
    	}
    	else{
    		Debug.Log("Passwords did not match!"); //should be a pop up
    	}
    }

    public bool checkConstraints(){
    	//checks for email
    	if(String.IsNullOrEmpty(email.text)){
    		Debug.Log("Email address field is mandatory.\n"); //should be a pop up
    		return true;
    	}
    	else if(pianoDB.isEmailAlreadyUsed(email.text)){
    		Debug.Log("An account with this email address already exists.\n"); //should be a pop up
    		return true;
    	}

    	//checks for username
    	if(String.IsNullOrEmpty(username.text)){
    		Debug.Log("Username field is mandatory.\n"); //should be a pop up
    		return true;
    	}
    	else if(pianoDB.isUsernameAlreadyUsed(username.text)){
    		Debug.Log("An account with this username already exists.\n"); //should be a pop up
    		return true;
    	}

    	//checks for password
    	if(String.IsNullOrEmpty(password.text)){
    		Debug.Log("Password field is mandatory.\n"); //should be a pop up
    		return true;
    	}
    	if(String.IsNullOrEmpty(confirmPassword.text)){
    		Debug.Log("Confirm password field is mandatory.\n"); //should be a pop up
    		return true;
    	}

    	//if it got here => all is good
    	return false;
    }
}
