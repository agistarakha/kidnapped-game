using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomAccessPoint : InteractiveObject
{
    public enum DoorType
    {
        FRONT,
        SIDE
    }
    public string connectedSceneName = "Room 2";
    public string connectedDoor = "D-1";
    public Sprite doorOpenSprite = null;
    public Collider2D doorCollider = null;
    public DoorType doorType;


    protected void LoadConnectedScene()
    {
        DoorData.lastVisitedScene = connectedSceneName;
        DoorData.doorSpawnLocation = connectedDoor;
        Player.lastPos = Vector3.zero;
        StartCoroutine(LoadYourAsyncScene(connectedSceneName));
    }

    IEnumerator LoadYourAsyncScene(string connected)
    {
        Player.gameState = Player.GameState.MENU;
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        GameDataManager.SaveFile(player);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(connected);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public IEnumerator OpenDoor()
    {
        objImg.color = oriColor;
        yield return new WaitForSeconds(0.5f);
        if (doorOpenSprite != null)
        {
            objImg.sprite = doorOpenSprite;
        }
        DoorTypeHandling();
        yield return new WaitForSeconds(0.1f);
        if (connectedSceneName == "")
        {
            doorCollider.enabled = false;

        }
        else
        {
            LoadConnectedScene();

        }

    }

    private void DoorTypeHandling()
    {
        if (doorType == DoorType.SIDE)
        {
            float xOffset = 87.274f - 85.52f;
            float yOffset = 17.252f - 18f;
            if (objImg.flipX == true)
            {
                // yOffset = yOffset * -1;
                xOffset = xOffset * -1;
            }
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.position = new Vector3(transform.position.x - xOffset, transform.position.y - yOffset, 0);

        }
    }

}

