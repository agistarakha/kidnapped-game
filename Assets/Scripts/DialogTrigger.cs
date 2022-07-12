using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class yang berfungsi sebagai component dari object yang menampilkan dialog apabila Player berada pada area object
/// </summary>
public class DialogTrigger : InteractiveObject
{
    [TextArea(5, 100)]
    public string dialogText;

    [SerializeField]
    private string dialogId;
    public override void PlayerEnterFeedback()
    {
        if (!Player.revealedDialog.Contains(dialogId))
        {
            Player.gameState = Player.GameState.DIALOG;
            Player.revealedDialog.Add(dialogId);
            DialogManager.Instance.ShowDialogUI(dialogText);
            GetComponent<BoxCollider2D>().enabled = false;

        }

    }
}
