using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject optionUIPrefab;
    // public delegate void Delegate();
    // public Delegate LoadGameCall;
    // public Delegate NewGameCall;

    void Start()
    {
        //LoadGameCall = LoadGame;
        //NewGameCall = NewGame;
        //GetComponentsInChildren<Button>()[1].onClick.AddListener(() => GetComponentsInChildren<Button>()[1].Select());
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            return;
        }
        OptionDataManager.Load();
        AudioManager.instance.GetAudioSource().volume = OptionDataManager.Option.sfxVolume;
        CharacterAudio.instances.GetAudioSource().volume = OptionDataManager.Option.sfxVolume;

        if (!GameDataManager.LoadFile())
        {
            GetComponentInChildren<Button>().interactable = false;
            // GetComponent<Button>()
            //GetComponentInChildren<Image>().color = Color.gray;
        }
        GetComponentsInChildren<Button>()[0].onClick.AddListener(() => LoadGame());
        GetComponentsInChildren<Button>()[1].onClick.AddListener(() => NewGame());
        GetComponentsInChildren<Button>()[2].onClick.AddListener(() => ShowOption());
        GetComponentsInChildren<Button>()[3].onClick.AddListener(() => ShowCredits());
        GetComponentsInChildren<Button>()[4].onClick.AddListener(() => ExitGame());
        foreach (Button btn in GetComponentsInChildren<Button>())
        {
            btn.onClick.AddListener(() => btn.Select());
        }
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    public void LoadGame()
    {
        if (GameDataManager.LoadFile())
        {
            GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
            blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
            //StartCoroutine(Fade());
            StartCoroutine(LoadYourAsyncScene(DoorData.lastVisitedScene));
            // SceneManager.LoadScene(DoorData.lastVisitedScene);

        }
    }

    public void NewGame()
    {
        //StartCoroutine(Fade());
        GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
        GameDataManager.ResetData();
        blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
        StartCoroutine(LoadYourAsyncScene("Room-1_3"));

    }

    public void ShowCredits()
    {
        GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
        blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
        StartCoroutine(LoadYourAsyncScene("Credits"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
        blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
        StartCoroutine(LoadYourAsyncScene("MainMenu"));
    }


    private void ShowOption()
    {
        // foreach (Button menuBtn in pauseMenuBtns)
        // {
        //     menuBtn.interactable = false;
        // }
        GameObject obj = Instantiate(optionUIPrefab, optionUIPrefab.transform.position, Quaternion.identity, transform.parent.parent);
        obj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        // obj.transform.SetParent(transform.parent);

        // transform.GetChild(0).GetComponent<Button>().onClick.Invoke();
        // PopUpUIManager.Instance.ActivateUI("Option");
        //transform.parent.gameObject.SetActive(false);
    }

    // private IEnumerator FadeScene(Delegate methodCall)
    // {
    //     GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
    //     blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
    //     while (blackScreen.GetComponent<Image>().color.a >= 255)
    //     {
    //         yield return null;
    //     }

    //     methodCall();

    // }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        Player.gameState = Player.GameState.GAMEPLAY;
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
