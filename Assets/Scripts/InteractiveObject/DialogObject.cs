using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogObject : InteractiveObject
{
    [TextArea(5, 100)]
    public string dialogText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            DialogManager.Instance.ShowDialogUI(dialogText);
        }
    }
}
