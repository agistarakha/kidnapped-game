using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class PopUpUIManager : MonoBehaviour
{
    public static PopUpUIManager _instance = null;
    public static PopUpUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PopUpUIManager>();
            }
            return _instance;
        }
    }
    /*
    - Definisi public pop Up apa saja yang dapat ditampilkan
    - Pada Update jika gameState == MENU maka tampilkan backdrop.
    - Membuat fungsi yang dapat melakukan aktivasi PopUp UI
        - Fungsi tersebut dipanggil pada object masing-masing.
    */
    public GameObject backdrop;
    public Button backBtn;
    public List<GameObject> popUpObjects;
    public GameObject currentActiveObject;



    // Start is called before the first frame update
    void Start()
    {
        currentActiveObject = null;

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     DeactivateUI();
        // }
    }



    public GameObject ActivateUI(string name)
    {
        Player.gameState = Player.GameState.MENU;
        foreach (GameObject obj in popUpObjects)
        {
            if (name == obj.name)
            {
                backdrop.SetActive(true);
                Button realBackBtn = Instantiate(backBtn, backBtn.transform.position, Quaternion.identity, backdrop.transform);
                realBackBtn.onClick.AddListener(() => DeactivateUI());
                obj.SetActive(true);
                currentActiveObject = obj;
                if (name == "PauseMenu")
                {
                    backBtn.gameObject.SetActive(false);
                    currentActiveObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
                    {
                        DeactivateUI();
                    });
                }
                return currentActiveObject;
            }
        }
        return null;
    }


    public void DeactivateUI()
    {
        if (Player.gameState == Player.GameState.MENU)
        {
            currentActiveObject.SetActive(false);
            backdrop.SetActive(false);
            backBtn.gameObject.SetActive(true);
            currentActiveObject = null;
            Player.gameState = Player.GameState.GAMEPLAY;
            // DialogManager.Instance.ShowDialogUI("Blabla");

        }
    }
}

