using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SFXVolumeConf : MonoBehaviour
{
    private Slider slider;
    private TMP_Text text;
    // Start is called before the first frame update
    void OnEnable()
    {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<TMP_Text>();
        slider.value = AudioManager.instance.GetAudioSource().volume;
        text.text = "" + Mathf.CeilToInt(slider.value * 100f) + "%";
        slider.onValueChanged.AddListener(delegate { TestSlide(); });
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    private void OnDisable()
    {
        OptionDataManager.Option.sfxVolume = AudioManager.instance.GetAudioSource().volume;
        OptionDataManager.Save();
    }
    private void OnDestroy()
    {
        OptionDataManager.Option.sfxVolume = AudioManager.instance.GetAudioSource().volume;
        OptionDataManager.Save();
    }

    private void TestSlide()
    {
        CharacterAudio.instances.GetAudioSource().volume = slider.value;
        AudioManager.instance.GetAudioSource().volume = slider.value;
        int value = Mathf.CeilToInt(slider.value * 100f);
        text.text = "" + value + "%";
        // OptionDataManager.Option.sfxVolume = slider.value;
        // OptionDataManager.Save();
        // Screen.brightness = slider.value;
        // Debug.Log(slider.value);
    }
}
