using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedExaminableObj : InteractiveObject
{
    public Key.typeKey key;
    public string code;
    // Start is called before the first frame update
    void Awake()
    {
        if (Player.obtainedKeys.Contains(key))
        {
            GetComponent<ExamineableObject>().enabled = true;
            // if (gameObject.GetComponent<KeyObject>().enabled == false || GetComponent<KeyObject>() != null)
            // {
            //     Debug.Log("Verdinald ssw");
            //     GetComponent<KeyObject>().enabled = true;
            // }
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<ExamineableObject>().PlayerInRange = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player.obtainedKeys.Contains(key))
        {
            GetComponent<ExamineableObject>().enabled = true;
            Player.gameState = Player.GameState.GAMEPLAY;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = true;
            this.enabled = false;
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.E) && playerInRange && Player.gameState == Player.GameState.GAMEPLAY && Player.currentState != Player.PlayerState.JUMPING)
            {
                GameObject popUpObj = PopUpUIManager.Instance.ActivateUI("NumLock");
                NumLockChecker numLockChecker = popUpObj.transform.GetChild(0).GetChild(0).GetComponent<NumLockChecker>();
                numLockChecker.Code = code;
                numLockChecker.KeyType = key;

            }
        }


    }
}
