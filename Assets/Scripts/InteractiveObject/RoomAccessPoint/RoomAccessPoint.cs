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
        StartCoroutine(LoadYourAsyncScene(connectedSceneName));
    }

    IEnumerator LoadYourAsyncScene(string connected)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(connected);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
