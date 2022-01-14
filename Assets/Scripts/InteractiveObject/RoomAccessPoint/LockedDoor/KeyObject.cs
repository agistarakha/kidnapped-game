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

    void Awake()
    {
        if (Player.obtainedKeys.Contains(GetKeyType()))
        {
            //gameObject.SetActive(false);
            GetComponent<ExamineableObject>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }
    void Update()
    {
        if (Player.obtainedKeys.Contains(GetKeyType()) && GetComponent<ExamineableObject>().isUIShown)
        {
            //gameObject.SetActive(false);
            GetComponent<ExamineableObject>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && Player.currentState != Player.PlayerState.JUMPING)
        {
            // PopUpUIManager.Instance.backdrop.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => DialogManager.Instance.ShowDialogUI(dialogText));
            //DialogManager.Instance.ShowDialogUI(dialogText);
            // Audio ketika mengambil kunci
            if (GetComponent<ExamineableObject>().enabled)
            {
                AudioManager.instance.PlaySFX("Kunci");
                Player.obtainedKeys.Add(GetKeyType());

            }
            // GetComponent<ExamineableObject>().enabled = false;
            // GetComponent<BoxCollider2D>().enabled = false;
            // this.enabled = false;
            //gameObject.SetActive(false);
        }
    }
}
