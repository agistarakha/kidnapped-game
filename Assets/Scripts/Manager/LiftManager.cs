using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftManager : MonoBehaviour
{

    public GameObject liftWall;
    private bool liftStopped;

    // Start is called before the first frame update
    void Start()
    {
        liftStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LiftDown(false));
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(LiftDown(true));
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            // liftStopped = true;
        }
    }
    private IEnumerator LiftDown(bool isUp)
    {
        // float mul = (isUp) ? 1f : -1f;
        // float offset = (-116.68f - -145.74f) * mul;
        Vector3 targetPos = new Vector3(liftWall.transform.position.x, liftWall.transform.position.y - 9999f, 0);
        //116.68
        //-145.74
        while (!liftStopped)
        {
            liftWall.transform.position = Vector3.Lerp(liftWall.transform.position, targetPos, 0.001f * Time.deltaTime);
            yield return null;
        }
    }
}
