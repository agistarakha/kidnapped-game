using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteObject : InteractiveObject
{
    public string title;

    [TextAreaAttribute(5, 100)]
    public string description;
    [TextAreaAttribute(5, 100)]
    public string dialogText = "";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && Player.gameState == Player.GameState.GAMEPLAY && Player.currentState!= Player.PlayerState.JUMPING)
        {
            if (!Player.obtainedNotes.ContainsKey(title))
            {
                Player.obtainedNotes.Add(title, description);
                // NoteInventoryManager.Instance.SpawnNoteUI(title);
            }
            GameObject noteUIObj = PopUpUIManager.Instance.ActivateUI("Note");
            if (dialogText != "")
            {
                noteUIObj.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => DialogManager.Instance.ShowDialogUI(dialogText));
                noteUIObj.name = "Note2";
            }
            else
            {
                noteUIObj.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => ShowNoteTutorial());
            }

            // Disini Audio
            AudioManager.instance.PlaySFX("Note");
            Debug.Log(noteUIObj);
            noteUIObj.transform.GetChild(1).GetComponent<Text>().text = title;
            //noteUIObj.transform.GetChild(2).GetComponent<Text>().text = description;
            noteUIObj.transform.GetChild(2).GetComponentInChildren<Text>().text = description;
        }
    }

    private void ShowNoteTutorial()
    {
        if (!Player.revealedTutorial.Contains(2))
        {
            Player.revealedTutorial.Add(2);
            TutorialManager.Instance.ShowTutorialUI(2);
        }
    }
}
