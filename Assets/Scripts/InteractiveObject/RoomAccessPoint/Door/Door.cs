
using UnityEngine;
using System.Collections;

public class Door : RoomAccessPoint
{

    private bool doorIsOpened = false;

    public override void StartFunExtension()
    {
        base.StartFunExtension();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && !doorIsOpened)
        {
            StartCoroutine(OpenDoor());
            doorIsOpened = true;
        }
    }

    public override void PlayerEnterFeedback()
    {
    }

    public override void PlayerExitFeedback()
    {
        base.PlayerExitFeedback();
    }


}
