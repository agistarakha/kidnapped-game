using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : InteractiveObject
{
    public string title;
    public string description;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            Player.obtainedNotes.Add(title, description);
            NoteInventoryManager.Instance.SpawnNoteUI(title);
            this.gameObject.SetActive(false);
            Debug.Log("Taken");
        }
    }
}
