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


  
        StartCoroutine(FakeUpdate());   //start the "update"


    }

    IEnumerator FakeUpdate()
    {

        //controller stuff
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.D))
            {
                Debug.Log("Hello");
                StartCoroutine(MedAttack());
            }
            //X
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.F))
            {
                StartCoroutine(LowAttack());
            }
            //circle
            if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.G))
            {
                StartCoroutine(SpecAttack());
            }
            //triangle
            if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.R))
            {
                StartCoroutine(HighAttack());
            }

            if (Input.GetKey(KeyCode.A))
            {
                Move = new Vector2(-1.0f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Move = new Vector2(1.0f,0.0f);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                Move = new Vector2(0.0f,-1.0f);
            }
            else
            {
                Move = new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));
            }







            yield return null;
        }

    }



}
