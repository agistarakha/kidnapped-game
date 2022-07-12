using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class yang memiliki fungsi untuk menampilkan UI tutorial
/// </summary>
public class TutorialManager : MonoBehaviour
{
    public static TutorialManager _instance = null;
    public static TutorialManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TutorialManager>();
            }
            return _instance;
        }
    }


    [SerializeField]
    private GameObject[] tutorialUIPrefabs;
    private GameObject canvasObj;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = null;
        canvasObj = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (obj != null)
        {
            if (((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && Player.gameState == Player.GameState.MENU))
            {
                if (obj.activeSelf)
                {
                    obj.SetActive(false);
                    StartCoroutine(BackToGameplayState());

                }

            }
        }
    }

    public void ShowTutorialUI(int index)
    {
        if (index == 2)
        {
            StartCoroutine(ShowTutorialUIDelay(index));
        }
        else
        {
            GameObject tutorialUI = tutorialUIPrefabs[index];
            obj = Instantiate(tutorialUI, tutorialUI.transform.position, Quaternion.identity, canvasObj.transform);
            obj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            Player.gameState = Player.GameState.MENU;
        }
    }

    private IEnumerator BackToGameplayState()
    {
        yield return new WaitForSeconds(0.25f);
        Player.gameState = Player.GameState.GAMEPLAY;
    }
    public IEnumerator ShowTutorialUIDelay(int index)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject tutorialUI = tutorialUIPrefabs[index];
        obj = Instantiate(tutorialUI, tutorialUI.transform.position, Quaternion.identity, canvasObj.transform);
        obj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        obj.GetComponentInChildren<Button>().onClick.AddListener(() => PopUpUIManager.Instance.isPopUpActive = false);
        PopUpUIManager.Instance.isPopUpActive = true;
        Player.gameState = Player.GameState.MENU;
    }


}
