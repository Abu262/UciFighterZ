using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class How2PlaySlct : MonoBehaviour
{
    public PlayerControls Controls; //Player Controls

    //  public Text READY;

    public Image[] CharPics;

    public Image P1Arrow;
    public Image P2Arrow;
    Vector2 SizeLarge;
    Vector2 SizeSmall;

    [SerializeField]
    private GameManager manager;

    int indexP1;
    int indexP2;

    bool turn1 = true;
    bool turn2 = true;

    bool ReadyP1 = false;
    bool ReadyP2 = false;


    public Vector2 MoveP1;
    public Vector2 MoveP2;

  //  private Image screen;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
       // StartCoroutine(FindObjectOfType<AudioManager>().PlayFadeIn("VGDCTheme"));
        indexP1 = 0;
        indexP2 = 0;
        P2Arrow.transform.position = new Vector2(CharPics[indexP2].transform.position.x, CharPics[indexP2].transform.position.y - 25.0f);
        P1Arrow.transform.position = new Vector2(CharPics[indexP1].transform.position.x, CharPics[indexP1].transform.position.y + 25.0f);
        RectTransform rt = P2Arrow.GetComponent<RectTransform>();
        SizeLarge = rt.sizeDelta;
        SizeSmall = new Vector2(rt.rect.width, rt.rect.height * .55f);

    //    screen = GameObject.FindGameObjectWithTag("Screen").GetComponent<Image>();
      //  StartCoroutine(manager.FadeScreenIn(screen));
    }

    // Update is called once per frame
    void Update()
    {

        MoveP2 = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        MoveP1 = new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));

        if (Input.GetKey(KeyCode.A))
        {
            MoveP1 = new Vector2(-1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveP1 = new Vector2(1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveP1 = new Vector2(0.0f, -1.0f);
        }
        if (Input.GetKey(KeyCode.K))
        {
            MoveP2 = new Vector2(-1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.Semicolon))
        {
            MoveP2 = new Vector2(1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            MoveP2 = new Vector2(0.0f, -1.0f);
        }


        if (ReadyP2 == false && turn2 == true && ((MoveP2.x > 0.8f || MoveP2.x < -0.8f) || (MoveP2.y > 0.8f || MoveP2.y < -0.8f)))
        {
            turn2 = false;
            StartCoroutine(ShiftP2Cursor());
        }


        if (ReadyP1 == false && turn1 == true && ((MoveP1.x > 0.8f || MoveP1.x < -0.8f) || (MoveP1.y > 0.8f || MoveP1.y < -0.8f)))
        {
            turn1 = false;
            StartCoroutine(ShiftP1Cursor());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Alpha4))
        {
            SelectP1();
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button1) || Input.GetKey(KeyCode.Minus))
        {
            SelectP2();
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.Joystick2Button3) || Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Equals))
        {
            StartMatch();
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.R))
        {
            BackP1();
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button2) || Input.GetKey(KeyCode.LeftBracket))
        {
            BackP2();
        }

    }

    void SelectP1()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        ReadyP1 = true;
        FindObjectOfType<GameManager>().PathP1 = FindSource(indexP1);
    }
    void SelectP2()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        ReadyP2 = true;
        FindObjectOfType<GameManager>().PathP2 = FindSource(indexP2);

    }
    void BackP1()
    {

        ReadyP1 = false;
    }
    void BackP2()
    {

        ReadyP2 = false;
    }
    void StartMatch()
    {
        if (ReadyP1 && ReadyP2)
        {
            StartCoroutine(Wait());
        }

    }


    string FindSource(int index)
    {
        string path = "SampleCharactePreFab";

        switch (index)
        {
            case 0:
                path = "Back";
                SceneManager.LoadScene("CharacterSelect");
                break;
            case 1:
                path = "Health";
                SceneManager.LoadScene("Health");
                break;
            default:
                path = "SampleCharactePreFab";
                break;
        }




        return path;
    }



    IEnumerator ShiftP2Cursor()
    {
        turn2 = false;
        FindObjectOfType<AudioManager>().Play("MenuScroll");
        while (turn2 == false)
        {
            if (MoveP2.x > 0.8f)
            {
                if (indexP2 == 1)
                {
                    indexP2 = 0;
                }
                else
                {
                    indexP2 += 1;
                }
            }

            else if (MoveP2.x < -0.8f)
            {
                if (indexP2 == 0)
                {
                    indexP2 = 1;
                }
                else
                {
                    indexP2 -= 1;
                }

            }

            yield return new WaitForSeconds(0.15f);
            turn2 = true;

            P2Arrow.rectTransform.position = new Vector2(CharPics[indexP2].transform.position.x, CharPics[indexP2].transform.position.y - 25.0f);

            //    yield return null;
        }
    }
    IEnumerator ShiftP1Cursor()
    {
        turn1 = false;
        FindObjectOfType<AudioManager>().Play("MenuScroll");
        while (turn1 == false)
        {
            if (MoveP1.x > 0.8f)
            {
                if (indexP1 == 1)
                {
                    indexP1 = 0;
                }
                else
                {
                    indexP1 += 1;
                }
            }

            else if (MoveP1.x < -0.8f)
            {
                if (indexP1 == 0)
                {
                    indexP1 = 1;
                }
                else
                {
                    indexP1 -= 1;
                }
            }
            
            yield return new WaitForSeconds(0.15f);
            turn1 = true;

            P1Arrow.rectTransform.position = new Vector2(CharPics[indexP1].transform.position.x, CharPics[indexP1].transform.position.y + 25.0f);

        }
    }

    IEnumerator FlashText(TextMeshProUGUI T, TextMeshProUGUI T2)
    {
        Color tmp = P1Arrow.color;
        tmp.a = 0f;
        while (true)
        {
            if (ReadyP1 == true)
            {
                yield return new WaitForSeconds(0.025f);
                T.enabled = !T.enabled;
                T2.enabled = !T2.enabled;
                tmp.a = Mathf.Abs(tmp.a - 255f);
                P1Arrow.color = tmp;
            }
            else
            {
                tmp.a = 255f;
                P1Arrow.color = tmp;
                T.enabled = true;
                T2.enabled = true;
            }
            yield return null;
        }
    }
    IEnumerator FlashTextP2(TextMeshProUGUI T, TextMeshProUGUI T2)
    {
        Color tmp = P2Arrow.color;
        tmp.a = 0f;
        while (true)
        {
            if (ReadyP2 == true)
            {
                yield return new WaitForSeconds(0.025f);
                T.enabled = !T.enabled;
                T2.enabled = !T2.enabled;
                tmp.a = Mathf.Abs(tmp.a - 255f);
                P2Arrow.color = tmp;
            }
            else
            {
                tmp.a = 255f;
                P2Arrow.color = tmp;
                T.enabled = true;
                T2.enabled = true;
            }
            yield return null;
        }
    }

    IEnumerator Wait()
    {
        FindObjectOfType<AudioManager>().Stop("VGDCTheme");
        //  yield return new WaitForSeconds(1.0f);

        //StartCoroutine(manager.FadeScreenOut(screen));
        SceneManager.LoadScene(7);
        yield return null;
    }

}

