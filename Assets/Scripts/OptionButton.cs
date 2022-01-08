using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    [SerializeField]
    private GameObject videoOption;

    [SerializeField]
    private GameObject audioOption;
    [SerializeField]
    private GameObject optionParent;
    private Button[] buttons;
    [SerializeField]
    private Color selectedColor;
    // private TMP_Text btnText;
    // Start is called before the first frame update
    void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        // selectedColor = buttons[0].colors.selectedColor;
        buttons[0].onClick.AddListener(() => ShowOption(videoOption));
        buttons[1].onClick.AddListener(() => ShowOption(audioOption));
        // buttons[2].onClick.AddListener(() => );
        buttons[3].onClick.AddListener(() => ShowPauseMenu());
        SetActiveColor();
    }

    void OnDisable()
    {
        Destroy(transform.parent.gameObject);
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    private void SetActiveColor()
    {
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => btn.GetComponent<Image>().color = selectedColor);
            btn.onClick.AddListener(() => btn.GetComponentInChildren<TMP_Text>().color = Color.white);
        }
    }
    private void ShowPauseMenu()
    {
        Destroy(transform.parent.gameObject);
        // PopUpUIManager.Instance.ActivateUI("PauseMenu");
        // transform.parent.gameObject.SetActive(false);
    }

    private void ShowOption(GameObject optionObj)
    {
        ResetOption();
        optionObj.SetActive(true);
    }

    private void ResetOption()
    {
        // RectTransform[] childern = transform.parent.GetComponentsInChildren<RectTransform>();
        // Debug.Log(childern.Length);
        // foreach (RectTransform child in childern)
        // {
        //     Debug.Log(child.gameObject.activeSelf);
        // }
        // if (transform.parent.GetChild(1).childCount > 0)
        // {
        foreach (Button btn in buttons)
        {
            btn.GetComponent<Image>().color = Color.white;
            btn.GetComponentInChildren<TMP_Text>().color = Color.black;
            // btn.onClick.AddListener(() => btn.GetComponent<Image>().color = selectedColor);
            // btn.onClick.AddListener(() => btn.GetComponentInChildren<TMP_Text>().color = Color.white);
        }
        for (int i = 0; i < optionParent.transform.childCount; i++)
        {
            GameObject obj = optionParent.transform.GetChild(i).gameObject;
            if (obj.activeSelf)
            {
                obj.SetActive(false);
            }
        }
        // }
    }
}
