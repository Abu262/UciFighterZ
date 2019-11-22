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
        
        CurrentForm.color= Color.blue;
        Self = Resources.Load<Character>(FindObjectOfType<GameManager>().PathP2);

        opponentTag = "Player1";
        CurrentForm.sprite = Self.StandSpr;
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
            //can only attack if they arent already doing something else and they arent currently  hit
            if (TakingAction == false && Hitstun == false && IsBlocking == false)
            {
                if (Input.GetKey(KeyCode.Joystick2Button0) || Input.GetKey(KeyCode.Minus))
                {
                    StartCoroutine(MedAttack());
                }
                //X
                if (Input.GetKeyDown(KeyCode.Joystick2Button1) || Input.GetKey(KeyCode.LeftBracket))
                {
                    StartCoroutine(LowAttack());
                }
                //circle
                if (Input.GetKeyDown(KeyCode.Joystick2Button2) || Input.GetKey(KeyCode.RightBracket))
                {
                    StartCoroutine(SpecAttack());
                }
                //triangle
                if (Input.GetKeyDown(KeyCode.Joystick2Button3) || Input.GetKey(KeyCode.Equals))
                {
                    StartCoroutine(HighAttack());
                }
                if (Input.GetKeyDown(KeyCode.Joystick2Button4) || Input.GetKeyDown(KeyCode.Joystick2Button5))
                {
                    StartCoroutine(Parry());
                }
                

                if (Input.GetKey(KeyCode.K))
                {
                    Move = new Vector2(-1.0f, 0.0f);
                }
                else if (Input.GetKey(KeyCode.Semicolon))
                {
                    Move = new Vector2(1.0f, 0.0f);
                }
                else if (Input.GetKey(KeyCode.L))
                {
                    Move = new Vector2(0.0f, -1.0f);
                }
                else
                {
                    Move = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
                }
            }
       //     if (Input.GetKeyDown(KeyCode.Joystick1Button9))
         //   {
           //     RB.velocity = Vector2.zero;
             //   Move = Vector2.zero;
               // StartCoroutine(Pause());
           // }



            yield return null;
        }

    }

}
