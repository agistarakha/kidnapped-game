using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // Start is called before the first frame update
    void Start()
    {
        canvasObj = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowTutorialUI(int index)
    {
        GameObject tutorialUI = tutorialUIPrefabs[index];
        GameObject obj = Instantiate(tutorialUI, tutorialUI.transform.position, Quaternion.identity, canvasObj.transform);
        obj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        Player.gameState = Player.GameState.MENU;
    }


}
