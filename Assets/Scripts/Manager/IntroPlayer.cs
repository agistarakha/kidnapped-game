using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


/// <summary>
/// Class yang digunakan untuk menampilkan video intro saat new game
/// </summary>
public class IntroPlayer : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private bool videoEnd;
    private bool videoInitiated;

    // Start is called before the first frame update
    void Start()
    {
        videoEnd = false;
        videoInitiated = false;
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.SetDirectAudioVolume(0, BGMManager.instance.GetAudioSource().volume);
        StartCoroutine(DelayPlay());
        // videoPlayer.Play();
    }

    /// <summary>
    /// Memberikan delay sebelum video diputar
    /// </summary>
    /// <returns>berupa courutine yang berisi waktu delay</returns>
    private IEnumerator DelayPlay()
    {
        yield return new WaitForSeconds(1.2f);
        videoPlayer.Play();
        videoInitiated = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (!videoPlayer.isPlaying && !videoEnd && videoInitiated)
        {
            BGMManager.instance.bgmIsolation = false;
            GameObject blackScreen = GameObject.FindGameObjectWithTag("Fade");
            blackScreen.GetComponent<Animator>().SetTrigger("FadeIn");
            StartCoroutine(LoadYourAsyncScene("Room-1_3"));
            videoEnd = true;

        }

    }

    /// <summary>
    /// Ketika video berakhir
    /// </summary>
    /// <param name="vp"></param>
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 1f;
    }


    /// <summary>
    /// Load scene dengan delay dan async
    /// </summary>
    /// <param name="sceneName">Nama Scene</param>
    /// <returns>Waktu delay</returns>
    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        yield return new WaitForSeconds(2f);
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
