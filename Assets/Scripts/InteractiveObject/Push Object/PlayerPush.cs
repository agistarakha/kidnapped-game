using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 5f;
    public LayerMask objectMask;

    private GameObject box;

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up,
            Vector2.right*distance*Input.GetAxisRaw("Horizontal"), distance, objectMask);
        if(hit.collider != null && hit.collider.gameObject.tag=="pushAble" && Input.GetKeyDown(KeyCode.R))
        {
            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            //box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position+Vector3.up, (Vector2)transform.position +Vector2.right * distance * Input.GetAxisRaw("Horizontal"));
    }
}
