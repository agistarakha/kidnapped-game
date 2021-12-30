using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteObject : InteractiveObject
{
    public string title;

    [TextAreaAttribute(5, 100)]
    public string description;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && Player.gameState == Player.GameState.GAMEPLAY)
        {
            if (!Player.obtainedNotes.ContainsKey(title))
            {
                Player.obtainedNotes.Add(title, description);
                // NoteInventoryManager.Instance.SpawnNoteUI(title);
            }
            GameObject noteUIObj = PopUpUIManager.Instance.ActivateUI("Note");
            // Disini Audio
            AudioManager.instance.PlaySFX("Note");
            Debug.Log(noteUIObj);
            noteUIObj.transform.GetChild(0).GetComponent<Text>().text = title;
            noteUIObj.transform.GetChild(1).GetComponent<Text>().text = description;
        }
    }
}
