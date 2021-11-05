using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private typeKey type;

    public enum typeKey{
        Red,
        Blue,
        Green
    }

    public typeKey GetKeyType()
    {
        return type;
    }
}
