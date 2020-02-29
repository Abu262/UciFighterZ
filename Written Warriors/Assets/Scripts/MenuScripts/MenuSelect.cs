using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSelect : MonoBehaviour
{
    public PlayerControls Controls; //Player Controls

    public Image[] CharPics;

    public Image P1Arrow;
    public Image P2Arrow;

    int indexP1;
    int indexP2;

    bool turn1 = true;
    bool turn2 = true;

    bool ReadyP1 = false;
    bool ReadyP2 = false;

    public Vector2 MoveP1;
    public Vector2 MoveP2;

    private Image screen;

    public AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        //Start playing theme song
        //StartCoroutine(FindObjectOfType<AudioManager>().PlayFadeIn("VGDCTheme"));
        source.volume = OptionsSelect.volume;

        indexP1 = CharSelectScr.positionP1;
        indexP2 = CharSelectScr.positionP2;

        //Set initial positions and dimensions
        //P1
        float x = CharPics[indexP1].rectTransform.position.x;
        float y = CharPics[indexP1].rectTransform.position.y;
        float sh = CharPics[indexP1].rectTransform.rect.height;
        float sw = CharPics[indexP1].rectTransform.rect.width;
        P1Arrow.rectTransform.position = new Vector2(x, y + sh - 25);
        //P2
        float x2 = CharPics[indexP2].rectTransform.position.x;
        float y2 = CharPics[indexP2].rectTransform.position.y;
        float sh2 = CharPics[indexP2].rectTransform.rect.height;
        float sw2 = CharPics[indexP2].rectTransform.rect.width;
        P2Arrow.rectTransform.position = new Vector2(x2, y2 - sh2 + 25);

        //Set sizes
        P1Arrow.rectTransform.sizeDelta = new Vector2(sw*1.4f,sh);
        P2Arrow.rectTransform.sizeDelta = new Vector2(sw2*1.4f, sh2);

    }

    // Update is called once per frame
    void Update()
    {
        //Get User Input
        MoveP2 = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        MoveP1 = new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));

        if (Input.GetKey(KeyCode.A)) //P1 left
        {
            MoveP1 = new Vector2(-1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D)) //P1 right
        {
            MoveP1 = new Vector2(1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.S)) //P1 down
        {
            MoveP1 = new Vector2(0.0f, -1.0f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            MoveP1 = new Vector2(0.0f, 1.0f);
        }

        if (Input.GetKey(KeyCode.K)) //P2 left
        {
            MoveP2 = new Vector2(-1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.Semicolon)) //P2 right
        {
            MoveP2 = new Vector2(1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.L)) //P2 down
        {
            MoveP2 = new Vector2(0.0f, -1.0f);
        }
        else if (Input.GetKey(KeyCode.O))
        {
            MoveP2 = new Vector2(0.0f, 1.0f);
        }

        //If P2 movement detected
        if (ReadyP2 == false && turn2 == true && ((MoveP2.x > 0.8f || MoveP2.x < -0.8f) || (MoveP2.y > 0.8f || MoveP2.y < -0.8f)))
        {
            turn2 = false;
            StartCoroutine(ShiftP2Cursor());
        }

        //If P1 movement detected
        if (ReadyP1 == false && turn1 == true && ((MoveP1.x > 0.8f || MoveP1.x < -0.8f) || (MoveP1.y > 0.8f || MoveP1.y < -0.8f)))
        {
            turn1 = false;
            StartCoroutine(ShiftP1Cursor());
        }

        //???
        if (ReadyP1 == true && ReadyP2 == true)
        {
        }
        else
        {
        }

        //If P1 locks in character
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Alpha4))
        {
            SelectP1();
        }
        //If P2 locks in character
        if (Input.GetKeyDown(KeyCode.Joystick2Button1) || Input.GetKey(KeyCode.Minus))
        {
            SelectP2();
        }

        CharSelectScr.positionP1 = indexP1;
        CharSelectScr.positionP2 = indexP2;
    }

    //If P1 selects
    void SelectP1()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        ReadyP1 = true;
        FindObjectOfType<GameManager>().PathP1 = FindSource(indexP1);
    }
    //If P2 selects
    void SelectP2()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        ReadyP2 = true;
        FindObjectOfType<GameManager>().PathP2 = FindSource(indexP2);
    }

    //Find what button was selected
    string FindSource(int index)
    {
        string path = "SampleCharactePreFab";

        switch (index)
        {
            case 0:
                path = "Menu";
                SceneManager.LoadScene("CharacterSelect");
                break;
            case 1:
                path = "OptionsMenu";
                SceneManager.LoadScene("OptionsMenu");
                break;
            case 2:
                path = "ZotFighter";
                SceneManager.LoadScene("ZotFighter");
                break;
            case 3:
                path = "Health";
                SceneManager.LoadScene("Health");
                break;
            case 4:
                path = "Controls";
                SceneManager.LoadScene("Controls");
                break;
            case 5:
                path = "Specials";
                SceneManager.LoadScene("Specials");
                break;
            case 6:
                path = "Sudden Death";
                SceneManager.LoadScene("Sudden Death");
                break;
            default:
                path = "SampleCharactePreFab";
                break;
        }
        return path;
    }

    //Move cursor for P2
    IEnumerator ShiftP2Cursor()
    {
        turn2 = false;
        FindObjectOfType<AudioManager>().Play("MenuScroll");
        while (turn2 == false)
        {
            if (MoveP2.x > 0.8f)
            {
                if (indexP2 == 6)
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
                    indexP2 = 6;
                }
                else
                {
                    indexP2 -= 1;
                }
            }

            else if (MoveP2.y > 0.8f)
            {
                if (indexP2 == 0)
                    indexP2 -= 1;
                else
                    indexP2 = 0;
            }

            else if (MoveP2.y < -0.8f)
            {
                if (indexP2 == 0)
                    indexP2 += 1;
                else indexP2 = 0;
            }

            yield return new WaitForSeconds(0.15f);
            turn2 = true;

            float x = CharPics[indexP2].rectTransform.position.x;
            float y = CharPics[indexP2].rectTransform.position.y;
            float sh = CharPics[indexP2].rectTransform.rect.height;
            float sw = CharPics[indexP2].rectTransform.rect.width;
            P2Arrow.rectTransform.position = new Vector2(x, y - sh + 25);
            P2Arrow.rectTransform.sizeDelta = new Vector2(sw*1.4f, sh);

        }
    }
    //Move cursor for P1
    IEnumerator ShiftP1Cursor()
    {
        turn1 = false;
        FindObjectOfType<AudioManager>().Play("MenuScroll");
        while (turn1 == false)
        {
            if (MoveP1.x > 0.8f)
            {
                if (indexP1 == 6)
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
                    indexP1 = 6;
                }
                else
                {
                    indexP1 -= 1;
                }
            }

            else if (MoveP1.y > 0.8f)
            {
                if (indexP1 == 0)
                    indexP1 -= 1;
                else
                    indexP1 = 0;
            }

            else if (MoveP1.y < -0.8f)
            {
                if (indexP1 == 0)
                    indexP1 += 1;
                else indexP1 = 0;
            }

            yield return new WaitForSeconds(0.15f);
            turn1 = true;

            float x = CharPics[indexP1].rectTransform.position.x;
            float y = CharPics[indexP1].rectTransform.position.y;
            float sh = CharPics[indexP1].rectTransform.rect.height;
            float sw = CharPics[indexP1].rectTransform.rect.width;
            P1Arrow.rectTransform.position = new Vector2(x, y + sh - 25);
            P1Arrow.rectTransform.sizeDelta = new Vector2(sw*1.4f, sh);
        }
    }

}

