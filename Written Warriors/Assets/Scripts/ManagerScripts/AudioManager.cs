using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [HideInInspector]
   
    public static AudioManager instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }





    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        s.source.Stop();
    }

    public bool Playing(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return false;
        }
        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void SetVolume(string name, float NewVolume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        if (NewVolume < 0.01)
        {
            s.source.volume = 0.01f;
        }
        else
        {
            s.source.volume = NewVolume;
        }

    }

    public float GetVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return 0f;
        }

        return s.source.volume;
    }



    void Start()
    {
            //        Play("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {

    }
}