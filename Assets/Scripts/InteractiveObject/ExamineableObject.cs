using UnityEngine;
using UnityEngine.UI;

public class ExamineableObject : InteractiveObject
{
    public enum ObjectTypes
    {
        FIGURA,
        COMMON
    }

    public ObjectTypes objectTypes;
    [TextArea(5, 100)]
    public string dialogText;
    public Sprite photoSprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (objectTypes == ObjectTypes.FIGURA)
            {

                GameObject fotoUI = PopUpUIManager.Instance.ActivateUI(photoSprite);
                fotoUI.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => DialogManager.Instance.ShowDialogUI(dialogText));
            }
            else
            {
                DialogManager.Instance.ShowDialogUI(dialogText);
            }
        }
    }


}
