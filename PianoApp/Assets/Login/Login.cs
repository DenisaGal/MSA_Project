using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
	public InputField username;
	public InputField password;

    DB pianoDB;
    PopUp pop;

    // Start is called before the first frame update
    void Start()
    {
        pianoDB = GameObject.FindGameObjectWithTag("PDB").GetComponent<DB>();
        pianoDB.CreatePianoDB();

        pop = GameObject.FindGameObjectWithTag("PopUpSystem").GetComponent<PopUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginUser(){
        if(pianoDB.isUsernameAlreadyUsed(username.text) && pianoDB.isPasswordCorrect(username.text, EncryptPassword.HashString(password.text))){
            SceneManager.LoadScene("Lesson1Scene"); //Should be main scene!!!! But we do not have it yet
        }
        else if(pianoDB.isUsernameAlreadyUsed(username.text) && !pianoDB.isPasswordCorrect(username.text, EncryptPassword.HashString(password.text))){
            pop.popUp("Wrong password!\nPlease try again.");
        }
        else if(!pianoDB.isUsernameAlreadyUsed(username.text)){
            pop.popUp("Wrong username!\nIf you have an account, please try again.\n");
        }
        else{
            //Did I forget any case? What should go here?
            pop.popUp("T_T");
        }
    }

    public void NewUser(){
        SceneManager.LoadScene("RegisterScene");
    }

    public void ForgotPassword(){
        //How should I implement this??????
        pop.popUp("To be implemented");
        //SceneManager.LoadScene("ForgotPasswordScene");//????????
    }
}
