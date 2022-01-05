using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
