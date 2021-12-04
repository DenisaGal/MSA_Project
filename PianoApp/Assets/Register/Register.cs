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
    public void RegisterUser(){
    	if(string.Equals(password.text, confirmPassword.text)){
    		pianoDB.AddUser(pianoDB.getLastUserID() + 1, email.text, username.text, EncryptPassword.HashString(password.text));
    		Debug.Log("User added.\n");
    	}
    	else{
    		Debug.Log("Passwords did not match!");
    	}
    }
}
