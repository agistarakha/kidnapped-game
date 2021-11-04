using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractiveObject
{
    public string connectedSceneName = "Room 2";
    public string connectedDoor = "D-1";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        DoorData.lastVisitedScene = connectedSceneName;
        DoorData.doorSpawnLocation = connectedDoor;
        Player.lastPos = Vector3.zero;
        SceneManager.LoadScene(connectedSceneName);
    }
}
