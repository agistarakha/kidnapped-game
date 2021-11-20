using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : InteractiveObject
{
    public GameObject puzzlePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            PopUpUIManager.Instance.ActivateUI(puzzlePrefab.name);
        }
    }
}
