using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };

    private int pos;
    private string buttonName, buttonValue;
    void Start()
    {
        buttonName = gameObject.name;
        pos = buttonName.IndexOf("_");
        buttonValue = buttonName.Substring(0, pos);
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        ButtonPressed(buttonValue);
    }
}
