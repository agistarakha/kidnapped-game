using UnityEngine;

/// <summary>
/// Class <c>InteractiveObject</c> merupakan kerangka utama untuk membuat objek interaktif yang lebih spesifik.
/// </summary>
public class InteractiveObject : MonoBehaviour
{
    /// <value>
    /// Property <c>playerInRange</c> merupakan variable yang merepresentasikan apakah player berada pada area interaktif objek.
    /// </value>
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
    void Start()
    {
        StartFunExtension();
        objImg = GetComponent<SpriteRenderer>();
        oriColor = objImg.color;
        enterColor = new Color(0.5f, 0.5f, 0.5f, oriColor.a);
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


    /// <summary>
    /// Method <c>PlayerEnterFeedback</c> digunakan untuk memberikan reaksi ketika player berada pada area interaktif objek.
    /// <example>
    /// Contoh pada object yang menampilkan tutorial apabila player berada pada area object.
    /// <code>
    /// public override void PlayerEnterFeedback()
    ///{
    ///    if (!Player.revealedTutorial.Contains(tutorialUI))
    ///    {
    ///        Player.revealedTutorial.Add(tutorialUI);
    ///        TutorialManager.Instance.ShowTutorialUI(tutorialUI);
    ///        GetComponent<BoxCollider2D>().enabled = false;
    ///    }
    ///}
    /// </code>
    /// </example>
    /// </summary>
    public virtual void PlayerEnterFeedback()
    {

    }


    /// <summary>
    /// Method <c>PlayerExitFeedback</c> digunakan untuk memberikan reaksi ketika player keluar dari area interaktif objek.
    /// <example>
    /// Contoh pada object tangga yang mengubah animasi memanjat menjadi animasi idle ketika Player keluar dari area tangga
    /// <code>
    ///public override void PlayerExitFeedback()
    ///{
    ///player.GetComponent<Animator>().Play("V2IdleAnimation");
    ///Player.currentState = Player.PlayerState.WANDER;
    ///player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    ///GetComponents<BoxCollider2D>()[0].enabled = true;
    ///}
    /// </code>
    /// </example>
    /// </summary>
    public virtual void PlayerExitFeedback()
    {

    }



    /// <summary>
    /// Method <c>StartFunExtension</c> digunakan untuk menambah kode yang akan digunakan pada fungsi <c>Start()</c>
    /// <example>
    /// Contohnya ketika ingin memberi data tujuan pintu pada object pintu
    /// </example>
    /// </summary>
    public virtual void StartFunExtension()
    {

    }

}
