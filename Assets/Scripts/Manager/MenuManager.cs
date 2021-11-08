using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseManuObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseManuObject.SetActive(true);
            Player.gameState = Player.GameState.MENU;
        }
    }

    public void ResumeGame()
    {
        pauseManuObject.SetActive(false);
        Player.gameState = Player.GameState.GAMEPLAY;

    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Player.gameState = Player.GameState.GAMEPLAY;

    }
}
