using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    private static CharacterAudio _instances = null;
    public static CharacterAudio instances
    {
        get
        {
            if (_instances == null)
            {
                _instances = FindObjectOfType<CharacterAudio>();
            }
            return _instances;
        }
    }

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips;

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
}
