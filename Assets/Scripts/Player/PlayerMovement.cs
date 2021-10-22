using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;


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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = 0;
        if (Player.currentState == Player.PlayerState.CLIMBING)
        {
            playerRb.gravityScale = 0;
            verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            playerRb.gravityScale = 10;
        }
        playerAnimator.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));
        playerAnimator.SetFloat("verticalInput", Mathf.Abs(verticalInput));
        playerSprite.flipX = (lastInput < 0) ? true : false;
        direction = new Vector2(horizontalInput, verticalInput);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        playerRb.MovePosition((Vector2)transform.position + (direction * speed) * Time.deltaTime);

    }

}
