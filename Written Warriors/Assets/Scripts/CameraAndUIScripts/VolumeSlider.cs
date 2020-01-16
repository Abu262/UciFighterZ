using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private GameObject Audio; // Represents the Audio Manager
    [SerializeField] private GameObject VolSlider; // Represents the volume slider
    private float lastVol; // Represents the last volume setting

    // Set the volumes of each song and SFX in the audio manager
    // to .5f (the default value of volume)
    private void Awake()
    {
        Audio = GameObject.FindGameObjectWithTag("audio");
        VolSlider.GetComponent<Slider>().value = Options.Volume;
        UpdateSounds(Options.Volume);
    }

    public void Update()
    {
        // The volume of every sound should only be changed if the 
        // last volume setting does not match the current volume setting
        // (that way we're not continually looping through the list of sounds every frame)
        if (VolSlider.GetComponent<Slider>().value != lastVol)
        {
            Options.Volume = VolSlider.GetComponent<Slider>().value;
            UpdateSounds(Options.Volume);
            lastVol = Options.Volume;
        }
    }

    
    // Update the volume of each song and SFX in the audio manager
    // to the new value
    private void UpdateSounds(float vol)
    {
        foreach (Sound s in Audio.GetComponent<AudioManager>().sounds)
        {
            Audio.GetComponent<AudioManager>().SetVolume(s.name, vol);
        }
    }
}
