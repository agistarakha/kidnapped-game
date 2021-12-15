using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteItem : MonoBehaviour
{
    public string title;
    private Button button;
    private Text noteDetails;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        foreach (KeyValuePair<string, string> note in Player.obtainedNotes)
        {

        }
        GetComponentInChildren<Text>().text = title;
    }

    public void ShowItemDetails()
    {
        GameObject.FindGameObjectsWithTag("NoteDetails")[0].GetComponentInChildren<Text>().text = Player.obtainedNotes[title];
        //noteDetails.text = 
    }
}
