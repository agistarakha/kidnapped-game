using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : InteractiveObject
{
    public GameObject puzzleObject;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            Player.gameState = Player.GameState.MENU;
            puzzleObject.SetActive(true);
        }
    }
}
