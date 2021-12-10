using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLockedDoor : RoomAccessPoint
{
    public Key.typeKey requiredKey;
    private bool keyIsObtained = false;
    private bool doorIsUnlocked = false;
    private string doorFullName;
    public Collider2D coll;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && keyIsObtained)
        {
            coll.enabled = false;
            Player.unlockedDoors.Add(doorFullName);
            doorIsUnlocked = true;
            promptManager.HidePrompt();
            promptManager.ShowPromt("Open");            
        }
    }

    public override void StartFunExtension()
    {
        doorFullName = connectedSceneName + gameObject.name;
        if (Player.unlockedDoors.Contains(doorFullName))
        {
            keyIsObtained = true;
            doorIsUnlocked = true;
            promptText = "Open";
        }
    }
    public override void PlayerEnterFeedback()
    {
        if (Player.obtainedKeys.Contains(requiredKey))
        {
            keyIsObtained = true;
        }
        if (!doorIsUnlocked)
        {
            if (!Player.obtainedKeys.Contains(requiredKey))
            {
                promptText = "Locked";
                keyIsObtained = false;
            }
            else
            {
                promptText = "Locked";
                keyIsObtained = true;
            }
        }
    }

    public override void PlayerExitFeedback()
    {
        // promptText = "Locked";
        keyIsObtained = false;
    }
}
