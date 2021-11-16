using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteInventoryManager : MonoBehaviour
{
    public static NoteInventoryManager _instance = null;
    public static NoteInventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<NoteInventoryManager>();
            }
            return _instance;
        }
    }


    public Image noteMenu;
    public GameObject itemContainer;
    public Image noteItem;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // foreach (KeyValuePair<string, string> note in Player.obtainedNotes)
            // {
            //     GameObject noteItemGameobject = Instantiate(noteItem.gameObject, noteItem.transform.position, Quaternion.identity, itemContainer.transform);
            //     noteItemGameobject.GetComponentInChildren<NoteItem>().title = note.Key;
            // }
            Player.gameState = Player.GameState.MENU;

            noteMenu.gameObject.SetActive(true);
        }
    }

    public void SpawnNoteUI(string title)
    {
        GameObject noteItemGameobject = Instantiate(noteItem.gameObject, noteItem.transform.position, Quaternion.identity, itemContainer.transform);
        noteItemGameobject.GetComponentInChildren<NoteItem>().title = title;
    }

    public void Hide()
    {
        Player.gameState = Player.GameState.GAMEPLAY;
        noteMenu.gameObject.SetActive(false);
    }
}
