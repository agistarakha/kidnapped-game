using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warp : InteractiveObject
{
    public string connectedSceneName = "Room 2";
    public string connectedDoor = "D-1";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            promptManager.ShowPromt(promptText);
            playerInRange = true;
            warpArea();
        }
    }

    void warpArea()
    {
        DoorData.lastVisitedScene = connectedSceneName;
        DoorData.doorSpawnLocation = connectedDoor;
        SceneManager.LoadScene(connectedSceneName);
    }
}
