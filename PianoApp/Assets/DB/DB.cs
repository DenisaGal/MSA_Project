using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;


public class DB : MonoBehaviour{
    //private string dbName = "URI=file:" + Application.persistentDataPath + "/PianoDB.db";
    private string dbName = "URI=file:PianoDB.db";

    // Start is called before the first frame update
    void Start(){
        CreatePianoDB();

        //testing the fuctions below

        //A lot of field values have to be unique (see constraints). To avoid errors please check the db before uncommenting
        /*AddUser(0, "abc", "abc", "abc");
        AddLesson(0, "abc", 5, 5);
        AddPianoKey(0, "abc", "abc", 5);

        DisplayUsers();
        DisplayLessosns();
        DisplayPianoKeys();

        getUserByID(0);
        getLessosnByID(0);
        getPianoKeysByID(0);*/

        //comment this if you want to actually see the values in the db
        /*DeleteUser(0);
        DeleteLesson(0);
        DeletePianoKey(0);*/

        // Debug.Log("Last user ID: " + getLastUserID() + ".\n");
        // Debug.Log("Last lesson ID: " + getLastLessonID() + ".\n");
        // Debug.Log("Last key ID: " + getLastKeyID() + ".\n");

        // Debug.Log("Check username ana: " + isUsernameAlreadyUsed("ana"));
        // Debug.Log("Check username elena: " + isUsernameAlreadyUsed("elena"));

        // Debug.Log("Check email ana: " + isEmailAlreadyUsed("ana@yahoo.com"));
        // Debug.Log("Check email elena: " + isEmailAlreadyUsed("elena@yahoo.com"));

        //Debug.Log("Check password for test: " + isPasswordCorrect("test", EncryptPassword.HashString("test")));
    }

    // Update is called once per frame
    void Update(){
        
    }

    //create database with tables
    public void CreatePianoDB(){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "CREATE TABLE IF NOT EXISTS Users (userID INTEGER PRIMARY KEY UNIQUE NOT NULL, email STRING NOT NULL UNIQUE, username STRING UNIQUE NOT NULL, hashedPwd STRING NOT NULL, xp INTEGER DEFAULT (0), streak INTEGER DEFAULT (0), level INTEGER DEFAULT (0));";
                query.ExecuteNonQuery();

                //query.CommandText = "CREATE TABLE IF NOT EXISTS PianoKey (keyID INTEGER PRIMARY KEY NOT NULL UNIQUE, note STRING  NOT NULL, tone STRING NOT NULL, sound BLOB NOT NULL, scale INTEGER NOT NULL);";
                query.CommandText = "CREATE TABLE IF NOT EXISTS PianoKey (keyID INTEGER PRIMARY KEY NOT NULL UNIQUE, note STRING  NOT NULL, tone STRING NOT NULL, sound BLOB, scale INTEGER NOT NULL);";
                query.ExecuteNonQuery();

                //query.CommandText = "CREATE TABLE IF NOT EXISTS Lessons (lessonID INTEGER PRIMARY KEY NOT NULL UNIQUE, title STRING  NOT NULL, content BLOB  NOT NULL, requiredLevel INTEGER NOT NULL, maxXP INTEGER NOT NULL);";
                query.CommandText = "CREATE TABLE IF NOT EXISTS Lessons (lessonID INTEGER PRIMARY KEY NOT NULL UNIQUE, title STRING  NOT NULL, content BLOB, requiredLevel INTEGER NOT NULL, maxXP INTEGER NOT NULL);";
                query.ExecuteNonQuery();
            }

