using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    // public string promptText;
    // public PromptManager promptManager;
    protected bool playerInRange = false;
    public bool PlayerInRange
    {
        get { return playerInRange; }
        set { playerInRange = value; }
    }
    protected GameObject player;
    protected SpriteRenderer objImg;
    protected Color oriColor;
    protected Color enterColor;
    // Start is called before the first frame update
    void Start()
    {
        StartFunExtension();
        objImg = GetComponent<SpriteRenderer>();
        oriColor = objImg.color;
        enterColor = Color.grey;
        playerInRange = false;
        // promptManager = FindObjectOfType<PromptManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            PlayerEnterFeedback();
            if (objImg != null)
            {
                objImg.color = enterColor;

            }

            // promptManager.ShowPromtBetter(promptText, gameObject.transform.position);
            playerInRange = (Player.gameState == Player.GameState.GAMEPLAY) ? true : false;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (objImg != null)
            {
                objImg.color = oriColor;

            }

            playerInRange = false;
            PlayerExitFeedback();
            // promptManager.HidePrompt();
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
