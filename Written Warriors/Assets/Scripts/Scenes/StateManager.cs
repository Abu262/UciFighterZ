using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StateManager : MonoBehaviour
{
    public float currentCountdown;
    public Text timerLabel;
    public GameObject shakeObj;
    float speed = 2.0f;
    float amount = 2.0f;
    Vector2 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos.x = gameObject.transform.position.x;
        startingPos.y = gameObject.transform.position.y;
        StartCoroutine(startCountdown(currentCountdown));
    }

    IEnumerator startCountdown(float countdown)
    {
        while (countdown > 0)
        {
            StartCoroutine(shake(countdown));
            Debug.Log("Countdown: " + countdown);
            timerLabel.text = (countdown).ToString("0");
            yield return new WaitForSeconds(1.0f);
            countdown--;
        }
    }

    IEnumerator shake(float countdown)
    {
        if (countdown % 15 == 0)
        {
            for (int x = 0; x < 30; x++)
            {
                Vector3 v = new Vector3(startingPos.x + (Mathf.Sin(Time.time * speed) * amount), startingPos.y + (Mathf.Sin(Time.time * speed) * amount));
                gameObject.transform.position = v;
            }
            yield return null;
        }
    }
}
