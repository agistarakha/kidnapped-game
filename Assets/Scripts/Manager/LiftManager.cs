using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftManager : MonoBehaviour
{

    public GameObject liftWall;
    private bool liftStopped;
    private bool liftStart;

    // Start is called before the first frame update
    void Start()
    {
        liftStopped = false;
        liftStart = false;
        StartCoroutine(LiftDown(false));
        // CinemachineShake.Instance.ShakeCamera(3f, 1f);
        //Invoke("ShakeCameraInv", 4f);
        // StartCoroutine(CameraShakeDelay());
        // CinemachineShake.Instance.Invoke("ShakeCamera")

    }

    // Update is called once per frame
    void Update()
    {
        // if (liftStart)
        // {
        //}
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     StartCoroutine(LiftDown(false));
        // }
        // else if (Input.GetKeyDown(KeyCode.I))
        // {
        //     StartCoroutine(LiftDown(true));
        // }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LiftBond")
        {
            Player.isScreenShakingEnded = true;
            StopAllCoroutines();
            // liftStopped = true;
        }
    }
    private IEnumerator LiftDown(bool isUp)
    {
        yield return new WaitForSeconds(4f);
        // float mul = (isUp) ? 1f : -1f;
        // float offset = (-116.68f - -145.74f) * mul;
        Vector3 targetPos = new Vector3(liftWall.transform.position.x, liftWall.transform.position.y - 9999f, 0);
        //116.68
        //-145.74
        liftStart = true;
        CinemachineShake.Instance.ShakeCamera(2f, 1f);
        while (!liftStopped)
        {
            liftWall.transform.position = Vector3.Lerp(liftWall.transform.position, targetPos, 0.001f * Time.deltaTime);
            yield return null;
        }
    }


    private void ShakeCameraInv()
    {
        CinemachineShake.Instance.ShakeCamera(3f, 1f);

    }

    // private IEnumerator CameraShakeDelay()
    // {
    //     yield return new WaitForSeconds(4f);
    //     CinemachineShake.Instance.ShakeCamera(2f, 1f);

    // }
}
