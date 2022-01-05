using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : InteractiveObject
{
    public GameObject buttonPrefab;
    public Key.typeKey typeKey;
    public string password;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && Player.gameState == Player.GameState.GAMEPLAY)
        {
            //PopUpUIManager.Instance.ActivateUI(buttonPrefab.name);
            //if (!Player.obtainedNotes.ContainsKey(title))
            //{
                //Player.obtainedNotes.Add(title, description);
                // NoteInventoryManager.Instance.SpawnNoteUI(title);
            //}
            GameObject numberPuzzle = PopUpUIManager.Instance.ActivateUI("ButtonUI");
            Debug.Log(numberPuzzle);
            //numberPuzzle.transform.GetChild(0).GetComponent<Text>().text = title;
            numberPuzzle.transform.GetChild(1).GetComponent<DisplayNum>().typeKey = typeKey;
            numberPuzzle.transform.GetChild(1).GetComponent<DisplayNum>().password = password;
        }
    }
}
