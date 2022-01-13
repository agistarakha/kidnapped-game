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
            transform.GetChild(0).gameObject.SetActive(true);
            door.GetComponent<BoxCollider2D>().enabled = true;
            secretDoor.transform.position = secretDoor.targetObj.transform.position;
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
                transform.GetChild(0).gameObject.SetActive(true);
                CinemachineShake.Instance.ShakeCamera(2f, 1f);
                StartCoroutine(secretDoor.SlideDoor());
                door.GetComponent<BoxCollider2D>().enabled = true;
                door.enabled = true;
                Player.unlockedDoors.Add("SecretDoor");

            }
        }
        else
        {
            if (playerInRange)
            {
                // promptManager.HidePrompt();
                objImg.color = oriColor;


            }
        }
    }

    public override void PlayerEnterFeedback()
    {
        objImg.color = oriColor;
    }
}