            connectionToDB.Close();
        }
    }

    //add data to the tables
    public void AddUser(int userID, string email, string username, string hashedPwd){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                //query.CommandText = "INSERT INTO Users VALUES('"+ userID +"', '" + email + "', '" + username + "', '" + hashedPwd + "', " + xp + "', '" + streak + "', '" + level + "');";
                //!!!!! DO NOT FORGET TO HASH THE PASSWORD
                //UserID should be incremented automatically before calling the function, as it is not user input
                query.CommandText = "INSERT INTO Users (userID, email, username, hashedPwd) VALUES('" + userID +"', '" + email + "', '" + username + "', '" + hashedPwd + "');"; //xp, streak, level are 0 by default for new users
                query.ExecuteNonQuery();
            }

            connectionToDB.Close();
        }
    }

    public void AddPianoKey(int keyID, string note, string tone, int scale){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                //LOOK INTO BLOB
                //ADD BACK NOT NULL CONSTRAINT
                query.CommandText = "INSERT INTO PianoKey (keyID, note, tone, scale) VALUES('" + keyID +"', '" + note + "', '" + tone + "', '" + scale + "');"; 
                query.ExecuteNonQuery();
            }

            connectionToDB.Close();
        }
    }

    public void AddLesson(int lessonID, string title, int requiredLevel, int maxXP){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                //LOOK INTO BLOB
                //ADD BACK NOT NULL CONSTRAINT
                query.CommandText = "INSERT INTO Lessons (lessonID, title, requiredLevel, maxXP) VALUES('" + lessonID +"', '" + title + "', '" + requiredLevel + "', '" + maxXP + "');";
                query.ExecuteNonQuery();
            }

            connectionToDB.Close();
        }
    }

    //display the contents of the tables
    public void DisplayUsers(){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT userID, email, username, xp, streak, level FROM Users;"; //We don't get the password for security (hopefully this helps)
                
                using(IDataReader usersReader = query.ExecuteReader()){
                    while(usersReader.Read()){
                        Debug.Log("User " + usersReader["username"] + " has ID " + usersReader["userID"] + " and email " + usersReader["email"] + " with XP " + usersReader["xp"] + " and a streak of " + usersReader["streak"] + " at level " + usersReader["level"] + ".\n");
                    }
                    usersReader.Close();
                }
            }

            connectionToDB.Close();
        }
    }

    public void DisplayPianoKeys(){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT * FROM PianoKey;";
                
                using(IDataReader keysReader = query.ExecuteReader()){
                    while(keysReader.Read()){
                        Debug.Log("Key " + keysReader["keyID"] + ", note " + keysReader["note"] + ", tone " + keysReader["tone"] + ", sound " + keysReader["sound"] + ", scale " + keysReader["scale"] + ".\n"); //can we display sound????
                    }
                    keysReader.Close();
                }
            }

            connectionToDB.Close();
        }
    }

    public void DisplayLessosns(){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT * FROM Lessons;";

                using(IDataReader lessonsReader = query.ExecuteReader()){
                    while(lessonsReader.Read()){
                        Debug.Log("Lesson " + lessonsReader["lessonID"] + ": "  + lessonsReader["title"] + " requires level " + lessonsReader["requiredLevel"] + " and you can get up to " + lessonsReader["maxXP"] + "XP.\n\t" + lessonsReader["content"] + "\n");
                    }
                    lessonsReader.Close();
                }
            }

            connectionToDB.Close();
        }
    }

    //get data by ID
    public void getUserByID(int userID){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT userID, email, username, xp, streak, level FROM Users WHERE userID = " + userID + ";"; //We don't get the password for security (hopefully this helps)
                IDataReader usersReader = query.ExecuteReader();
                Debug.Log("User " + usersReader["username"] + " has ID " + usersReader["userID"] + " and email " + usersReader["email"] + " with XP " + usersReader["xp"] + " and a streak of " + usersReader["streak"] + " at level " + usersReader["level"] + ".\n");
                usersReader.Close();
            }

            connectionToDB.Close();
        }
    }

    public void getPianoKeysByID(int keyID){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT * FROM PianoKey WHERE keyID = " + keyID + ";";
                IDataReader keysReader = query.ExecuteReader();
                Debug.Log("Key " + keysReader["keyID"] + ", note " + keysReader["note"] + ", tone " + keysReader["tone"] + ", sound " + keysReader["sound"] + ", scale " + keysReader["scale"] + ".\n"); //can we display sound????
                keysReader.Close();
            }

            connectionToDB.Close();
        }
    }

    public void getLessosnByID(int lessonID){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT * FROM Lessons WHERE lessonID = " + lessonID + ";";
                IDataReader lessonsReader = query.ExecuteReader();
                Debug.Log("Lesson " + lessonsReader["lessonID"] + ": "  + lessonsReader["title"] + " requires level " + lessonsReader["requiredLevel"] + " and you can get up to " + lessonsReader["maxXP"] + "XP.\n\t" + lessonsReader["content"] + "\n");
                lessonsReader.Close();
            }

            connectionToDB.Close();
        }
    }

    //delete entry from table by ID
    //is this even safe??
    public void DeleteUser(int userID){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "DELETE FROM Users WHERE userID = " + userID + ";";
                query.ExecuteNonQuery();
            }

            connectionToDB.Close();
        }
    }

    public void DeletePianoKey(int keyID){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "DELETE FROM PianoKey WHERE keyID = " + keyID + ";";
                query.ExecuteNonQuery();
            }

            connectionToDB.Close();
        }
    }

    public void DeleteLesson(int lessonID){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "DELETE FROM Lessons WHERE lessonID = " + lessonID + ";";
                query.ExecuteNonQuery();
            }

            connectionToDB.Close();
        }
    }

    //getting the last ID in the table to use when inserting the next entry
    public int getLastUserID(){
        int lastID = 0;

        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT MAX(userID) AS userID FROM Users;";
                IDataReader usersReader = query.ExecuteReader();
                if(usersReader["userID"] != DBNull.Value){
                    lastID = Convert.ToInt32(usersReader["userID"]);
                    Debug.Log("ID: " + usersReader["userID"] + "\n");
                }
                else{
                    Debug.Log("Users table is empty\n");
                }
                usersReader.Close();
            }

            connectionToDB.Close();
        }

        return lastID;
    }

    public int getLastKeyID(){
        int lastID = 0;

        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT MAX(keyID) AS keyID FROM PianoKey;";
                IDataReader keysReader = query.ExecuteReader();
                if(keysReader["keyID"] != DBNull.Value){
                    lastID = Convert.ToInt32(keysReader["keyID"]);
                    Debug.Log("ID: " + keysReader["keyID"] + "\n");
                }
                else{
                    Debug.Log("PianoKey table is empty\n");
                }
                keysReader.Close();
            }

            connectionToDB.Close();
        }

        return lastID;
    }

    public int getLastLessonID(){
        int lastID = 0;

        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT MAX(lessonID) AS lessonID FROM Lessons;";
                IDataReader lessonsReader = query.ExecuteReader();
                if(lessonsReader["lessonID"] != DBNull.Value){
                    lastID = Convert.ToInt32(lessonsReader["lessonID"]);
                    Debug.Log("ID: " + lessonsReader["lessonID"] + "\n");
                }
                else{
                    Debug.Log("Lessons table is empty\n");
                }
                lessonsReader.Close();
            }

            connectionToDB.Close();
        }

        return lastID;
    }


    //checks for constraint violations
    //can this be done in only one function/in a better way?
    public bool isUsernameAlreadyUsed(string text){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT username FROM Users WHERE username = '" + text + "' ;";
                IDataReader usersReader = query.ExecuteReader();
                if(usersReader["username"] != DBNull.Value){
                    Debug.Log("Username: " + usersReader["username"] + " already exists in the database.\n");
                    return true;
                }
                usersReader.Close();
            }

            connectionToDB.Close();
        }

        return false;
    }

    public bool isEmailAlreadyUsed(string text){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT email FROM Users WHERE email = '" + text + "' ;";
                IDataReader usersReader = query.ExecuteReader();
                if(usersReader["email"] != DBNull.Value){
                    Debug.Log("Email address: " + usersReader["email"] + " already exists in the database.\n");
                    return true;
                }
                usersReader.Close();
            }

            connectionToDB.Close();
        }

        return false;
    }

    public bool isPasswordCorrect(string username, string password){
        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT hashedPwd FROM Users WHERE username = '" + username + "' ;";
                IDataReader usersReader = query.ExecuteReader();
                if(usersReader["hashedPwd"] != DBNull.Value){
                    if(string.Equals(password, usersReader["hashedPwd"])){
                        Debug.Log("Password is correct.\n");
                        return true;
                    }
                }
                usersReader.Close();
            }

            connectionToDB.Close();
        }

        return false;
    }

    public int getNumberOfLessons(){
        int numberOfLessons = 0;

        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT COUNT(lessonID) AS numberOfLessons FROM Lessons;";
                IDataReader lessonsReader = query.ExecuteReader();
                if(lessonsReader["numberOfLessons"] != DBNull.Value){
                    numberOfLessons = Convert.ToInt32(lessonsReader["numberOfLessons"]);
                }
                else{
                    Debug.Log("Lessons table is empty\n");
                }
                lessonsReader.Close();
            }

            connectionToDB.Close();
        }

        return numberOfLessons;
    }

    public string getLessonNameByID(int lessonID){
        string lessonName = "";

        using(var connectionToDB = new SqliteConnection(dbName)){
            connectionToDB.Open();

            using(var query = connectionToDB.CreateCommand()){
                query.CommandText = "SELECT title FROM Lessons WHERE lessonID = " + lessonID + ";";
                IDataReader lessonsReader = query.ExecuteReader();
                if(lessonsReader["title"] != DBNull.Value){
                    lessonName = Convert.ToString(lessonsReader["title"]);
                }
                else{
                    Debug.Log("Lessons table is empty\n");
                }
                lessonsReader.Close();
            }

            connectionToDB.Close();
        }

        return lessonName;
    }
}