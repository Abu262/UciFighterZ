using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JESSE ALLAS
//Last Updated: 10/1/2019

public class Player1Scr : Player
{
    //Player1Scr is a child of Player,
    //we do this to grab the controls for the second player

    //Nobody will have to touch this, all it does is grab controls and set some static things

    private void Awake()
    {

        Self = Resources.Load<Character>(FindObjectOfType<GameManager>().PathP1); ///load the character script
        opponentTag = "Player2";        //set the tag for the opponent
       // CurrentForm.sprite = Self.StandSpr;


        StartCoroutine(FakeUpdate());   //start the "update"


    }

    IEnumerator FakeUpdate()
    {
        //2 is square
        //    1 is Circle
        //    x is 0
        //controller stuff
        while (true)
        {
            //   if (!PM.isPaused)
            //  {
            if (TakingAction == false && Hitstun == false && IsBlocking == false)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Alpha4))
                {
//                    Debug.Log("Hello");
                    StartCoroutine(MedAttack());
                }
                //X
                if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.R))
                {
                    StartCoroutine(LowAttack());
                }
                //circle
                if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.T))
                {
                    StartCoroutine(SpecAttack());
                }
                //triangle
                if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Alpha5))
                {
                    StartCoroutine(HighAttack());
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.Joystick1Button5))
                {
                    StartCoroutine(Parry());
                }
                if (Input.GetKeyDown(KeyCode.Joystick2Button9))
                {
                    StartCoroutine(Pause());
                }

                if (Input.GetKey(KeyCode.A))
                {
                    Move = new Vector2(-1.0f, 0.0f);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Move = new Vector2(1.0f, 0.0f);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    Move = new Vector2(0.0f, -1.0f);
                }
                else
                {
                    Move = new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));
                }
            }
           // else
          //  {
          //      Move.x = 0.0f;
            //    RB.velocity = Vector2.zero;
            //}
        //    if (Input.GetKeyDown(KeyCode.Joystick1Button9))
          //  {
          //
            //    StartCoroutine(Pause());
           // }

            yield return null;
        }

    }



}
