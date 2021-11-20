using UnityEngine;
using UnityEngine.UI;

public class ExamineableObject : InteractiveObject
{
    [TextArea(5, 100)]
    public string dialogText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            GameObject fotoUI = PopUpUIManager.Instance.ActivateUI("Foto");
            fotoUI.transform.parent.GetChild(5).GetComponent<Button>().onClick.AddListener(() => DialogManager.Instance.ShowDialogUI(dialogText));
        }
    }


}
