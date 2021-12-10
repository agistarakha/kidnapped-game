using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 lastPos;
    public string lastVisitedScene;
    public List<Key.typeKey> obtainedKeys;
    public Dictionary<string, string> obtainedNotes;
    public List<string> unlockedDoors;

}

