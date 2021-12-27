using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointObject : InteractiveObject
{
    void Update()
    {
        if (playerInRange && Input.GetKey(KeyCode.E))
        {
            GameDataManager.SaveFile(player);
            // promptManager.ShowPromt("Game Saved");

        }
    }
}
