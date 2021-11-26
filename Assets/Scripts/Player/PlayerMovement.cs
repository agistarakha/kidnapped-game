
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpVelocity = 2.0f;
    public Transform ledgeCheck;
    public Transform wallCheck;
    public Transform pushCheck;
    public LayerMask objectMask;
    private Collider2D standingCollider;

    public float distance = 5f;
    private GameObject box;


    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    private Animator playerAnimator;
    private Vector2 direction;
    private float currentSpeed;
    private CapsuleCollider2D playerCollider;

    private float lastInput;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] bool isTouchLedge;
    [SerializeField] bool isTouchWall;

    private Vector2 ledgePosBot;
    private Vector2 ledgePos1;

    public float timer=1;
    public float ledgeClimbXOffset1 = 0f;
    public float ledgeClimbYOffset1 = 0f;
    public float ledgeClimbXOffset2 = 0f;
    public float ledgeClimbYOffset2 = 0f;

    [SerializeField] bool crouchFlag;
    [SerializeField] bool pullGrab;
    [SerializeField] bool ledgeGrab;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        standingCollider = GetComponents<CapsuleCollider2D>()[0];
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponents<CapsuleCollider2D>()[0];
        direction = Vector2.zero;
        lastInput = 0;
        horizontalInput = 0;
        verticalInput = 0;
        currentSpeed = speed;
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
                horizontalInput = 0;
                horizontalInput = Input.GetAxisRaw("Horizontal");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
                Push();
                Crouch();
            }
        }


        playerAnimator.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));
        playerAnimator.SetFloat("verticalInput", Mathf.Abs(verticalInput));

        if (pullGrab)
        {
            playerAnimator.SetBool("IsPush", true);
        }
        if (!pullGrab)
        {
            playerSprite.flipX = (lastInput < 0) ? true : false;
        }

        direction = new Vector2(horizontalInput, verticalInput);
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
            if (ledgeGrab)
            {

            }
            else if (!ledgeGrab)
            {
                Move();
            }
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
        playerRb.velocity = new Vector2(currentSpeed * direction.x, playerRb.velocity.y);
        // playerRb.velocity = Vector2.right * Mathf.Ceil(direction.x) * currentSpeed;

    }

    void Climb()
    {
        // playerRb.MovePosition((Vector2)transform.position + (direction * currentSpeed) * Time.deltaTime);
        playerRb.velocity = Vector2.up * direction * 2.0f;
    }
    void Jump()
    {
        playerAnimator.SetTrigger("Jump");
        // playerRb.velocity = Vector2.up * jumpVelocity;
        playerRb.AddForce(new Vector2(0, jumpVelocity));
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
            currentSpeed = 1f;
        }

        else if (!hitr && !hitl)
        {
            playerAnimator.SetBool("IsCrouch", false);
            playerAnimator.SetBool("IsStanding", true);
            crouchFlag = false;
            currentSpeed = speed;
        }
        standingCollider.enabled = !crouchFlag;
    }

    void Ledge()
    {
        isTouchLedge = Physics2D.Raycast(ledgeCheck.position, transform.right*lastInput, distance, objectMask);
        isTouchWall = Physics2D.Raycast(wallCheck.position, transform.right*lastInput, distance, objectMask);

        if (!isTouchLedge&&isTouchWall)
        {
            ledgeGrab = true;
            playerRb.velocity = Vector2.zero;
            playerRb.gravityScale = 0;
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
                ledgeGrab = false;
            }
        }     
    }

    void Push()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(pushCheck.position,transform.right*lastInput, distance, objectMask);
        RaycastHit2D hit1 = Physics2D.Raycast(pushCheck.position+Vector3.left,transform.right, 3f, objectMask);
        if (hit.collider != null && hit.collider.gameObject.tag == "pushAble")
        {
            playerAnimator.SetBool("IsPush", true);
            box = hit.collider.gameObject;
            if (Input.GetButtonDown("Push"))
            {
                pullGrab = true;
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            }
            else if(Input.GetButtonUp("Push"))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                pullGrab = false;
                playerAnimator.SetBool("IsPush", false);
            }
        }
        else 
        {
            if (Input.GetButtonUp("Push"))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                pullGrab = false;
                playerAnimator.SetBool("IsPush", false);
                //box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            }
            playerAnimator.SetBool("IsPush", false);
        }
    }

    #endregion



    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + 0.1f, LayerMask.GetMask("Floor"));

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
