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
    private bool isPopUpActive = false;



    // Start is called before the first frame update
    void Start()
    {
        currentActiveObject = null;
        GenerateUI();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isPopUpActive && Player.gameState == Player.GameState.MENU)
        {
            Player.gameState = Player.GameState.GAMEPLAY;
        }
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Escape)) && Player.gameState == Player.GameState.MENU)
        {
            for (int i = 0; i < backdrop.transform.childCount; i++)
            {
                GameObject childObj = backdrop.transform.GetChild(i).gameObject;
                if (childObj.activeSelf)
                {
                    if (childObj.name == "Photo(Clone)")
                    {
                        childObj.transform.GetChild(0).GetComponent<Button>().onClick.Invoke();

                    }
                    backdrop.transform.GetChild(i).gameObject.SetActive(false);
                    backdrop.SetActive(false);
                    isPopUpActive = false;

                    break;
                }
            }
        }
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
        //Debug.Log(name);
        isPopUpActive = true;
        Player.gameState = Player.GameState.MENU;

        for (int i = 0; i < popUpObjects.Count; i++)
        {
            GameObject obj = backdrop.transform.GetChild(i).gameObject;
            //Debug.Log(obj.name);
            if (name + "(Clone)" == obj.name)
            {
                backdrop.SetActive(true);
                obj.SetActive(true);
                Debug.Log(backdrop.activeSelf);
                Debug.Log(obj.activeSelf);
                currentActiveObject = obj;
                StartCoroutine(PopUpAnim(currentActiveObject.GetComponent<RectTransform>()));

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
        isPopUpActive = true;
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
                StartCoroutine(PopUpAnim(currentActiveObject.GetComponent<RectTransform>()));
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


    private IEnumerator gaemStateDelay()
    {

        yield return null;
    }

    private IEnumerator PopUpAnim(RectTransform rect)
    {
        Vector3 oriPos = rect.position;
        rect.position = new Vector3(rect.position.x, rect.position.y - (rect.position.y * 2), rect.position.z);

        while (rect.position.y != oriPos.y)
        {
            rect.position = Vector3.Lerp(rect.position, oriPos, 3f * Time.deltaTime);
            yield return null;
        }
        rect.position = oriPos;

    }
}

