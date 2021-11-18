using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private typeKey type;

    public enum typeKey
    {
        Red,
        Blue,
        Green,
        Lever
    }

    public typeKey GetKeyType()
    {
        return type;
    }


    void Awake()
    {
        if (Player.obtainedKeys.Contains(GetKeyType()))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.obtainedKeys.Add(GetKeyType());
            gameObject.SetActive(false);
        }
    }
}
