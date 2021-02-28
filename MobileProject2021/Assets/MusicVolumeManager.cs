using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicVolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    [SerializeField] private SO_MusicVolume musicVolume;
    [SerializeField] private Slider sliderVolume;

    private void Start()
    {
        sliderVolume.value = musicVolume.value;
        mixer.SetFloat("MasterVolume", Mathf.Log10(musicVolume.value) * 20);
    }

    public void VolumeLevel (float sliderValue)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        musicVolume.value = sliderValue;
    }


}
