using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static bool isPlayerMoveable = false;
    public static Vector3 lastPos = Vector3.zero;
    public enum PlayerState
    {
        EXAMINE,
        WANDER,
        CLIMBING,
    }

    public enum GameState
    {
        MENU,
        GAMEPLAY,
        DIALOG
    }
    public static PlayerState currentState = PlayerState.WANDER;
    public static PlayerState sceneState = PlayerState.WANDER;
    public static GameState gameState = GameState.GAMEPLAY;
    public static List<Key.typeKey> obtainedKeys = new List<Key.typeKey>();
    public static Dictionary<string, string> obtainedNotes = new Dictionary<string, string>();
    public static List<string> unlockedDoors = new List<string>();
    public static bool gameIsInitiated = false;
    public static List<string> revealedDialog = new List<string>();
    public static Dictionary<string, Vector3> boxesPos = new Dictionary<string, Vector3>();

    public static bool isSaveGame = false;
    public static bool isLoadGame = false;
    public static bool isScreenShakingEnded = false;
}
