using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedExaminableObj : InteractiveObject
{
    public Key.typeKey key;
    // Start is called before the first frame update
    void Awake()
    {
        if (Player.obtainedKeys.Contains(key))
        {
            GetComponent<ExamineableObject>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.obtainedKeys.Contains(key))
        {
            GetComponent<ExamineableObject>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = true;
            this.enabled = false;
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.E) && playerInRange && Player.gameState == Player.GameState.GAMEPLAY)
            {
                GameObject popUpObj = PopUpUIManager.Instance.ActivateUI("Brankas");

            }
        }


    }
}
