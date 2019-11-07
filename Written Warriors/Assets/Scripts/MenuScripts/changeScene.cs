using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour
{
    public void sceneChange(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
