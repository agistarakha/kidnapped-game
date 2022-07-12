using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class <c>DialogManager</c> digunakan untuk mengatur Dialog Box.
/// </summary>
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

    /// <summary>
    /// Property yang diisi dengan prefab Object Dialog Box yang digunakan sebagai UI
    /// </summary>
    public GameObject dialogUIObject;

    /// <summary>
    /// Property yang digunakan untuk menggunakan komponen Text dari <c>dialogUIObject</c>
    /// </summary>
    private Text dialogText;

    /// <value>
    /// Property yang merepresentasikan apakah dialog box sedang aktif atau tidak
    /// </value>
    private bool isDialogActive = false;

    /// <summary>
    /// Property yang digunakan untuk menyimpan text yang akan ditampilkan pada dilaogBox
    /// </summary>
    private string fullText;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (!isDialogActive && Player.gameState == Player.GameState.DIALOG)
        {
            Player.gameState = Player.GameState.GAMEPLAY;
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && Player.gameState == Player.GameState.DIALOG)
        {
            if (fullText == dialogText.text)
            {
                HideDialogUI();
                isDialogActive = false;
            }
        }
    }


    /// <summary>
    /// Method <c>ShowDialogUI</c> digunakan untuk menampilkan UI dialog box
    /// </summary>
    /// <param name="text">text yang ditampilkan pada dialog box</param>
    public void ShowDialogUI(string text)
    {
        isDialogActive = true;
        Player.gameState = Player.GameState.DIALOG;
        dialogText = dialogUIObject.transform.GetChild(0).GetComponent<Text>();
        dialogText.text = "";
        //Player.gameState = Player.GameState.DIALOG;
        dialogUIObject.SetActive(true);
        StartCoroutine(GenerateDialogText(text));
    }


    /// <summary>
    /// Digunakan untuk menyembunyikan Dialog box UI
    /// </summary>
    public void HideDialogUI()
    {
        StopAllCoroutines();
        dialogText.text = "";
        //Player.gameState = Player.GameState.GAMEPLAY;
        dialogUIObject.SetActive(false);
    }


    /// <summary>
    /// Digunakan untuk menampilkan efek text yang ditampilkan karakter per karakter pada dialog box UI
    /// </summary>
    /// <param name="text">Text yang ditampilkan pada dialog box UI</param>
    /// <returns>Memberikan delay selama 0.001f tiap kali karakter ditampilkan</returns>
    private IEnumerator GenerateDialogText(string text)
    {
        fullText = text;
        foreach (char txt in text)
        {
            dialogText.text += txt;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
