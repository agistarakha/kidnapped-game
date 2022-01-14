using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowedModeConf : MonoBehaviour
{
    TMP_Text[] texts;
    // Start is called before the first frame update
    void OnEnable()
    {
        texts = GetComponentsInChildren<TMP_Text>();

        Button[] buttons = transform.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(() => Screen.fullScreenMode = FullScreenMode.Windowed);
        buttons[1].onClick.AddListener(() => Screen.fullScreenMode = FullScreenMode.FullScreenWindow);
        buttons[0].onClick.AddListener(() => SetTextAlpha(0));
        buttons[1].onClick.AddListener(() => SetTextAlpha(1));
        FullScreenCheck();



    }

    void OnDisable()
    {
        Button[] buttons = transform.GetComponentsInChildren<Button>();
        buttons[0].onClick.RemoveAllListeners();
        buttons[1].onClick.RemoveAllListeners();
    }


    private void SetTextAlpha(int mode)
    {
        if (mode == 0)
        {
            texts[0].alpha = 1f;
            texts[1].alpha = 0.5f;
        }
        else if (mode == 1)
        {
            texts[1].alpha = 1f;
            texts[0].alpha = 0.5f;
        }
    }
    private void FullScreenCheck()
    {
        if (Screen.fullScreenMode == FullScreenMode.Windowed)
        {
            texts[0].alpha = 1f;
            texts[1].alpha = 0.5f;
        }
        else if (Screen.fullScreenMode == FullScreenMode.FullScreenWindow)
        {
            texts[1].alpha = 1f;
            texts[0].alpha = 0.5f;
        }
    }


    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(Screen.fullScreenMode);
    // }
}
