using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager _instance = null;
    public static DialogManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DialogManager>();
            }
            return _instance;
        }
    }

    public GameObject dialogUIObject;


    private Text dialogText;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HideDialogUI();
        }
    }

    public void ShowDialogUI(string text)
    {
        dialogText = dialogUIObject.transform.GetChild(0).GetComponent<Text>();
        dialogText.text = "";
        //Player.gameState = Player.GameState.DIALOG;
        dialogUIObject.SetActive(true);
        StartCoroutine(GenerateDialogText(text));
    }
    public void HideDialogUI()
    {
        //Player.gameState = Player.GameState.GAMEPLAY;
        dialogUIObject.SetActive(false);
    }

    private IEnumerator GenerateDialogText(string text)
    {
        foreach (char txt in text)
        {
            dialogText.text += txt;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
