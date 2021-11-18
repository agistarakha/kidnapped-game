using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomAccessPoint : InteractiveObject
{
    public string connectedSceneName = "Room 2";
    public string connectedDoor = "D-1";

    protected void LoadConnectedScene()
    {
        DoorData.lastVisitedScene = connectedSceneName;
        DoorData.doorSpawnLocation = connectedDoor;
        Player.lastPos = Vector3.zero;
        SceneManager.LoadScene(connectedSceneName);
    }
}
