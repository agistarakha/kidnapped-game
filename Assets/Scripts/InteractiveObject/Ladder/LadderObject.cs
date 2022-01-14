using UnityEngine;

public class LadderObject : InteractiveObject
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponentInChildren<LadderJumpPoint>().stopClimb)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = true;
            return;
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) == 1 && playerInRange && Player.currentState != Player.PlayerState.CLIMBING && Player.currentState != Player.PlayerState.JUMPING)
        {
            // promptManager.HidePrompt();
            objImg.color = oriColor;
            Player.currentState = Player.PlayerState.CLIMBING;
            Vector3 playerPos = player.transform.position;
            player.transform.position = new Vector3(transform.position.x, playerPos.y, 0);
            // GetComponents<BoxCollider2D>()[0].enabled = false;
        }
    }
    public override void PlayerExitFeedback()
    {
        //player.GetComponent<Animator>().Play("V2IdleAnimation");
        Player.currentState = Player.PlayerState.WANDER;
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // GetComponents<BoxCollider2D>()[0].enabled = true;

    }

}
