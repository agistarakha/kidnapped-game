using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(transform.position.x - (125.1f - 120.8f), transform.position.y, transform.position.x);
        // StartCoroutine(SlideDoor());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SlideDoor()
    {

        while (transform.position.x != targetPos.x)
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

    }
}
