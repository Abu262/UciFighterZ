using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : Character
{
    public Character Parent;

    public static PlayerChar instance;

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
        DontDestroyOnLoad(instance);
    }




}
