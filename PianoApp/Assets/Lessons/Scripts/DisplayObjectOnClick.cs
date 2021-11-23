using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayObjectOnClick : MonoBehaviour
{
	public GameObject Note, previousNote;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void DisplayNote(){
		bool isActive = previousNote.activeSelf;
		if( Note != null && isActive == true){
			Note.SetActive(true);			
		}
	}
}
