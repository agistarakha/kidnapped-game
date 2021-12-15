using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    public GameObject targetObj;
    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(transform.position.x - (123.1f - 120.8f) * -1f, transform.position.y, transform.position.z);
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
            gameObject.transform.position = Vector3.Lerp(transform.position, targetObj.transform.position, 0.5f * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

    }
}
