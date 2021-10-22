using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractiveObject
{
    public string connectedSceneName = "Room 2";
    public string connectedDoor = "D-1_R-2";



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && playerInRange)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        DoorData.lastVisitedScene = connectedSceneName;
        DoorData.doorSpawnLocation = connectedDoor;
        SceneManager.LoadScene(connectedSceneName);
    }
}
