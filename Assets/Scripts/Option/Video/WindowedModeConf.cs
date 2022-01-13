using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowedModeConf : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Button[] buttons = transform.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(() => Screen.fullScreenMode = FullScreenMode.Windowed);
        buttons[1].onClick.AddListener(() => Screen.fullScreenMode = FullScreenMode.FullScreenWindow);

    }


    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(Screen.fullScreenMode);
    // }
}
