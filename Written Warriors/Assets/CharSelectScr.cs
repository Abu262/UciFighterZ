using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharSelectScr : MonoBehaviour
{
    public PlayerControls Controls; //Player Controls

    public Text READY;

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


    // Start is called before the first frame update
    void Start()
    {
        indexP1 = 0;
        indexP2 = 0;
        P2Arrow.transform.position = new Vector2(CharPics[indexP2].transform.position.x, CharPics[indexP2].transform.position.y - 35.0f);
        P1Arrow.transform.position = new Vector2(CharPics[indexP1].transform.position.x, CharPics[indexP1].transform.position.y + 35.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveP2 = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        MoveP1 = new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));


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
            READY.enabled = true;
        }
        else
        {
            READY.enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            SelectP1();
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            SelectP2();
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.Joystick2Button3))
        {
            StartMatch();
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            BackP1();
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button2))
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
        ReadyP1 = true;
        //  FindObjectOfType<GameManager>().PathP1 = FindSource(indexP1);
        manager.PathP1 = FindSource(indexP1);
        //FindObjectOfType<GameManager>().Self1 = (Character)Resources.Load(FindObjectOfType<GameManager>().PathP1, typeof(Character));
        //manager.Self1 = (Character)Resources.Load(manager.PathP1, typeof(Character));
       
    }
    void SelectP2()
    {
        ReadyP2 = true;
        //FindObjectOfType<GameManager>().PathP2 = FindSource(indexP2);
        //FindObjectOfType<GameManager>().Self2 = (Character)Resources.Load(FindObjectOfType<GameManager>().PathP2, typeof(Character));
        manager.PathP2 = FindSource(indexP2);
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
      //  manager.Self1 
        SceneManager.LoadScene(1);
    }


    string FindSource(int index)
    {
        string path = "SampleCharactePreFab";

        switch (index)
        {
            case 0:
                path = "SampleCharactePreFab";
                break;
            case 1:
                path = "SampleCharactePreFab";
                break;
            case 2:
                path = "SampleCharactePreFab";
                break;
            case 3:
                path = "SampleCharactePreFab";
                break;
            case 4:
                path = "SampleCharactePreFab";
                break;
            case 5:
                path = "Thornton";
                break;
            case 6:
                path = "SampleCharactePreFab";
                break;
            case 7:
                path = "Klefstad";
                break;
            case 8:
                path = "SampleCharactePreFab";
                break;
            case 9:
                path = "Pattis";
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

        while (turn2 == false)
        {
            if (MoveP2.x > 0.8f)
            {
                if (indexP2 + 1 + 1 == CharPics.Length / 2 + 1 || indexP2 + 1 + 1 > CharPics.Length)
                {
                    indexP2 = indexP2 - CharPics.Length / 2 + 1;
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
                if (indexP2 + 1 == CharPics.Length / 2 + 1 || indexP2 == 0)
                {
                    indexP2 = indexP2 + CharPics.Length / 2 - 1;
                }
                else
                {
                    indexP2 -= 1;
                }


                //                yield return new WaitForSeconds(0.15f);
                //         Debug.Log(indexP2);
            }

            if (MoveP2.y < -0.8f)
            {
                if (indexP2 + 1 <= CharPics.Length / 2)
                {
                    indexP2 = indexP2 + CharPics.Length / 2;
                }
                else
                {
                    indexP2 = indexP2 - CharPics.Length / 2;
                }
            }
            else if (MoveP2.y > 0.8f)
            {
                if (indexP2 + 1 > CharPics.Length / 2)
                {
                    indexP2 = indexP2 - CharPics.Length / 2;
                }
                else
                {
                    indexP2 = indexP2 + CharPics.Length / 2;
                }


                if (indexP2 > CharPics.Length - 1)
                {
                    indexP2 = 0;
                }

                if (indexP2 < 0)
                {
                    indexP2 = CharPics.Length;
                }
                //   yield return new WaitForSeconds(0.15f);
                // turn1 = true;
            }
            yield return new WaitForSeconds(0.15f);
            turn2 = true;



            P2Arrow.transform.position = new Vector2(CharPics[indexP2].transform.position.x, CharPics[indexP2].transform.position.y - 35.0f);





            //    yield return null;
        }
    }
        IEnumerator ShiftP1Cursor()
        {
            turn1 = false;

            while (turn1 == false)
            {
                if (MoveP1.x > 0.8f)
                {
                    if (indexP1 + 1 + 1 == CharPics.Length / 2 + 1 || indexP1 + 1 + 1 > CharPics.Length)
                    {
                        indexP1 = indexP1 - CharPics.Length / 2 + 1;
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
                    if (indexP1 + 1 == CharPics.Length / 2 + 1 || indexP1 == 0)
                    {
                        indexP1 = indexP1 + CharPics.Length / 2 - 1;
                    }
                    else
                    {
                        indexP1 -= 1;
                    }


                    //                yield return new WaitForSeconds(0.15f);
                    //         Debug.Log(indexP2);
                }

                if (MoveP1.y < -0.8f)
                {
                    if (indexP1 + 1 <= CharPics.Length/2)
                    {
                        indexP1 = indexP1 + CharPics.Length /2;
                    }
                    else
                    {
                        indexP1 = indexP1 - CharPics.Length / 2;
                    }
                }
                else if (MoveP1.y > 0.8f)
                {
                    if (indexP1 + 1 > CharPics.Length/2)
                    {
                        indexP1 = indexP1 - CharPics.Length / 2;
                    }
                    else
                    {
                        indexP1 = indexP1 + CharPics.Length / 2;
                    }


                    if (indexP1 > CharPics.Length - 1)
                    {
                        indexP1 = 0;
                    }

                    if (indexP1 < 0)
                    {
                        indexP1 = CharPics.Length;
                    }
                 //   yield return new WaitForSeconds(0.15f);
                   // turn1 = true;
                }
            yield return new WaitForSeconds(0.15f);
            turn1 = true;



            P1Arrow.transform.position = new Vector2(CharPics[indexP1].transform.position.x, CharPics[indexP1].transform.position.y + 35.0f);






                //    yield return null;
            }
        }

    
}
