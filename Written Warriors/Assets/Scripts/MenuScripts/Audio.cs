using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public static GameObject instance;
    static public AudioSource Song;
    private float volume;
    Scene currentScene;
    bool fading = false;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this.gameObject;
            Song = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
            Song.Play();
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (currentScene != SceneManager.GetActiveScene())
        {
            currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "TransitionScene")
                Song.Stop();
            if (currentScene.name == "Aldrich")
            {
                Song = GameObject.Find("AldrichMusic").GetComponent<AudioSource>();
                Song.volume = volume;
                Song.Play();
            }
            if (currentScene.name == "Spectrum")
            {
                Song = GameObject.Find("SpectrumMusic").GetComponent<AudioSource>();
                Song.volume = volume;
                Song.Play();
            }
        }

        volume = Song.volume;
    }
}
