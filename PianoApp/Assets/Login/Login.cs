using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
	public InputField username;
	public InputField password;

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
}
