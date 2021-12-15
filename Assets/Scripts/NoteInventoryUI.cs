using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteInventoryUI : MonoBehaviour
{
    public GameObject noteItem;
    public GameObject noteItemParent;
    public GameObject noteDetails;
    private List<string> generatedNote = new List<string>();
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
            if (!generatedNote.Contains(note.Key))
            {
                GameObject obj = Instantiate(noteItem, Vector3.zero, Quaternion.identity, noteItemParent.transform);
                obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = note.Key;
                obj.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
                {
                    ShowDetail(note.Key);
                });
                generatedNote.Add(note.Key);
            }

        }
        // GetComponentInChildren<Text>().text = title;
    }


    private void ShowDetail(string title)
    {
        noteDetails.transform.GetChild(0).GetComponent<Text>().text = title;
        noteDetails.transform.GetChild(1).GetComponent<Text>().text = Player.obtainedNotes[title];
    }
}
