using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JESSE ALLAS
//Last Updated: 10/1/2019

public class Player2Scr : Player
{
    //Player2Scr is a child of Player,
    //we do this to grab the controls for the second player

    //Nobody will have to touch this, all it does is grab controls and set some static things

  
          
    private void Awake()
    {
        //    Path = FindObjectOfType<GameManager>().PathP2;
 
        Self = Resources.Load<Character>(FindObjectOfType<GameManager>().PathP2);

        opponentTag = "Player1";
        //set hitbix sizes and positions
        //HighHitBox.offset = Self.HighHitBoxOffset;
        //MedHitBox.offset = Self.MedHitBoxOffset;
        //LowHitBox.offset = Self.LowHitBoxOffset;

        //HighHitBox.size = Self.HighHitBoxSize;
        //MedHitBox.size = Self.MedHitBoxSize;
        //LowHitBox.size = Self.LowHitBoxSize;



        StartCoroutine(FakeUpdate());
        //Controls.Gameplay.High2.performed += ctx => StartCoroutine(HighAttack());
        //Controls.Gameplay.Medium2.performed += ctx => StartCoroutine(MedAttack());
        //Controls.Gameplay.Low2.performed += ctx => StartCoroutine(LowAttack());
        //Controls.Gameplay.Special2.performed += ctx => StartCoroutine(SpecAttack());
        //Controls.Gameplay.Move2.performed += ctx => Move = ctx.ReadValue<Vector2>();
        //Controls.Gameplay.Move2.canceled += ctx => Move = Vector2.zero;

    }


    IEnumerator FakeUpdate()
    {

        //controller stuff
        while (true)
        {
            if (Input.GetKey(KeyCode.Joystick2Button0))
            {
                StartCoroutine(MedAttack());
            }
            //X
            if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                StartCoroutine(LowAttack());
            }
            //circle
            if (Input.GetKeyDown(KeyCode.Joystick2Button2))
            {
                StartCoroutine(SpecAttack());
            }
            //triangle
            if (Input.GetKeyDown(KeyCode.Joystick2Button3))
            {
                StartCoroutine(HighAttack());
            }

            Move = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));

            yield return null;
        }

    }

}
