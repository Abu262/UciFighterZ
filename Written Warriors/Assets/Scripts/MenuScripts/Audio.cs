using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static GameObject instance;
    static public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (instance == null)
            instance = this.gameObject;
        else
            Destroy(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
