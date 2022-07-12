using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class yang berfungsi sebagai component dari object yang menampilkan tutorial apabila Player berada pada area object
/// </summary>
public class TutorialTrigger : InteractiveObject
{
    public int tutorialUI;

    public override void PlayerEnterFeedback()
    {
        if (!Player.revealedTutorial.Contains(tutorialUI))
        {
            Player.revealedTutorial.Add(tutorialUI);
            TutorialManager.Instance.ShowTutorialUI(tutorialUI);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
