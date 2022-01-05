using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossFadeLoading : MonoBehaviour
{
    public void PlayerStopMoving()
    {
        Player.isPlayerMoveable = false;
    }

    public void PlayerStartMoving()
    {
        Player.isPlayerMoveable = true;
    }
}
