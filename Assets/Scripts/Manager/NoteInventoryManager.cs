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


    private GameObject noteInventoryObj;
    private GameObject itemContainer;
    public Image noteItem;
    public GameObject backdrop;


    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Player.gameState == Player.GameState.GAMEPLAY)
        {
            // foreach (KeyValuePair<string, string> note in Player.obtainedNotes)
            // {
            //     GameObject noteItemGameobject = Instantiate(noteItem.gameObject, noteItem.transform.position, Quaternion.identity, itemContainer.transform);
            //     noteItemGameobject.GetComponentInChildren<NoteItem>().title = note.Key;
            // }
            noteInventoryObj = PopUpUIManager.Instance.ActivateUI("NoteInventoryUI");
            // noteMenu.gameObject.SetActive(true);

        }
    }

    public void SpawnNoteUI(string title)
    {
        GameObject noteItemGameobject = Instantiate(noteItem.gameObject, noteItem.transform.position, Quaternion.identity, itemContainer.transform);
        noteItemGameobject.GetComponentInChildren<NoteItem>().title = title;
    }


}
