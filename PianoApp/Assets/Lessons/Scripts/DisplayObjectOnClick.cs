using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayObjectOnClick : MonoBehaviour
{
	PopUp pop;

	public GameObject Note, previousNote;
	
    // Start is called before the first frame update
    void Start()
    {
        pop = GameObject.FindGameObjectWithTag("PopUpSystem").GetComponent<PopUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void DisplayNote(){
		bool isActive = previousNote.activeSelf;
		if( Note != null && isActive == true){
			Note.SetActive(true);
			Debug.Log(previousNote.name + " si " + Note.name);
			if((previousNote.name == "LaFill") && (Note.name == "SiFill")){
				pop.popUpYesNo("Good job!\nAre you ready for a quiz?");//feel free to change this text to whatever you were thinking of
			}			
		}
	}
}
