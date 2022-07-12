using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Class yang berisi fungsi-fungsi untuk main menu
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject optionUIPrefab;
 

    void Start()
    {
        
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            return;
        }
        OptionDataManager.Load();
        AudioManager.instance.GetAudioSource().volume = OptionDataManager.Option.sfxVolume;
        CharacterAudio.instances.GetAudioSource().volume = OptionDataManager.Option.sfxVolume;
        BGMManager.instance.GetAudioSource().volume = OptionDataManager.Option.musicVolume;

        if (!GameDataManager.LoadFile())
        {
            GetComponentInChildren<Button>().interactable = false;
            
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

    
    /// <summary>
    /// Fungsi yang dipanggil ketika tombol Continue ditekan
    /// </summary>
    public void LoadGame()
    {
        if (GameDataManager.LoadFile())
        {
            GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
            blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
            StartCoroutine(LoadYourAsyncScene(DoorData.lastVisitedScene));
            
        }
    }

    /// <summary>
    /// Fungsi yang dipanggil ketika new game
    /// </summary>
    public void NewGame()
    {
        BGMManager.instance.bgmIsolation = true;
        BGMManager.instance.Stop();
        GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
        GameDataManager.ResetData();
        blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
        StartCoroutine(LoadYourAsyncScene("Intro"));

    }

    /// <summary>
    /// Method untuk menampilkan credit scene
    /// </summary>
    public void ShowCredits()
    {
        GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
        blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
        StartCoroutine(LoadYourAsyncScene("Credits"));
    }

    /// <summary>
    /// Exit game
    /// </summary>
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


    /// <summary>
    /// Menampilkan option panel
    /// </summary>
    private void ShowOption()
    {
        
        GameObject obj = Instantiate(optionUIPrefab, optionUIPrefab.transform.position, Quaternion.identity, transform.parent.parent);
        obj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        
    }

    


    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        yield return new WaitForSeconds(5f);
        Player.gameState = Player.GameState.GAMEPLAY;
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        BGMManager.instance.Stop();
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
