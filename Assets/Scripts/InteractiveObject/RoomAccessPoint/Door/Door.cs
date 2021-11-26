
using UnityEngine;
using System.Collections;

public class Door : RoomAccessPoint
{


    public Sprite doorOpenSprite;

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

    private IEnumerator OpenDoor()
    {
        objImg.color = oriColor;
        yield return new WaitForSeconds(0.5f);
        objImg.sprite = doorOpenSprite;
        yield return new WaitForSeconds(0.5f);
        LoadConnectedScene();

    }
}
