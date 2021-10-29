using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPlatform : MonoBehaviour
{

    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.currentState == Player.PlayerState.CLIMBING)
        {
            col.enabled = false;
        }
        else if (Player.currentState == Player.PlayerState.WANDER)
        {
            col.enabled = true;
        }
    }
}
