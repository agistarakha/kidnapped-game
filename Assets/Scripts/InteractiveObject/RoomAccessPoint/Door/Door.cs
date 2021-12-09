
using UnityEngine;
using System.Collections;

public class Door : RoomAccessPoint
{



    public override void StartFunExtension()
    {
        base.StartFunExtension();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            StartCoroutine(OpenDoor());
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
