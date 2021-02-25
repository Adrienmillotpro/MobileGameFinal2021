using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicVolumeManager : MonoBehaviour
{
    public AudioMixer mixer;

    public void VolumeLevel (float sliderValue)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }


}
