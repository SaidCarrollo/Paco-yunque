using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;
    public AudioSettings audioSettings;

    private void Start()
    {
        
        audioSource.volume = audioSettings.volume;
        volumeSlider.value = audioSettings.volume;
    }

    public void UpdateVolume()
    {
        
        audioSource.volume = volumeSlider.value;
        audioSettings.volume = volumeSlider.value;
    }
}