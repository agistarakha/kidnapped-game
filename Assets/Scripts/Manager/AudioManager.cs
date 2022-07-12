using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;
    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips;
    public AudioSource GetAudioSource()
    {
        return _audioSource;
    }
    // public void Awake()
    // {
    //     OptionDataManager.Load();

    //     _audioSource.volume = OptionDataManager.Option.sfxVolume;
    // }


    /// <summary>
    /// Metode <c>PlaySFX</c> digunakan untuk play SFX satu kali ketika fungsi dipanggil.
    /// </summary>
    /// <param name="name">Nama dari file SFX</param>
    public void PlaySFX(string name)
    {
        AudioClip sfx = _audioClips.Find(s => s.name == name);
        if (sfx == null)
        {
            return;
        }
        _audioSource.PlayOneShot(sfx);
    }
    /*
     public void PlayLoopSFX(string name)
     {
         AudioClip sfx = _audioClips.Find(s => s.name == name);
         _audioSource.clip = sfx;
         if (sfx == null)
         {
             return;
         }
         _audioSource.Play();
     }
     public void StopLoopSFX(string name)
     {
         AudioClip sfx = _audioClips.Find(s => s.name == name);
         _audioSource.clip = sfx;
         if (sfx == null)
         {
             return;
         }
         _audioSource.Stop();
     }
     */
}
