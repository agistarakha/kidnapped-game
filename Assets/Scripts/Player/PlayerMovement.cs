
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpVelocity = 2.0f;


    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    private Animator playerAnimator;
    private Vector2 direction;
    private float lastInput = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        direction = Vector2.zero;
    }

    void Update()
    {
        if (Player.gameState == Player.GameState.MENU)
        {
            playerRb.velocity = Vector2.zero;
            playerAnimator.Play("IdleAnimation");
            return;
        }
        lastInput = (direction.x == 0) ? lastInput : direction.x;
        float horizontalInput = 0;
        float verticalInput = 0;
        if (Player.currentState == Player.PlayerState.CLIMBING)
        {
            playerRb.velocity = Vector2.zero;
            playerAnimator.SetBool("IsClimbing", true);
            playerAnimator.SetBool("IsStanding", false);

            playerRb.gravityScale = 0;
            verticalInput = Input.GetAxis("Vertical");


        }
        else if (Player.currentState == Player.PlayerState.WANDER)
        {
            playerAnimator.SetBool("IsClimbing", false);
            playerAnimator.SetBool("IsStanding", true);

            playerRb.gravityScale = 1;
            if (IsGrounded())
            {
                horizontalInput = Input.GetAxis("Horizontal");
                playerAnimator.SetBool("IsJumping", false);
                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();
                }
            }
        }
        playerAnimator.SetFloat("YVelo", Mathf.Abs(playerRb.velocity.y));
        playerAnimator.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));
        playerAnimator.SetFloat("verticalInput", Mathf.Abs(verticalInput));
        playerSprite.flipX = (lastInput < 0) ? true : false;
        direction = new Vector2(horizontalInput, verticalInput);
        // Debug.Log(playerRb.velocity.x);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.gameState == Player.GameState.MENU)
        {
            playerRb.velocity = Vector2.zero;
            playerAnimator.Play("IdleAnimation");

            return;
        }

        if (Mathf.Abs(direction.x) > 0)
        {
            Move();

        }
        else if (Mathf.Abs(direction.y) > 0)
        {
            Climb();
        }
        else
        {
            if (IsGrounded())
            {
                playerRb.velocity = Vector2.zero;
            }
        }

    }

    void Move()
    {
        // playerRb.MovePosition((Vector2)transform.position + (direction * speed) * Time.deltaTime);
        playerAnimator.SetBool("IsStanding", false);
        playerRb.velocity = new Vector2(speed * direction.x, playerRb.velocity.y);
        // playerRb.velocity = Vector2.right * Mathf.Ceil(direction.x) * speed;

    }

    void Climb()
    {
        // playerRb.MovePosition((Vector2)transform.position + (direction * speed) * Time.deltaTime);
        playerRb.velocity = Vector2.up * direction * 2.0f;

    }
    void Jump()
    {
        playerRb.velocity = Vector2.up * jumpVelocity;
        playerAnimator.SetBool("IsStanding", false);
        playerAnimator.SetBool("IsJumping", true);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Floor"));

        //If something was hit.
        if (hit)
        {

            Player.currentState = Player.PlayerState.WANDER;
            
            return true;

        }

        return false;

    }
}
