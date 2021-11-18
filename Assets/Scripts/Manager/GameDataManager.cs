using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class GameDataManager
{
    // Create a field for the save file.

    // Create a GameData field.



    public static bool LoadFile()
    {
        GameData.PlayerData playerData = new GameData.PlayerData();
        string saveFile = Application.persistentDataPath + "/gamedata.json";


        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            playerData = JsonUtility.FromJson<GameData.PlayerData>(fileContents);
            // Player.lastPos = gameData
            DoorData.lastVisitedScene = playerData.lastVisitedScene;
            Player.lastPos = playerData.lastPos;
            Player.obtainedKeys = playerData.obtainedKeys;
            return true;
        }
        return false;
    }

    public static void SaveFile(GameObject playerGameObject)
    {
        // GameData gameData = new GameData();
        string saveFile = Application.persistentDataPath + "/gamedata.json";

        GameData.PlayerData playerData = new GameData.PlayerData();
        playerData.lastPos = playerGameObject.GetComponent<Rigidbody2D>().transform
        .position;
        playerData.lastVisitedScene = DoorData.lastVisitedScene;
        playerData.obtainedKeys = Player.obtainedKeys;
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(playerData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }
}
