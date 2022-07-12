using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteItem : MonoBehaviour
{
    public string title;
    private Button button;
    private Text noteDetails;

    

    void OnEnable()
    {
        foreach (KeyValuePair<string, string> note in Player.obtainedNotes)
        {

        }
        GetComponentInChildren<Text>().text = title;
    }

    
}
