using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamineableObject : InteractiveObject
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && playerInRange)
        {
            ShowObjectDetail();
        }
    }

    void ShowObjectDetail()
    {
        Player.currentState = Player.PlayerState.EXAMINE;
        Player.lastPos = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        SceneManager.LoadScene("Figura");
    }
}
