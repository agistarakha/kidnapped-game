
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpVelocity = 2.0f;
    public Transform ledgeCheck;
    public Transform wallCheck;
    public Transform pushCheck;
    public Transform boxCheck;
    public LayerMask objectMask;
    private Collider2D standingCollider;

    private AudioSource walkSound;
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
    [SerializeField] bool isTouchBox;
    [SerializeField] bool isTouchPush;

    private Vector2 ledgePosBot;
    private Vector2 ledgePos1;

    public float timer = -99f;
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
        walkSound = GetComponent<AudioSource>();
        direction = Vector2.zero;
        lastInput = 0;
        horizontalInput = 0;
        verticalInput = 0;
        currentSpeed = speed;
    }

    void Update()
    {
        // if (timer > 0)
        // {
        //     timer -= Time.deltaTime;
        //     //transform.position = ledgePos1;
        //     return;
        // }
        if (!Player.isPlayerMoveable)
        {
            playerRb.velocity = Vector2.zero;
            playerAnimator.Play("V2IdleAnimation");
            return;
        }
        horizontalInput = 0;
        verticalInput = 0;
        playerAnimator.SetFloat("yVelocity", playerRb.velocity.y);
        // Debug.Log(playerRb.velocity.y);
        // Debug.Log(Player.currentState);
        if ((Player.gameState == Player.GameState.MENU) || (Player.gameState == Player.GameState.DIALOG))
        {
            playerRb.velocity = Vector2.zero;
            playerAnimator.Play("V2IdleAnimation");
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
            // playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            // playerRb.velocity = new Vector2(playerRb.velocity.x,0);
            playerAnimator.SetBool("IsClimbing", false);
            playerAnimator.SetBool("IsStanding", true);

            playerRb.gravityScale = 1;
            if (IsGrounded())
            {
                horizontalInput = 0;
                horizontalInput = Input.GetAxisRaw("Horizontal");
                Push();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
                // Crouch();
                playerAnimator.SetBool("IsJumping", false);
                playerAnimator.SetFloat("yVelocity", 0);
                //timer = 2f;

            }
            if (!IsGrounded())
            {
                //Debug.Log(playerRb.velocity.y);

                //playerAnimator.SetTrigger("Jump");
                if (!ledgeGrab)
                {
                    playerAnimator.SetBool("IsJumping", true);
                }
            }
        }

        //Debug.Log(playerRb.velocity);
        playerAnimator.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));
        playerAnimator.SetFloat("verticalInput", Mathf.Abs(verticalInput));

        if (pullGrab)
        {
            playerAnimator.SetBool("IsPull", true);
            if (playerSprite.flipX == true)
            {
                if (playerRb.velocity.x < 0)
                {
                    horizontalInput = 0;
                }
            }
            else if (playerSprite.flipX == false)
            {
                if (playerRb.velocity.x > 0)
                {
                    horizontalInput = 0;
                }
            }
        }
        else if (!pullGrab)
        {
            playerSprite.flipX = (lastInput < 0) ? true : false;
        }
        Ledge();

        if (ledgeGrab)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.gravityScale = 0;
        }
        else if (!ledgeGrab)
        {
            // Debug.Log("lepas");
            playerAnimator.SetBool("IsGrabLedge", false);
        }
        direction = new Vector2(horizontalInput, verticalInput);
        if (box != null)
        {
            Player.boxesPos[SceneManager.GetActiveScene().name + box.name] = box.transform.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Player.isPlayerMoveable) return;
        if ((Player.gameState == Player.GameState.MENU) || (Player.gameState == Player.GameState.DIALOG))
        {
            //Debug.Log("Yo dud");
            playerRb.velocity = Vector2.zero;
            playerAnimator.Play("V2IdleAnimation");
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
        //walkSound.PlayOneShot(walkSound.clip);
        // playerRb.velocity = Vector2.right * Mathf.Ceil(direction.x) * currentSpeed;
        //Debug.Log(playerRb.velocity.x);

    }

    void Climb()
    {
        // playerRb.MovePosition((Vector2)transform.position + (direction * currentSpeed) * Time.deltaTime);
        playerRb.velocity = Vector2.up * direction * 2.0f;
    }
    void Jump()
    {
        playerAnimator.SetBool("IsJumping", true);
        //playerAnimator.SetTrigger("Jump");
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
        isTouchLedge = Physics2D.Raycast(ledgeCheck.position, transform.right * lastInput, distance, objectMask);
        isTouchWall = Physics2D.Raycast(wallCheck.position, transform.right * lastInput, distance, objectMask);
        if (isTouchWall && !isTouchLedge)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("tembok");
                ledgeGrab = true;
                pullGrab = false;
                playerAnimator.SetBool("IsGrabLedge", true);
            }
        }
        else
        {
            ledgeGrab = false;
            //Debug.Log("lepas");
        }
    }

    void Box()
    {
        isTouchBox = Physics2D.Raycast(boxCheck.position, transform.right * lastInput, distance, objectMask);
        isTouchPush = Physics2D.Raycast(pushCheck.position, transform.right * lastInput, distance, objectMask);

        if (!isTouchBox && isTouchPush)
        {

            ledgeGrab = true;
            //playerAnimator.SetTrigger("IsGrabLedge1");
            playerAnimator.SetBool("IsGrabLedge", true);
            playerRb.velocity = Vector2.zero;
            playerRb.gravityScale = 0;
            ledgePosBot = boxCheck.position;
            if (lastInput < 0)
            {
                //ledgePos1 = new Vector2(Mathf.Floor(ledgePosBot.x - 1f) + ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset1);
            }
            else if (lastInput > 0)
            {
                //ledgePos1 = new Vector2(Mathf.Floor(ledgePosBot.x + 1f) + ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset1);
            }

        }
        else if (!isTouchBox && !isTouchPush)
        {
            ledgeGrab = false;
            //playerAnimator.SetBool("IsGrabLedge", false);
        }
    }

    void Push()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(pushCheck.position, transform.right * lastInput, distance, objectMask);
        RaycastHit2D hit1 = Physics2D.Raycast(pushCheck.position + Vector3.left, transform.right, 3f, objectMask);
        if (hit.collider != null && hit.collider.gameObject.tag == "pushAble")
        {
            if (Input.GetButtonDown("Push"))
            {
                pullGrab = true;
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                playerAnimator.SetBool("IsPull", true);
                playerAnimator.SetBool("IsPush", false);
            }
            else if (Input.GetButtonUp("Push"))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                pullGrab = false;
            }
            else
            {
                playerAnimator.SetBool("IsPull", false);
                playerAnimator.SetBool("IsPush", true);
                playerAnimator.SetBool("IsStanding", false);
                box = hit.collider.gameObject;

            }
        }
        else
        {
            if (Input.GetButtonUp("Push"))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                pullGrab = false;
                playerAnimator.SetBool("IsPush", false);
                playerAnimator.SetBool("IsPull", false);
                //box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            }
            playerAnimator.SetBool("IsPush", false);
            playerAnimator.SetBool("IsPull", false);


        }
    }

    #endregion

    public void AnimUp()
    {
        Vector3 targetPos = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y + 1, 0);
        playerRb.MovePosition(targetPos);
    }
    public void AnimSide()
    {
        if (lastInput < 0)
        {
            Vector3 targetPos = new Vector3(playerRb.transform.position.x - 1, playerRb.transform.position.y, 0);
            playerRb.MovePosition(targetPos);
        }
        else if (lastInput > 0)
        {
            Vector3 targetPos = new Vector3(playerRb.transform.position.x + 1, playerRb.transform.position.y, 0);
            playerRb.MovePosition(targetPos);
        }
    }

    public void footstepPlay()
    {
        //walkSound.Play();
        //walkSound.PlayOneShot(walkSound.clip);
        AudioManager.instance.PlayLoopSFX("Mlaku");
    }
    public void footstepStop()
    {
        //walkSound.Stop();
        AudioManager.instance.StopLoopSFX("Mlaku");
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + 0.1f, LayerMask.GetMask("Floor"));

        //If something was hit.
        if (hit)
        {

            Player.currentState = Player.PlayerState.WANDER;
            return true;

        }

        return false;

    }
}
