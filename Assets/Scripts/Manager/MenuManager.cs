using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseManuPrefab;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Player.gameState == Player.GameState.GAMEPLAY)
        {
            PopUpUIManager.Instance.ActivateUI(pauseManuPrefab.name);
        }
    }


    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Player.gameState = Player.GameState.GAMEPLAY;

    }
}
