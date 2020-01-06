using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StateManager : MonoBehaviour
{
    public float currentCountdown;
//    public Text timerLabel;
    public TextMeshProUGUI timerLabel;
    public TextMeshProUGUI timerLabelBG;
    public GameObject shakeObj;
    public GameObject shakeObjBG;
    Vector2 startingPos;
    Vector2 startingPosBG;
    Vector3 vUp;
    Vector3 vDown;
    Vector3 vRight;
    Vector3 vLeft;
    Vector3 vUpBG;
    Vector3 vDownBG;
    Vector3 vRightBG;
    Vector3 vLeftBG;

    PauseMenu p = new PauseMenu();

    public GameOver GO;
    public PauseMenu PM;
    int count = 1;
    public bool runTimer = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCountdown(currentCountdown));
        shakeObj.GetComponent<TextMeshProUGUI>().material.color = Color.white;
        startingPos.x = shakeObj.transform.position.x;
        startingPos.y = shakeObj.transform.position.y;
        startingPosBG.x = shakeObjBG.transform.position.x;
        startingPosBG.y = shakeObjBG.transform.position.y;
    }

    public IEnumerator startCountdown(float countdown)
    {
        runTimer = true;
        yield return StartCoroutine(GO.StartMatch());
        while (countdown > -1 && p.isPaused == false)
        {
            if (!PM.isPaused)
            {
                if (countdown % 150 == 0)
                    StartCoroutine(shake(countdown));

                timerLabel.text = (countdown).ToString("0");
                timerLabelBG.text = (countdown).ToString("0");
                yield return new WaitForSeconds(.05f);
                if (runTimer)
                {
                    countdown -= 1f;
                }
            }

            yield return null;


        }
        yield return StartCoroutine(GO.TimerEnds());
        yield return null;
    }

    public IEnumerator MoveTextIn(string FGtext, TextMeshProUGUI FG, TextMeshProUGUI BG, float ypos)
    {
        float w = Screen.width;
        float h = Screen.height;
        FG.GetComponent<Transform>().position = new Vector3(-w + w/2, h/2);
        BG.GetComponent<Transform>().position = new Vector3(w/2 + w, h/2);

        FG.text = FGtext;
        BG.text = FGtext;

        while (FG.GetComponent<Transform>().position.x < w/2)
        {
            FG.GetComponent<Transform>().position += Vector3.right * 40f;
            BG.GetComponent<Transform>().position -= Vector3.right * 40f;
            yield return null;
        }
        FG.GetComponent<Transform>().position = new Vector3(w/2, h/2);
        BG.GetComponent<Transform>().position = new Vector3(w/2, h/2);
        yield return new WaitForSeconds(0.1f);
        while (FG.GetComponent<Transform>().position.y <= h/2 + 7.0f)
        {
            FG.GetComponent<Transform>().position += Vector3.up * 1.5f;
            FG.GetComponent<Transform>().position -= Vector3.right * 1.5f;
            BG.GetComponent<Transform>().position -= Vector3.up * 1.5f;
            BG.GetComponent<Transform>().position += Vector3.right * 1.5f;
            yield return null;
        }

        yield return null;
    }



    IEnumerator shake(float countdown)
    {

        Color clr = shakeObj.GetComponent<TextMeshProUGUI>().color;
        Color clrBG = shakeObjBG.GetComponent<TextMeshProUGUI>().color;
        for (int x = 0; x < 10; x++)
        {
            shakeObj.GetComponent<TextMeshProUGUI>().color = Color.Lerp(clr, Color.red, 0.1f * x);
            shakeObjBG.GetComponent<TextMeshProUGUI>().color = Color.Lerp(clr, Color.black, 0.1f * x);
            yield return new WaitForSeconds(0.05f);
        }
        vUp = new Vector3(startingPos.x, startingPos.y + 2.0f * count, 0);
        vDown = new Vector3(startingPos.x, startingPos.y - 2.0f * count, 0);
        vRight = new Vector3(startingPos.x + 5.0f * count, startingPos.y, 0);
        vLeft = new Vector3(startingPos.x - 5.0f * count, startingPos.y, 0);

        vUpBG = new Vector3(startingPosBG.x, startingPosBG.y + 2.0f * count, 0);
        vDownBG = new Vector3(startingPosBG.x, startingPosBG.y - 2.0f * count, 0);
        vRightBG = new Vector3(startingPosBG.x + 5.0f * count, startingPosBG.y, 0);
        vLeftBG = new Vector3(startingPosBG.x - 5.0f * count, startingPosBG.y, 0);
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
        shakeObjBG.transform.position = new Vector3(startingPosBG.x, startingPosBG.y, 0);
        count += 1;
        for (int x = 0; x < 10; x++)
        {
            shakeObj.GetComponent<TextMeshProUGUI>().color = Color.Lerp(Color.red, clr, 0.1f * x);
            shakeObjBG.GetComponent<TextMeshProUGUI>().color = Color.Lerp(Color.red, clr, 0.1f * x);
            yield return new WaitForSeconds(0.05f);
        }
        shakeObj.GetComponent<TextMeshProUGUI>().color = clr;
        shakeObjBG.GetComponent<TextMeshProUGUI>().color = clrBG;
        yield return null;
    }


}
