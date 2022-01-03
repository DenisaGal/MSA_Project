using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySongNotes : MonoBehaviour
{
    public GameObject[] Notes;
    public string[] NotesNames;
    private int currentindex = 0;
    [SerializeField] private string nextScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AllBeforeNoteActive()
    {
        for(int i = 0; i < currentindex; i++)
        {
            var isActive = Notes[i].activeSelf;
            if (Notes[i] == null || isActive == false)
                return false;
        }

        return true;
    }

    public void DisplayNote(string note)
    {
        if (note == NotesNames[currentindex])
        {
            if (AllBeforeNoteActive())
            {
                Notes[currentindex].SetActive(true);
                
                if (currentindex < (Notes.Length - 1))
                    currentindex++;
                else
                {
                    StartCoroutine(TransitionToNextScene());
                }
            }
        }
    }
    
    IEnumerator TransitionToNextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextScene);
    }
}

