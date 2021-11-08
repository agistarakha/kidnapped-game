
using UnityEngine;

public class Door : RoomAccessPoint
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            LoadConnectedScene();
        }
    }
}
