using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject optionUIPrefab;
    // Start is called before the first frame update
    void OnEnable()
    {
        Button[] pauseMenuBtns = transform.GetComponentsInChildren<Button>();
        // Instantiate(optionUIPrefab, optionUIPrefab.transform.position, Quaternion.identity, transform.parent.parent);
        // GameObject OptionUIObj = GameObject.FindGameObjectWithTag("OptionUI");
        // Debug.Log(OptionUIObj);
        // GetComponentsInChildren<Button>()[1].onClick.AddListener(() => OptionUIObj.SetActive(true));
        pauseMenuBtns[1].onClick.AddListener(() => ShowOption());
        pauseMenuBtns[2].onClick.AddListener(() => MainMenu());
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    private void ShowOption()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.Invoke();
        PopUpUIManager.Instance.ActivateUI("Option");
        //transform.parent.gameObject.SetActive(false);
    }

    private void MainMenu()
    {
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
