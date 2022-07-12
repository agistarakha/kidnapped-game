using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
/// Class <c>GameDataManager</c> berisi fungsi-fungsi yang dapat digunakan untuk melakukan save, looad, dan reset data.
/// </summary>
public static class GameDataManager
{
    


    /// <summary>
    /// Digunakan untuk load file yang berisi save data dengan cara mengubah file JSON ke object.
    /// </summary>
    /// <returns><code>true</code> apabila terdapat save file</returns>
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
            Player.gameIsInitiated = gameData.gameIsInitiated;
            DoorData.lastVisitedScene = gameData.lastVisitedScene;
            DoorData.doorSpawnLocation = gameData.doorSpawnLocation;
            Player.lastPos = gameData.lastPos;
            Player.obtainedKeys = gameData.obtainedKeys;
            Player.unlockedDoors = gameData.unlockedDoors;
            Player.revealedDialog = gameData.revealedDialog;
            Player.revealedTutorial = gameData.revealedTutorial;
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

    /// <summary>
    /// Digunakan untuk menyimpan data game ke sebuah file JSON.
    /// </summary>
    /// <param name="playerGameObject">Parameter ini merupakan parameter Gameobject player. Paramter ini digunakan untuk mendapatkan data posisi player terakhir</param>
    public static void SaveFile(GameObject playerGameObject)
    {
        // GameData gameData = new GameData();
        string saveFile = Application.persistentDataPath + "/gamedata.json";

        GameData gameData = new GameData();
        gameData.gameIsInitiated = Player.gameIsInitiated;
        gameData.doorSpawnLocation = DoorData.doorSpawnLocation;
        gameData.lastPos = playerGameObject.GetComponent<Rigidbody2D>().transform
        .position;
        gameData.lastVisitedScene = DoorData.lastVisitedScene;
        gameData.obtainedKeys = Player.obtainedKeys;
        gameData.unlockedDoors = Player.unlockedDoors;
        gameData.revealedDialog = Player.revealedDialog;
        gameData.revealedTutorial = Player.revealedTutorial;
        gameData.boxesPos = Player.boxesPos.Values.ToArray<Vector3>();
        gameData.boxesName = Player.boxesPos.Keys.ToArray<string>();
        gameData.obtainedNotesTitle = Player.obtainedNotes.Keys.ToArray<string>();
        gameData.obtainedNotesContent = Player.obtainedNotes.Values.ToArray<string>();
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(gameData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }

    /// <summary>
    /// Digunakan untuk mereset save data dengan melakukan inisialisasi ulang data pada data video game dan menghapus file save. Contohnya digunakan saat New Game
    /// </summary>
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
        Player.revealedTutorial = new List<int>();
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
