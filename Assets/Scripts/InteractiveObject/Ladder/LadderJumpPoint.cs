using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderJumpPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.currentState = Player.PlayerState.WANDER;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.isJumpPointReached = false;
        }
    }
}
