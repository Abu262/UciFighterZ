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
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                Debug.Log("Hello");
                StartCoroutine(MedAttack());
            }
            //X
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                StartCoroutine(LowAttack());
            }
            //circle
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                StartCoroutine(SpecAttack());
            }
            //triangle
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                StartCoroutine(HighAttack());
            }

            Move = new Vector2(Input.GetAxis("Horizontal1"), 0.0f);

            yield return null;
        }

    }



}
