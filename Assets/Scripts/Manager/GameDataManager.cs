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
        GameData gameData = new GameData();
        string saveFile = Application.persistentDataPath + "/gamedata.json";


        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            gameData = JsonUtility.FromJson<GameData>(fileContents);
            // Player.lastPos = gameData
            DoorData.lastVisitedScene = gameData.lastVisitedScene;
            Player.lastPos = gameData.lastPos;
            Player.obtainedKeys = gameData.obtainedKeys;
            Player.unlockedDoors = gameData.unlockedDoors;
            return true;
        }
        return false;
    }

    public static void SaveFile(GameObject playerGameObject)
    {
        // GameData gameData = new GameData();
        string saveFile = Application.persistentDataPath + "/gamedata.json";

        GameData gameData = new GameData();
        gameData.lastPos = playerGameObject.GetComponent<Rigidbody2D>().transform
        .position;
        gameData.lastVisitedScene = DoorData.lastVisitedScene;
        gameData.obtainedKeys = Player.obtainedKeys;
        gameData.unlockedDoors = Player.unlockedDoors;
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(gameData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }
}
