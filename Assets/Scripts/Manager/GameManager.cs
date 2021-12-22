
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;


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


    }

    // Start is called before the first frame update
    void Start()
    {
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
        Player.sceneState = Player.PlayerState.WANDER;
        vCam.Follow = player.transform;
        roomInfo.text = SceneManager.GetActiveScene().name;
        Player.isLoadGame = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Player.currentState);
        // Debug.Log()
    }
}
