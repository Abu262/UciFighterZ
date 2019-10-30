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
    public GameOver GO;
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
        while (countdown > -1)
        {
            if (countdown % 150 == 0)
                StartCoroutine(shake(countdown));
            
            timerLabel.text = (countdown).ToString("0");
            yield return new WaitForSeconds(.05f);
            countdown -= 1f;
        }
        yield return StartCoroutine(GO.TimerEnds());
        yield return null;
    }

    IEnumerator shake(float countdown)
    {

        Color clr = shakeObj.GetComponent<Text>().color;
        for (int x = 0; x < 10; x++)
        {
            shakeObj.GetComponent<Text>().color = Color.Lerp(clr, Color.red, 0.1f * x);
            yield return new WaitForSeconds(0.05f);
        }
        vUp = new Vector3(startingPos.x, startingPos.y + 2.0f * count, 0);
        vDown = new Vector3(startingPos.x, startingPos.y - 2.0f * count, 0);
        vRight = new Vector3(startingPos.x + 5.0f * count, startingPos.y, 0);
        vLeft = new Vector3(startingPos.x - 5.0f * count, startingPos.y, 0);
        for (int x = 0; x < 3 * count; x++)
        {
            if (countdown <= 300)
            {
                x += 2;
                shakeObj.transform.position = vUp;
                yield return new WaitForSeconds(0.02f);
                shakeObj.transform.position = vDown;
                yield return new WaitForSeconds(0.02f);
            }
            shakeObj.transform.position = vRight;
            yield return new WaitForSeconds(0.05f);
            shakeObj.transform.position = vLeft;
            yield return new WaitForSeconds(0.05f);
        }

        shakeObj.transform.position = new Vector3(startingPos.x, startingPos.y, 0);
        count += 1;
        for (int x = 0; x < 10; x++)
        {
            shakeObj.GetComponent<Text>().color = Color.Lerp(Color.red, clr, 0.1f * x);
            yield return new WaitForSeconds(0.05f);
        }
        shakeObj.GetComponent<Text>().color = clr;
        yield return null;
    }
}
