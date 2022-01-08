using UnityEngine;
using UnityEngine.UI;

public class PromptManager : MonoBehaviour
{
    private Text promptTextUI;
    public Image promtPanel;


    void Start()
    {
        // promptTextUI = promtPanel.gameObject.GetComponentInChildren<Text>();
    }
    public void ShowPromtBetter(string text, Vector3 objPos)
    {
        promtPanel.gameObject.SetActive(true);
        promtPanel.rectTransform.localPosition = objPos + new Vector3(0, 1, 0);
        promptTextUI.text = text;
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
