using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : InteractiveObject
{
    public SecretDoor secretDoor;
    public Door door;

    public override void StartFunExtension()
    {
        base.StartFunExtension();
        if (Player.unlockedDoors.Contains("SecretDoor"))
        {
            secretDoor.transform.position = secretDoor.targetPos;
            door.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.obtainedKeys.Contains(Key.typeKey.Lever))
        {
            if (Input.GetKeyDown(KeyCode.E) && playerInRange)
            {
                StartCoroutine(secretDoor.SlideDoor());
                door.enabled = true;
                Player.unlockedDoors.Add("SecretDoor");
            }
        }
        else
        {
            if (playerInRange)
            {
                promptManager.HidePrompt();
                objImg.color = oriColor;


            }
        }
    }

    public override void PlayerEnterFeedback()
    {
        objImg.color = oriColor;
    }
}
