using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string promptText;
    public PromptManager promptManager;
    protected bool playerInRange = false;
    protected GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartFunExtension();
        playerInRange = false;
        promptManager = FindObjectOfType<PromptManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerEnterFeedback();
            player = other.gameObject;
            promptManager.ShowPromt(promptText);
            playerInRange = (Player.gameState == Player.GameState.GAMEPLAY) ? true : false;

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

    public virtual void StartFunExtension()
    {

    }

}
