using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;


/// <summary>
/// Class ini digunakan untuk melakukan konfigurasi awal ketika sebuah Scene dimuat.
/// Konfigurasi yang dilakukan yaitu: Mengatur kamera, Mengatur posisi dan state player, Mengatur posisi object interactive yang dinamis.
/// </summary>
public class GameManager : MonoBehaviour
{
    // public static GameManager _instance = null;
    // public static GameManager Instance
    // {
    //     get
    //     {
    //         if (_instance == null)
    //         {
    //             _instance = FindObjectOfType<GameManager>();
    //         }
    //         return _instance;
    //     }
    // }

    public GameObject playerPrefab;
    public CinemachineVirtualCamera vCam;
    public Text roomInfo;
    public Transform spawnPoint = null;

    void Awake()
    {
        Camera.main.backgroundColor = Color.black;
    }

    // Start is called before the first frame update
    void Start()
    {
        //BGMManager.instance.Play();
        if (Player.gameIsInitiated == false)
        {
            StartCoroutine(DispayFirstTutorial());
        }
        Vector3 spawnPos;
        if (spawnPoint == null || Player.gameIsInitiated)
        {
            spawnPos = GameObject.Find(DoorData.doorSpawnLocation).transform.position;
        }
        else
        {
            spawnPos = spawnPoint.position;
            Player.gameIsInitiated = true;
        }
        // Vector3 spawnPos = (Player.sceneState == Player.PlayerState.EXAMINE) ?
        // Player.lastPos :
        // GameObject.Find(DoorData.doorSpawnLocation).transform.position;
        // Debug.Log(Player.currentState == Player.PlayerState.EXAMINE);
        GameObject player = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        Player.currentState = Player.PlayerState.WANDER;
        // Player.gameState = Player.GameState.MENU;
        // StartCoroutine(MoveDelay());
        Player.sceneState = Player.PlayerState.WANDER;
        vCam.Follow = player.transform;
        // roomInfo.text = "";
        OptionDataManager.Load();
        AudioManager.instance.GetAudioSource().volume = OptionDataManager.Option.sfxVolume;
        CharacterAudio.instances.GetAudioSource().volume = OptionDataManager.Option.sfxVolume;
        BGMManager.instance.GetAudioSource().volume = OptionDataManager.Option.musicVolume;

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("pushAble");
        if (boxes.Length > 0 && Player.boxesPos.Count > 0)
        {
            foreach (KeyValuePair<string, Vector3> box in Player.boxesPos)
            {
                GameObject obj = null;
                if (box.Key.Contains(SceneManager.GetActiveScene().name))
                {

                    string boxName = box.Key.Replace(SceneManager.GetActiveScene().name, "");
                    obj = GameObject.Find(boxName).gameObject;
                    Debug.Log(obj);
                }
                if (obj != null)
                {
                    Debug.Log("Ori Pos :" + obj.transform.position);
                    obj.transform.position = box.Value;
                    Debug.Log("Final Pos: " + obj.transform.position);
                }
            }
        }

    }


    // private IEnumerator MoveDelay()
    // {
    //     yield return new WaitForSeconds(2f);
    //     Player.gameState = Player.GameState.MENU;
    // }

    /// <summary>
    /// Digunakan untuk menampilkan tutorial awal ketika player melakukan new game
    /// </summary>
    /// <returns>Tutorial dtiampilkan dengan delay 4 detik</returns>
    private IEnumerator DispayFirstTutorial()
    {
        yield return new WaitForSeconds(4f);
        TutorialManager.Instance.ShowTutorialUI(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Player.currentState);
        // Debug.Log()
    }
}
