
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpSpeedY = 2.0f;


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
        lastInput = (direction.x == 0) ? lastInput : direction.x;
        float horizontalInput = 0;
        float verticalInput = 0;
        if (Player.currentState == Player.PlayerState.CLIMBING)
        {
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
            horizontalInput = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space) && Player.isGrounded)
            {
                Jump(playerRb.velocity.x);
                Player.isGrounded = false;
            }
        }
        CastToFloor();

        playerAnimator.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));
        playerAnimator.SetFloat("verticalInput", Mathf.Abs(verticalInput));
        playerSprite.flipX = (lastInput < 0) ? true : false;
        direction = new Vector2(horizontalInput, verticalInput);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(direction.x) > 0)
        {
            Move();

        }
        else if (Mathf.Abs(direction.y) > 0)
        {
            Climb();
        }
    }

    void Move()
    {
        // playerRb.MovePosition((Vector2)transform.position + (direction * speed) * Time.deltaTime);
        playerRb.velocity = new Vector2(speed * direction.x, playerRb.velocity.y);

    }

    void Climb()
    {
        playerRb.MovePosition((Vector2)transform.position + (direction * speed) * Time.deltaTime);

    }
    void Jump(float xDir)
    {
        playerRb.velocity = new Vector2(xDir, playerRb.velocity.y + jumpSpeedY * 2);


    }

    void CastToFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, 0.00001f, LayerMask.GetMask("Floor"));

        //If something was hit.
        if (hit)
        {

            Player.currentState = Player.PlayerState.WANDER;
            Player.isGrounded = true;

        }

    }



}
