using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Mengatur fungsi-fungsi untuk pause menu
/// </summary>
public class PauseMenuManager : MonoBehaviour
{
    public GameObject optionUIPrefab;
    private Button[] pauseMenuBtns;

    void OnEnable()
    {
        pauseMenuBtns = transform.GetComponentsInChildren<Button>();
        // GameObject OptionUIObj = GameObject.FindGameObjectWithTag("OptionUI");
        // Debug.Log(OptionUIObj);
        // GetComponentsInChildren<Button>()[1].onClick.AddListener(() => OptionUIObj.SetActive(true));
        pauseMenuBtns[1].onClick.AddListener(() => ShowOption());
        pauseMenuBtns[2].onClick.AddListener(() => MainMenu());
    }

    private void OnDisable()
    {
        foreach (Button btn in pauseMenuBtns)
        {
            btn.onClick.RemoveAllListeners();
        }
    }

    
    /// <summary>
    /// Menampilkan Option panel dari pause menu
    /// </summary>
    private void ShowOption()
    {
        
        GameObject obj = Instantiate(optionUIPrefab, optionUIPrefab.transform.position, Quaternion.identity, transform.parent.parent);
        obj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        obj.transform.SetParent(transform.parent);

       
    }

    /// <summary>
    /// Berpinah ke MainMenu Scene dari pause meu
    /// </summary>
    private void MainMenu()
    {
        BGMManager.instance.Stop();
        GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>().SetTrigger("FadeIn");
        StartCoroutine(LoadYourAsyncScene("MainMenu"));

    }


    IEnumerator LoadYourAsyncScene(string sceneName)
    {
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
