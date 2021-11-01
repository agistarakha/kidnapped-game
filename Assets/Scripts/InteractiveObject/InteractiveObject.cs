using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string promptText;
    public PromptManager promptManager;
    protected bool playerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        promptManager = FindObjectOfType<PromptManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            promptManager.ShowPromt(promptText);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            PlayerExitFeedback();
            promptManager.HidePrompt();
        }
    }

    public virtual void PlayerEnterFeedback()
    {

    }

    public virtual void PlayerExitFeedback()
    {

    }

}
