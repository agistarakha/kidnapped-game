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
        if (!Player.obtainedKeys.Contains(requiredKey))
        {
            promptText = "Locked";
            keyIsObtained = false;
        }
        else
        {
            promptText = "Open";
            keyIsObtained = true;
        }
    }

    public override void PlayerExitFeedback()
    {
        promptText = "Locked";
        keyIsObtained = false;
    }
}
