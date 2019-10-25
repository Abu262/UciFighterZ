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
    Vector2 startingPos;
    Vector3 vUp;
    Vector3 vDown;
    Vector3 vRight;
    Vector3 vLeft;
    int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCountdown(currentCountdown));
        shakeObj.GetComponent<Text>().material.color = Color.white;
        startingPos.x = shakeObj.transform.position.x;
        startingPos.y = shakeObj.transform.position.y;
    }

    IEnumerator startCountdown(float countdown)
    {
        while (countdown > 0)
        {
            if (countdown % 15 == 0)
                StartCoroutine(shake(countdown));

            /*countdown += .99f;
            for (; countdown % 1 > -1; countdown -= .01f)
            {
                timerLabel.text = (countdown).ToString("0.00");
                yield return new WaitForSeconds(.006f);
            }*/
            timerLabel.text = (countdown).ToString("0.00");
            yield return new WaitForSeconds(1f);
            countdown -= 1f;
        }
        yield return null;
    }

    IEnumerator shake(float countdown)
    {
        for (int x = 0; x < 10; x++)
        {
            shakeObj.GetComponent<Text>().color = Color.Lerp(Color.white, Color.red, 0.1f * x);
            yield return new WaitForSeconds(0.05f);
        }
        vUp = new Vector3(startingPos.x, startingPos.y + 7.0f * count, 0);
        vDown = new Vector3(startingPos.x, startingPos.y - 7.0f * count, 0);
        vRight = new Vector3(startingPos.x + 7.0f * count, startingPos.y, 0);
        vLeft = new Vector3(startingPos.x - 7.0f * count, startingPos.y, 0);
        for (int x = 0; x < 3 * count; x++)
        {
            if (countdown == 15)
            {
                shakeObj.transform.position = vUp;
                yield return new WaitForSeconds(0.05f);
                shakeObj.transform.position = vDown;
                yield return new WaitForSeconds(0.05f);
            }
            shakeObj.transform.position = vRight;
            yield return new WaitForSeconds(0.05f);
            shakeObj.transform.position = vLeft;
            yield return new WaitForSeconds(0.05f);
        }
        count += 1;
        for (int x = 0; x < 10; x++)
        {
            shakeObj.GetComponent<Text>().color = Color.Lerp(Color.red, Color.white, 0.1f * x);
            yield return new WaitForSeconds(0.05f);
        }
        shakeObj.GetComponent<Text>().color = Color.white;
        yield return null;
    }
}
