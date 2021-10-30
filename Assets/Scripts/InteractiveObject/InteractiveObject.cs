using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string promptText;
    private PromptManager promptManager;
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
            Feedback();
            promptManager.HidePrompt();
        }
    }

    public virtual void Feedback ()
    {

    }
        
}
