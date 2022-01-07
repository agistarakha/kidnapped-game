using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        // buttons[0].onClick.AddListener(() => );
        // buttons[1].onClick.AddListener(() => );
        // buttons[2].onClick.AddListener(() => );
        buttons[3].onClick.AddListener(() => ShowPauseMenu());
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    private void ShowPauseMenu()
    {
        // PopUpUIManager.Instance.ActivateUI("PauseMenu");
        // transform.parent.gameObject.SetActive(false);
    }
}
