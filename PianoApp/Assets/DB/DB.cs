using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;


public class DB : MonoBehaviour{
	//private string dbName = "URI=file:" + Application.persistentDataPath + "/PianoDB.db";
	private string dbName = "URI=file:PianoDB.db";

    // Start is called before the first frame update
    void Start(){
    	CreatePianoDB();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void CreatePianoDB(){
    	using(var connectionToDB = new SqliteConnection(dbName)){
    		connectionToDB.Open();

    		using(var query = connectionToDB.CreateCommand()){
    			query.CommandText = "CREATE TABLE IF NOT EXISTS Users (userID INTEGER PRIMARY KEY UNIQUE NOT NULL, email STRING NOT NULL UNIQUE, username STRING UNIQUE NOT NULL, hashedPwd STRING NOT NULL, xp INTEGER DEFAULT (0), streak INTEGER DEFAULT (0), level INTEGER DEFAULT (0));";
    			query.ExecuteNonQuery();

    			query.CommandText = "CREATE TABLE IF NOT EXISTS PianoKey (keyID INTEGER PRIMARY KEY NOT NULL UNIQUE, note STRING  NOT NULL, tone STRING NOT NULL, sound BLOB NOT NULL, scale INTEGER NOT NULL);";
    			query.ExecuteNonQuery();

    			query.CommandText = "CREATE TABLE IF NOT EXISTS Lessons (lessonID INTEGER PRIMARY KEY NOT NULL UNIQUE, title STRING  NOT NULL, content BLOB    NOT NULL, requiredLevel INTEGER NOT NULL, maxXP INTEGER NOT NULL);";
    			query.ExecuteNonQuery();
    		}

    		connectionToDB.Close();
    	}
    }
}
