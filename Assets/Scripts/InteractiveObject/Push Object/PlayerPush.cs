using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 5f;
    public LayerMask objectMask;

    private GameObject box;
    private Animator playerAnimator;
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up,
            Vector2.right*distance*Input.GetAxisRaw("Horizontal"), distance, objectMask);
        if(hit.collider != null && hit.collider.gameObject.tag=="pushAble")
        {
            playerAnimator.SetBool("IsPush", true);
            box = hit.collider.gameObject;
            if (Input.GetButtonDown("Push"))
            {
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            }
        }
        else
        {
             if (Input.GetButtonUp("Push"))
             {
                box.GetComponent<FixedJoint2D>().enabled = false;
                playerAnimator.SetBool("IsPush", false);
                //box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
             }
            playerAnimator.SetBool("IsPush", false);
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position+Vector3.up, (Vector2)transform.position +Vector2.right * distance * Input.GetAxisRaw("Horizontal"));
    }
}
