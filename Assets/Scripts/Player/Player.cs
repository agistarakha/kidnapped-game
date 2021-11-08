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
        ONAIR
    }
    public static bool isJumpPointReached = false;
    public static bool isGrounded = true;
    public static bool isOnAir = false;
    public static PlayerState currentState = PlayerState.WANDER;
    public static PlayerState sceneState = PlayerState.WANDER;
}
