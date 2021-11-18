using UnityEngine;
using UnityEngine.UI;

public class PromptManager : MonoBehaviour
{
    private Text promptTextUI;
    public Image promtPanel;


    void Start()
    {
        promptTextUI = promtPanel.gameObject.GetComponentInChildren<Text>();
    }
    public void ShowPromt(string text)
    {
        promtPanel.gameObject.SetActive(true);
        promptTextUI.text = text;
    }

    public void HidePrompt()
    {
        promtPanel.gameObject.SetActive(false);
    }
}
