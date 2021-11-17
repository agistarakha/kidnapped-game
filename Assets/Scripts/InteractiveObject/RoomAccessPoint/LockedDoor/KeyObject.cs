using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : InteractiveObject
{
    [SerializeField]
    private Key.typeKey type;


    public Key.typeKey GetKeyType()
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            Player.obtainedKeys.Add(GetKeyType());
            gameObject.SetActive(false);
        }
    }
}
