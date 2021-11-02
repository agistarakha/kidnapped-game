using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamineableObject : InteractiveObject
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            ShowObjectDetail();
        }
    }

    void ShowObjectDetail()
    {
        Player.sceneState = Player.PlayerState.EXAMINE;
        Player.lastPos = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        SceneManager.LoadScene("Figura");
    }
}
