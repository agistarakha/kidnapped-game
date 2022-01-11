using System.Collections;
using System.Linq;
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
            Player.revealedDialog = gameData.revealedDialog;
            for (int i = 0; i < gameData.boxesName.Length; i++)
            {
                Player.boxesPos[gameData.boxesName[i]] = gameData.boxesPos[i];
            }
            for (int i = 0; i < gameData.obtainedNotesTitle.Length; i++)
            {
                Player.obtainedNotes[gameData.obtainedNotesTitle[i]] = gameData.obtainedNotesContent[i];
            }
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
        gameData.revealedDialog = Player.revealedDialog;
        gameData.boxesPos = Player.boxesPos.Values.ToArray<Vector3>();
        gameData.boxesName = Player.boxesPos.Keys.ToArray<string>();
        gameData.obtainedNotesTitle = Player.obtainedNotes.Keys.ToArray<string>();
        gameData.obtainedNotesContent = Player.obtainedNotes.Values.ToArray<string>();
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(gameData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }

    public static void ResetData()
    {
        // GameData gameData = new GameData();
        string saveFile = Application.persistentDataPath + "/gamedata.json";
        Player.gameIsInitiated = false;
        DoorData.lastVisitedScene = "Room-1_3";
        DoorData.lastVisitedScene = "D-1";
        Player.lastPos = Vector3.zero;
        Player.obtainedKeys = new List<Key.typeKey>();
        Player.unlockedDoors = new List<string>();
        Player.revealedDialog = new List<string>();
        Player.boxesPos = new Dictionary<string, Vector3>();
        Player.obtainedNotes = new Dictionary<string, string>();
        if (File.Exists(saveFile))
        {
            File.Delete(saveFile);

        }
        // for (int i = 0; i < gameData.boxesName.Length; i++)
        // {
        //     Player.boxesPos[gameData.boxesName[i]] = gameData.boxesPos[i];
        // }
        // for (int i = 0; i < gameData.obtainedNotesTitle.Length; i++)
        // {
        //     Player.obtainedNotes[gameData.obtainedNotesTitle[i]] = gameData.obtainedNotesContent[i];
        // }

    }
}
