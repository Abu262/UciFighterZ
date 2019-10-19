using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//JESSE ALLAS
//Last Updated: 10/1/2019

public class Player1Scr : Player
{
    //Player1Scr is a child of Player,
    //we do this to grab the controls for the second player

    //Nobody will have to touch this, all it does is grab controls and set some static things

    private void Awake()
    {
;
        Self = Resources.Load<Character>(FindObjectOfType<GameManager>().PathP1);
        opponentTag = "Player2";
        //set hitbox sizes and positions
        //HighHitBox.offset = Self.HighHitBoxOffset;
        //MedHitBox.offset = Self.MedHitBoxOffset;
        //LowHitBox.offset = Self.LowHitBoxOffset;

        //HighHitBox.size = Self.HighHitBoxSize;
        //MedHitBox.size = Self.MedHitBoxSize;
        //LowHitBox.size = Self.LowHitBoxSize;


        //call controls
        Controls = new PlayerControls();
        Controls.Gameplay.High1.performed += ctx => StartCoroutine(HighAttack());
        Controls.Gameplay.Medium1.performed += ctx => StartCoroutine(MedAttack());
        Controls.Gameplay.Low1.performed += ctx => StartCoroutine(LowAttack());
        Controls.Gameplay.Special1.performed += ctx => StartCoroutine(SpecAttack());
        Controls.Gameplay.Move1.performed += ctx => Move = ctx.ReadValue<Vector2>();
        Controls.Gameplay.Move1.canceled += ctx => Move = Vector2.zero;

    }




}
