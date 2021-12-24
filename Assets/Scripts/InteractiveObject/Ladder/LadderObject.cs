using UnityEngine;

public class LadderObject : InteractiveObject
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) == 1 && playerInRange && Player.currentState != Player.PlayerState.CLIMBING)
        {
            // promptManager.HidePrompt();
            Player.currentState = Player.PlayerState.CLIMBING;
        }
    }
    public override void PlayerExitFeedback()
    {
        Player.currentState = Player.PlayerState.WANDER;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

}
