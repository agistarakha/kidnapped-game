using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // public delegate void Delegate();
    // public Delegate LoadGameCall;
    // public Delegate NewGameCall;

    void Start()
    {
        //LoadGameCall = LoadGame;
        //NewGameCall = NewGame;
        //GetComponentsInChildren<Button>()[1].onClick.AddListener(() => GetComponentsInChildren<Button>()[1].Select());

        if (!GameDataManager.LoadFile())
        {
            GetComponentInChildren<Button>().interactable = false;
            // GetComponent<Button>()
            //GetComponentInChildren<Image>().color = Color.gray;
        }
        GetComponentsInChildren<Button>()[0].onClick.AddListener(() => LoadGame());
        GetComponentsInChildren<Button>()[1].onClick.AddListener(() => NewGame());
        GetComponentsInChildren<Button>()[4].onClick.AddListener(() => ExitGame());
        foreach (Button btn in GetComponentsInChildren<Button>())
        {
            btn.onClick.AddListener(() => btn.Select());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

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
        blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
        StartCoroutine(LoadYourAsyncScene("Room-1_3"));

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        // StartCoroutine(LoadYourAsyncScene("MainMenu"));

        SceneManager.LoadScene("MainMenu");
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
