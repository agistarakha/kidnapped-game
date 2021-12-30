using UnityEngine;

public class LadderJumpPoint : MonoBehaviour
{


    private bool isClimbEnd = false;
    private Rigidbody2D playerRb = null;
    public bool stopClimb = false;


    void Update()
    {
        if (Input.GetAxis("Vertical") < 0 && isClimbEnd && playerRb != null)
        {
            stopClimb = true;
            Debug.Log("Kawan");
            Player.currentState = Player.PlayerState.WANDER;
            //playerRb.velocity = Vector2.zero;

        }
        else if (Player.currentState == Player.PlayerState.WANDER)
        {
            stopClimb = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerRb = other.GetComponent<Rigidbody2D>();
            isClimbEnd = true;
            // GetComponentInParent<BoxCollider2D>().enabled = false;
            // GetComponentInParent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            stopClimb = false;
            isClimbEnd = false;
        }
    }
}
