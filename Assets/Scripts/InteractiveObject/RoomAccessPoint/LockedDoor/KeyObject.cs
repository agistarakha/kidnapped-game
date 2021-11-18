using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyObject : InteractiveObject
{
    [SerializeField]
    private Key.typeKey type;


    public Key.typeKey GetKeyType()
    {
        return type;
    }

    public string dialogText;


    void Awake()
    {
        if (Player.obtainedKeys.Contains(GetKeyType()))
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            // PopUpUIManager.Instance.backdrop.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => DialogManager.Instance.ShowDialogUI(dialogText));
            DialogManager.Instance.ShowDialogUI(dialogText);
            Player.obtainedKeys.Add(GetKeyType());
            gameObject.SetActive(false);
        }
    }
}
