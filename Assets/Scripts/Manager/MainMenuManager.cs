using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        GameDataManager.LoadFile();
        SceneManager.LoadScene(DoorData.lastVisitedScene);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Room 1");

    }
}
