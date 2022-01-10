using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//https://www.youtube.com/watch?v=VaDhk2eOQXM

public class PopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void popUp(string text){
    	popUpBox.SetActive(true);
    	popUpText.text = text;
    	animator.SetTrigger("pop");
    }

    public void popUpYesNo(string text){
    	popUpBox.SetActive(true);
    	popUpText.text = text;
    	animator.SetTrigger("pop");
    }
}
