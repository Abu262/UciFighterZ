using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public string PathP1 = "SampleCharactePrFab";
    public string PathP2 = "SampleCharactePrFab";

    

    bool P1 = true;
    public static GameManager instance;

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

    public string ReturnPath()
    {
        if (P1)
        {
            P1 = false;
            return PathP1;
        }
        else
        {
            return PathP2;
        }

    }
}
