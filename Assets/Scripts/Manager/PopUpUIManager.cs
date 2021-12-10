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
    public List<GameObject> popUpObjects;
    public GameObject currentActiveObject;
    private List<GameObject> generatedObjects;
    private Sprite photoSprite;



    // Start is called before the first frame update
    void Start()
    {
        currentActiveObject = null;
        GenerateUI();

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     DeactivateUI();
        // }
    }

    private void GenerateUI()
    {
        foreach (GameObject obj in popUpObjects)
        {
            GameObject generatedObj = Instantiate(obj, obj.transform.position, Quaternion.identity, backdrop.transform);
            generatedObj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }





    public GameObject ActivateUI(string name)
    {
        Player.gameState = Player.GameState.MENU;

        for (int i = 0; i < popUpObjects.Count; i++)
        {
            GameObject obj = backdrop.transform.GetChild(i).gameObject;
            if (name + "(Clone)" == obj.name)
            {
                backdrop.SetActive(true);
                obj.SetActive(true);
                currentActiveObject = obj;
                // if (name == "PauseMenu")
                // {
                //     // backBtn.gameObject.SetActive(false);
                //     currentActiveObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
                //     {
                //         DeactivateUI();
                //     });
                // }
                return currentActiveObject;
            }
        }
        return null;
    }

    public GameObject ActivateUI(Sprite img)
    {
        Player.gameState = Player.GameState.MENU;

        for (int i = 0; i < popUpObjects.Count; i++)
        {
            GameObject obj = backdrop.transform.GetChild(i).gameObject;
            if ("Photo(Clone)" == obj.name)
            {
                backdrop.SetActive(true);
                obj.GetComponent<Image>().sprite = img;
                obj.SetActive(true);
                currentActiveObject = obj;
                // if (name == "PauseMenu")
                // {
                //     // backBtn.gameObject.SetActive(false);
                //     currentActiveObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
                //     {
                //         DeactivateUI();
                //     });
                // }
                return currentActiveObject;
            }
        }
        return null;
    }


    public void DeactivateUI()
    {
        if (Player.gameState == Player.GameState.MENU)
        {
            // currentActiveObject.SetActive(false);
            // backdrop.SetActive(false);
            //backBtn.gameObject.SetActive(true);
            // Destroy(realButton.gameObject);
            // currentActiveObject = null;
            Player.gameState = Player.GameState.GAMEPLAY;
            // DialogManager.Instance.ShowDialogUI("Blabla");

        }
    }
}

