using UnityEngine;

public class LadderJumpPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Player.currentState == Player.PlayerState.CLIMBING)
        {
            // GetComponentInParent<BoxCollider2D>().enabled = false;
            // GetComponentInParent<BoxCollider2D>().enabled = true;
            Player.currentState = Player.PlayerState.WANDER;

        }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         Player.isJumpPointReached = false;
    //     }
    // }
}
