using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    [SerializeField]
    private Key.typeKey typeKey;

    public Key.typeKey GetTypeKey()
    {
        return typeKey;
    }

    public void OpenDoor()
    {
        //transform.Translate(0, -5, Time.deltaTime);
        gameObject.SetActive(false);
    }
}
