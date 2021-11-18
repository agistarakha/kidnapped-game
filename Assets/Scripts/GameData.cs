using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [System.Serializable]
    public struct PlayerData
    {
        public Vector3 lastPos;
        public string lastVisitedScene;
        public List<Key.typeKey> obtainedKeys;
    }

}

