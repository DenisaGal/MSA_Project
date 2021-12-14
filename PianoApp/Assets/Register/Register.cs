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
	PopUp pop;
	//EncryptPassword hashPassword;

    // Start is called before the first frame update
    void Start()
    {
    	pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
        pianoDB.CreatePianoDB();

        pop = GameObject.FindGameObjectWithTag("PopUpSystem").GetComponent<PopUp>();

        //hashPassword = GameObject.FindGameObjectWithTag("Encrypt").GetComponent<EncryptPassword>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterUser(){
    	if(checkConstraints()){
	    	if(string.Equals(password.text, confirmPassword.text)){
	    		pianoDB.AddUser(pianoDB.getLastUserID() + 1, email.text, username.text, EncryptPassword.HashString(password.text));
	    		Debug.Log("User added.\n");
	    	}
	    	else{
	    		pop.popUp("Passwords did not match!\nPlease try again.");
	    		//Debug.Log("Passwords did not match!"); //should be a pop up
	    	}
    	}
    }

    public bool checkConstraints(){
    	//checks for email
    	if(string.IsNullOrEmpty(email.text)){
    		//Debug.Log("Email address field is mandatory.\n"); //should be a pop up
    		pop.popUp("Email address field is mandatory.");

    		return false;
    	}
    	//is there any better way to do this???? how to check if email address is valid?
    	else if(!email.text.Contains("@") || !email.text.Contains(".")){
    		//Debug.Log("Please enter a valid email address.\n"); //should be a pop up
			pop.popUp("Please enter a valid email address.");

    		return false;
    	}
    	else if(pianoDB.isEmailAlreadyUsed(email.text)){
    		//Debug.Log("An account with this email address already exists.\n"); //should be a pop up
			pop.popUp("An account with this email address already exists.");
    		
    		return false;
    	}

    	//checks for username
    	if(string.IsNullOrEmpty(username.text)){
    		//Debug.Log("Username field is mandatory.\n"); //should be a pop up
			pop.popUp("Username field is mandatory.");
    		
    		return false;
    	}
    	else if(pianoDB.isUsernameAlreadyUsed(username.text)){
    		//Debug.Log("An account with this username already exists.\n"); //should be a pop up
			pop.popUp("An account with this username already exists.");
    		
    		return false;
    	}

    	//checks for password
    	if(string.IsNullOrEmpty(password.text)){
    		//Debug.Log("Password field is mandatory.\n"); //should be a pop up
			pop.popUp("Password field is mandatory.");
    		
    		return false;
    	}
    	if(string.IsNullOrEmpty(confirmPassword.text)){
    		//Debug.Log("Confirm password field is mandatory.\n"); //should be a pop up
			pop.popUp("Confirm password field is mandatory.");
    		
    		return false;
    	}

    	//if it got here => all is good
    	return true;
    }
}
