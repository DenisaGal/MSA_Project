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
	//public static int id = 1;

	DB pianoDB = new DB();

    // Start is called before the first frame update
    void Start()
    {
        pianoDB.CreatePianoDB();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //!!!!!!!!DO NOT FORGET TO HASH PWD!!!!!!!!
    public void RegisterUser(){//(string email, string username, string password, string confirmPassword){
    	//if(password == confirmPassword){
    		pianoDB.AddUser(2, email.text, username.text, password.text);
    		//this.id += 1;
    		Debug.Log("User added.\n");
    	/*}
    	else{
    		Debug.Log("Passwords did not match!");
    	}*/	
    }
}
