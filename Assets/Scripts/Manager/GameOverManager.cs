using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : InteractiveObject
{
    public string connectedSceneName = "Room 2";

    protected void LoadConnectedScene()
    {
        SceneManager.LoadScene(connectedSceneName);
    }
    public override void PlayerEnterFeedback()
    {
        base.PlayerEnterFeedback();
        LoadConnectedScene();
    }
}
