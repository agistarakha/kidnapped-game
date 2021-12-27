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
    public string[] obtainedNotesTitle;
    public string[] obtainedNotesContent;
    public List<string> unlockedDoors;
    public string[] boxesName;
    public Vector3[] boxesPos;

}

