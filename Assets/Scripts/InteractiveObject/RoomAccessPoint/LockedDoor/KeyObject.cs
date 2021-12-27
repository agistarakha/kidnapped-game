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

    //[TextArea(5, 100)]
    //public string dialogText;

    // void Awake()
    // {

    // }
    void Update()
    {
        if (Player.obtainedKeys.Contains(GetKeyType()) && GetComponent<ExamineableObject>().isUIShown)
        {
            //gameObject.SetActive(false);
            GetComponent<ExamineableObject>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            this.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            // PopUpUIManager.Instance.backdrop.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => DialogManager.Instance.ShowDialogUI(dialogText));
            //DialogManager.Instance.ShowDialogUI(dialogText);
            Player.obtainedKeys.Add(GetKeyType());
            // GetComponent<ExamineableObject>().enabled = false;
            // GetComponent<BoxCollider2D>().enabled = false;
            // this.enabled = false;
            //gameObject.SetActive(false);
        }
    }
}
