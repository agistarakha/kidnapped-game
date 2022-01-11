using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : InteractiveObject
{
    public int tutorialUI;

    public override void PlayerEnterFeedback()
    {
        if (!Player.revealedTutorial.Contains(tutorialUI))
        {
            //Player.gameState = Player.GameState.DIALOG;
            Player.revealedTutorial.Add(tutorialUI);
            //DialogManager.Instance.ShowDialogUI(dialogText);
            TutorialManager.Instance.ShowTutorialUI(tutorialUI);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
