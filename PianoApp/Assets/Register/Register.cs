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
	public static int id = 1;

	DB pianoDB;

    // Start is called before the first frame update
    /*void Start()
    {
        pianoDB.CreateDB();
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    //!!!!!!!!DO NOT FORGET TO HASH PWD!!!!!!!!
    public void RegisterUser(){//(string email, string username, string password, string confirmPassword){
    	/*if(password== confirmPassword){
    		pianoDB.AddUser(1, email, username, password);
    		//this.id += 1;
    	}
    	else{
    		Debug.Log("Passwords did not match!");
    	}*/
    	Debug.Log("Works!" + email.text + " " + username.text + "" + password.text + " " + confirmPassword.text + " ^^.\n");
    }
}
