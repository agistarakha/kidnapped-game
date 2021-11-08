using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : RoomAccessPoint
{
    public Key.typeKey requiredKey;
    private bool keyIsObtained = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && keyIsObtained)
        {
            LoadConnectedScene();
        }
    }

    public override void PlayerEnterFeedback()
    {
        base.PlayerEnterFeedback();
        if (!Player.obtainedKeys.Contains(requiredKey))
        {
            promptText = "Unlocked";
            keyIsObtained = false;
        }
        else
        {
            promptText = "Open";
            keyIsObtained = true;
        }
    }
}
