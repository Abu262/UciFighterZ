using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StateManager : MonoBehaviour
{
    public float currentCountdown;
    public Text timerLabel;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(startCountdown(currentCountdown));
    }

    IEnumerator startCountdown(float countdown)
    {
        while (countdown > 0)
        {
            Debug.Log("Countdown: " + countdown);
            timerLabel.text = (countdown).ToString("0");
            yield return new WaitForSeconds(1.0f);
            countdown--;
        }
    }
}
