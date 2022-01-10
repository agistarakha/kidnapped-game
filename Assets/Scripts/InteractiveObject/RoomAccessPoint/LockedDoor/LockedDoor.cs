using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : RoomAccessPoint
{
    public Key.typeKey requiredKey;
    private bool keyIsObtained = false;
    private bool doorIsUnlocked = false;
    private string doorFullName;
    [TextAreaAttribute(5, 100)]
    public string lockedDialog = "Terkunci...";
    private bool doorIsOpened = false;

    // void Start()
    // {
    //     doorFullName = connectedSceneName + gameObject.name;
    // }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && keyIsObtained && playerInRange && (Player.gameState == Player.GameState.GAMEPLAY) && !doorIsOpened)
        {
            if (doorIsUnlocked)
            {
                StartCoroutine(OpenDoor());
                doorIsOpened = true;

            }
            else
            {
                //Disini Audio ketika kunci berhasil
                AudioManager.instance.PlaySFX("BukaKunci");
                Player.unlockedDoors.Add(doorFullName);
                doorIsUnlocked = true;
                DialogManager.Instance.ShowDialogUI("Terbuka!");
                // promptManager.HidePrompt();
                // promptManager.ShowPromt("Open");
            }


        }
        else if (Input.GetKeyDown(KeyCode.E) && !keyIsObtained && playerInRange && (Player.gameState == Player.GameState.GAMEPLAY))
        {
            //Disini Audio Ketika Pintu terkunci
            AudioManager.instance.PlaySFX("Terkunci");
            DialogManager.Instance.ShowDialogUI(lockedDialog);
        }
        // if (Player.unlockedDoors.Contains(doorFullName) && keyIsObtained)
        // {
        //     doorIsUnlocked = true;

        //     promptManager.HidePrompt();
        //     promptManager.ShowPromt("Open");
        // }
    }

    public override void StartFunExtension()
    {
        doorFullName = connectedSceneName + gameObject.name;
        if (Player.unlockedDoors.Contains(doorFullName))
        {
            keyIsObtained = true;
            doorIsUnlocked = true;
            // promptText = "Open";
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
                // promptText = "Locked";
                keyIsObtained = false;
            }
            else
            {
                // promptText = "Locked";
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
