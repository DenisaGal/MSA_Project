using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//courtesy of https://www.sean-lloyd.com/post/hash-a-string/

public class EncryptPassword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     	//Debug.Log(HashString("anaaremere"));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Maybe add a !null salt?
    static string HashString(string text, string salt = "AnaAreMere"){
	    if (System.String.IsNullOrEmpty(text)){
	        return System.String.Empty;
	    }
	    
	    // Uses SHA256 to create the hash
	    using (var sha = new System.Security.Cryptography.SHA256Managed()){
	        // Convert the string to a byte array first, to be processed
	        byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
	        byte[] hashBytes = sha.ComputeHash(textBytes);
	        
	        // Convert back to a string, removing the '-' that BitConverter adds
	        string hash = System.BitConverter
	            .ToString(hashBytes)
	            .Replace("-", System.String.Empty);

	        return hash;
	    }
	}
}
