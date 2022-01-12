using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager _instance;

    public static BGMManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BGMManager>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private AudioSource bgms;
    [SerializeField] private List<AudioClip> _bgmClips;
    private bool isStop = false;

    void Awake()
    {
        bgms = GetComponent<AudioSource>();
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public void Play(string name)
    {
        //Play some audio!
        if (bgms.isPlaying)
        {
            return;
        }
        bgms.clip = _bgmClips.Find(s => s.name == name);
        isStop = false;
        bgms.Play();
    }

    public void Stop()
    {
        StartCoroutine(FadeSwitchAudio(bgms, 2.0f));
    }

    private IEnumerator SmoothlyStop()
    {
        //float oriVolume = bgms.volume;
        while (bgms.volume > 0)
        {
            bgms.volume = Mathf.Lerp(bgms.volume, 0f, 0.5f * Time.deltaTime);
            yield return null;
        }
        bgms.Stop();
        //bgms.volume = oriVolume;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Lift" && !isStop)
        {
            Stop();
            isStop = true;
        }

        if (SceneManager.GetActiveScene().name.Contains("Room-"))
        {
            Play("Stage1");
        }
        else if (SceneManager.GetActiveScene().name.Contains("Room2-"))
        {
            Play("Stage2");
        }
    }

    private const float FADED_OUT_VOLUME = 0.01f;

    public static IEnumerator FadeSwitchAudio(AudioSource audioSource, float duration)
    {
        var originalVolume = audioSource.volume;

        // I prefer using for loops over while to eliminate the danger of infinite loops
        // and the need for "external" variables
        // I personally also find this better to read and maintain
        for (var timePassed = 0f; timePassed < duration; timePassed += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(originalVolume, FADED_OUT_VOLUME, timePassed / duration);

            yield return null;
        }

        // To be sure to end with clean values
        audioSource.volume = FADED_OUT_VOLUME;
        audioSource.Stop();
        audioSource.volume = originalVolume;
    }
}
