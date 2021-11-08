using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static Vector3 lastPos = Vector3.zero;
    public enum PlayerState
    {
        EXAMINE,
        WANDER,
        CLIMBING,
    }
    public static PlayerState currentState = PlayerState.WANDER;
    public static PlayerState sceneState = PlayerState.WANDER;
    public static List<Key.typeKey> obtainedKeys = new List<Key.typeKey>();
}
