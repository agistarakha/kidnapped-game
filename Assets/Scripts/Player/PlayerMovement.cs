
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpVelocity = 2.0f;
    public Transform ledgeCheck;
    public Transform wallCheck;
    public LayerMask objectMask;

    [SerializeField] Collider2D standingCollider;

    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    private Animator playerAnimator;
    private Vector2 direction;
    private float lastInput = 0;

    [SerializeField] bool isTouchLedge;
    [SerializeField] bool isTouchWall;
    private bool canClimbLedge = false;
    private bool ledgeDetected=false;
    private Vector2 ledgePosBot;
    private Vector2 ledgePos1;
    private Vector2 ledgePos2;

    public float timer=1;
    public float ledgeClimbXOffset1 = 0f;
    public float ledgeClimbYOffset1 = 0f;
    public float ledgeClimbXOffset2 = 0f;
    public float ledgeClimbYOffset2 = 0f;

    [SerializeField] bool crouchFlag;

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
        if (Player.gameState == Player.GameState.MENU || Player.gameState == Player.GameState.DIALOG)
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
                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();
                               
                }
                Crouch();
            }
        }
        playerAnimator.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));
        playerAnimator.SetFloat("verticalInput", Mathf.Abs(verticalInput));
        playerSprite.flipX = (lastInput < 0) ? true : false;
        direction = new Vector2(horizontalInput, verticalInput);
        // Debug.Log(playerRb.velocity.x);
        Ledge();
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
    #region Movement
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
        playerAnimator.SetBool("IsStanding", false);
        playerAnimator.SetBool("IsJumping", true);
        playerRb.velocity = Vector2.up * jumpVelocity;
    }
    void Crouch()
    {
        RaycastHit2D hitr = Physics2D.Raycast(transform.position + Vector3.right, Vector2.up, 3f, LayerMask.GetMask("Crouch"));
        RaycastHit2D hitl = Physics2D.Raycast(transform.position + Vector3.left, Vector2.up, 3f, LayerMask.GetMask("Crouch"));
        if (Input.GetButtonDown("Crouch") && (hitr || hitl))
        {
            playerAnimator.SetBool("IsStanding", false);
            playerAnimator.SetBool("IsCrouch", true);
            crouchFlag = true;
            speed = 1f;
        }

        else if (!hitr && !hitl)
        {
            playerAnimator.SetBool("IsCrouch", false);
            playerAnimator.SetBool("IsStanding", true);
            crouchFlag = false;
            speed = 8f;
        }
        standingCollider.enabled = !crouchFlag;
    }

    void Ledge()
    {
        isTouchLedge = Physics2D.Raycast(ledgeCheck.position, transform.right*lastInput, 1f, objectMask);
        isTouchWall = Physics2D.Raycast(wallCheck.position, transform.right*lastInput, 1f, objectMask);

        if (!isTouchLedge&&isTouchWall)
        {
            ledgePosBot = wallCheck.position;
            if (lastInput < 0)
            {
                ledgePos1 = new Vector2(Mathf.Floor(ledgePosBot.x - 1f) + ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset1);
            }
            else if (lastInput > 0)
            {
                ledgePos1 = new Vector2(Mathf.Floor(ledgePosBot.x + 1f) + ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset1);
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                    transform.position = ledgePos1;
                timer = 1;
            }
        }     
    }


    #endregion



    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Floor"));

        //If something was hit.
        if (hit)
        {

            Player.currentState = Player.PlayerState.WANDER;
            playerAnimator.SetBool("IsJumping", false);
            return true;

        }

        return false;

    }
}
