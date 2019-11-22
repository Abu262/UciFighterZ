using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharSelectScr : MonoBehaviour
{
    public PlayerControls Controls; //Player Controls

  //  public Text READY;

    public Image[] CharPics;

    public Image P1Arrow;
    public Image P2Arrow;

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

    public TextMeshProUGUI READY;
    public TextMeshProUGUI READYBG;
    public TextMeshProUGUI RDYP1;
    public TextMeshProUGUI RDYP1BG;
    public TextMeshProUGUI RDYP2;
    public TextMeshProUGUI RDYP2BG;
    public TextMeshProUGUI P1CHAR;
    public TextMeshProUGUI P1CHARBG;
    public TextMeshProUGUI P2CHAR;
    public TextMeshProUGUI P2CHARBG;


    private Image screen;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindObjectOfType<AudioManager>().PlayFadeIn("VGDCTheme"));
        indexP1 = 0;
        indexP2 = 0;
        P2Arrow.transform.position = new Vector2(CharPics[indexP2].transform.position.x, CharPics[indexP2].transform.position.y - 55.0f);
        P1Arrow.transform.position = new Vector2(CharPics[indexP1].transform.position.x, CharPics[indexP1].transform.position.y + 55.0f);

        StartCoroutine(FlashText(P1CHAR, P1CHARBG));
        StartCoroutine(FlashTextP2(P2CHAR, P2CHARBG));
        screen = GameObject.FindGameObjectWithTag("Screen").GetComponent<Image>();
        StartCoroutine(manager.FadeScreenIn(screen));
    }

    // Update is called once per frame
    void Update()
    {

        if (ReadyP1 == true)
        {
            RDYP1.enabled = true;
            RDYP1BG.enabled = true;
        }
        else
        {
            RDYP1.enabled = false;
            RDYP1BG.enabled = false;
        }
        if(ReadyP2 == true)
        {
            RDYP2.enabled = true;
            RDYP2BG.enabled = true;
        }
        else
        {
            RDYP2.enabled = false;
            RDYP2BG.enabled = false;
        }
        if (ReadyP1 == true && ReadyP2 == true)
        {
            READY.enabled = true;
            READYBG.enabled = true;
        }
        else
        {
            READY.enabled = false;
            READYBG.enabled = false;
        }


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
        // else
        // {
        //     turn2 = true;
        // }


        if (ReadyP1 == false && turn1 == true && ((MoveP1.x > 0.8f || MoveP1.x < -0.8f) || (MoveP1.y > 0.8f || MoveP1.y < -0.8f)))
        {
            turn1 = false;
            StartCoroutine(ShiftP1Cursor());
        }

        if (ReadyP1 == true && ReadyP2 == true)
        {
     //      READY.enabled = true;
        }
        else
        {
      //      READY.enabled = false;
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
        // else
        // {
        //     turn1 = true;
        // }
        //Debug.Log(MoveP2);


    }

    void SelectP1()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        ReadyP1 = true;
        //  FindObjectOfType<GameManager>().PathP1 = FindSource(indexP1);
        FindObjectOfType<GameManager>().PathP1 = FindSource(indexP1);
        //FindObjectOfType<GameManager>().Self1 = (Character)Resources.Load(FindObjectOfType<GameManager>().PathP1, typeof(Character));
        //manager.Self1 = (Character)Resources.Load(manager.PathP1, typeof(Character));
       
    }
    void SelectP2()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        ReadyP2 = true;
        //FindObjectOfType<GameManager>().PathP2 = FindSource(indexP2);
        //FindObjectOfType<GameManager>().Self2 = (Character)Resources.Load(FindObjectOfType<GameManager>().PathP2, typeof(Character));
        FindObjectOfType<GameManager>().PathP2 = FindSource(indexP2);
        //manager.Self2 = (Character)Resources.Load(manager.PathP2, typeof(Character));
       
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
            //FindObjectOfType<AudioManager>().Stop("VGDCTheme");
            StartCoroutine(Wait());
            //SceneManager.LoadScene(7);
        }
      //  manager.Self1 

    }


    string FindSource(int index)
    {
        string path = "SampleCharactePreFab";

        switch (index)
        {
            case 0:
                path = "Thornton";
                break;
            case 1:
                path = "Klefstad";
                break;
            case 2:
                path = "Pattis";
                break;
            //case 3:
            //    path = "SampleCharactePreFab";
            //    break;
            //case 4:
            //    path = "SampleCharactePreFab";
            //    break;
            //case 5:
            //    path = "Thornton";
            //    break;
            //case 6:
            //    path = "SampleCharactePreFab";
            //    break;
            //case 7:
            //    path = "Klefstad";
            //    break;
            //case 8:
            //    path = "SampleCharactePreFab";
            //    break;
            //case 9:
            //    path = "Pattis";
            //    break;
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
                if (indexP2 == 2)
                {
                    indexP2 = 0;
                }
                else
                {
                    indexP2 += 1;
                }


                //              yield return new WaitForSeconds(0.15f);
                //       Debug.Log(indexP2);
            }

            else if (MoveP2.x < -0.8f)
            {
                if (indexP2 == 0)
                {
                    indexP2 = 2;
                }
                else
                {
                    indexP2 -= 1;
                }


                //                yield return new WaitForSeconds(0.15f);
                //         Debug.Log(indexP2);
            }

            //if (MoveP2.y < -0.8f)
            //{
            //    if (indexP2 + 1 <= CharPics.Length / 2)
            //    {
            //        indexP2 = indexP2 + CharPics.Length / 2;
            //    }
            //    else
            //    {
            //        indexP2 = indexP2 - CharPics.Length / 2;
            //    }
            //}
            //else if (MoveP2.y > 0.8f)
            //{
            //    if (indexP2 + 1 > CharPics.Length / 2)
            //    {
            //        indexP2 = indexP2 - CharPics.Length / 2;
            //    }
            //    else
            //    {
            //        indexP2 = indexP2 + CharPics.Length / 2;
            //    }


            //    if (indexP2 > CharPics.Length - 1)
            //    {
            //        indexP2 = 0;
            //    }

            //    if (indexP2 < 0)
            //    {
            //        indexP2 = CharPics.Length;
            //    }
            //    //   yield return new WaitForSeconds(0.15f);
            //    // turn1 = true;
            //}
            yield return new WaitForSeconds(0.15f);
            turn2 = true;


            
            P2Arrow.rectTransform.position = new Vector2(CharPics[indexP2].transform.position.x, CharPics[indexP2].transform.position.y - 55.0f);
            if(indexP2 == 0)
            {
                P2CHAR.text = "THORNTON";
                P2CHARBG.text = "THORNTON";
            }
            else if (indexP2 == 1)
            {
                P2CHAR.text = "KLEFSTAD";
                P2CHARBG.text = "KLEFSTAD";
            }
            else
            {
                P2CHAR.text = "PATTIS";
                P2CHARBG.text = "PATTIS";
            }




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
                    if (indexP1 == 2)
                    {
                        indexP1 = 0;
                    }
                    else
                    {
                        indexP1 += 1;
                    }


                    //              yield return new WaitForSeconds(0.15f);
                    //       Debug.Log(indexP2);
                }

                else if (MoveP1.x < -0.8f)
                {
                    if (indexP1 == 0)
                    {
                        indexP1 = 2;
                    }
                    else
                    {
                        indexP1 -= 1;
                    }


                    //                yield return new WaitForSeconds(0.15f);
                    //         Debug.Log(indexP2);
                }

                //if (MoveP1.y < -0.8f)
                //{
                //    if (indexP1 + 1 <= CharPics.Length/2)
                //    {
                //        indexP1 = indexP1 + CharPics.Length /2;
                //    }
                //    else
                //    {
                //        indexP1 = indexP1 - CharPics.Length / 2;
                //    }
                //}
                //else if (MoveP1.y > 0.8f)
                //{
                //    if (indexP1 + 1 > CharPics.Length/2)
                //    {
                //        indexP1 = indexP1 - CharPics.Length / 2;
                //    }
                //    else
                //    {
                //        indexP1 = indexP1 + CharPics.Length / 2;
                //    }


                //    if (indexP1 > CharPics.Length - 1)
                //    {
                //        indexP1 = 0;
                //    }

                //    if (indexP1 < 0)
                //    {
                //        indexP1 = CharPics.Length;
                //    }
                // //   yield return new WaitForSeconds(0.15f);
                //   // turn1 = true;
                //}
            yield return new WaitForSeconds(0.15f);
            turn1 = true;



            P1Arrow.rectTransform.position = new Vector2(CharPics[indexP1].transform.position.x, CharPics[indexP1].transform.position.y + 55.0f);
            if (indexP1 == 0)
            {
                P1CHAR.text = "THORNTON";
                P1CHARBG.text = "THORNTON";
            }
            else if (indexP1 == 1)
            {
                P1CHAR.text = "KLEFSTAD";
                P1CHARBG.text = "KLEFSTAD";
            }
            else
            {
                P1CHAR.text = "PATTIS";
                P1CHARBG.text = "PATTIS";
            }





            //    yield return null;
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

