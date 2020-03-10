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
            Song = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
            instance = this.gameObject;
            Song.Play();
            currentScene = SceneManager.GetActiveScene();
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
            if(currentScene.name == "CharacterSelect")
            {
                Song.Stop();
                Song = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
                Song.volume = volume;
                Song.Play();
            }
            if (currentScene.name == "Aldrich")
            {
                if (Song != GameObject.Find("AldrichMusic").GetComponent<AudioSource>())
                {
                    Song = GameObject.Find("AldrichMusic").GetComponent<AudioSource>();
                    Song.volume = volume;
                    Song.Play();
                }
            }
            if (currentScene.name == "Spectrum")
            {
                if (Song != GameObject.Find("SpectrumMusic").GetComponent<AudioSource>())
                {
                    Song = GameObject.Find("SpectrumMusic").GetComponent<AudioSource>();
                    Song.volume = volume;
                    Song.Play();
                }
            }
        }
        
        volume = Song.volume;
    }
}
