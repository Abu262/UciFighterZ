﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klefstad : Character
{
    //    public float copyHighAttackerBlockPush;// = 0.0f;
    //  public float copyHighDefenderBlockPush;// = 0.0f;
    //   public float copyMedDefenderBlockPush;// = 0.0f;
    // public float copyMedAttackerBlockPush;// = 0.0f;
    //   public float copyLowAttackerBlockPush;// = 0.0f;
    //   public float copyLowDefenderBlockPush;// = 0.0f;
    public float speedscalar = 0.25f;

    // Start is called before the first frame update
    void Awake()
    {
/*        copyHighAttackerBlockPush = HighAttackerBlockPush;
        copyHighDefenderBlockPush = HighDefenderBlockPush;
        copyMedAttackerBlockPush = MedAttackerBlockPush;
        copyMedDefenderBlockPush = MedDefenderBlockPush;
        copyLowAttackerBlockPush = LowAttackerBlockPush;
        copyLowDefenderBlockPush = LowDefenderBlockPush;*/

    }

    private void Start()
    {
/*        HighAttackerBlockPush = copyHighAttackerBlockPush;
        HighDefenderBlockPush = copyHighDefenderBlockPush;
        MedAttackerBlockPush = copyMedAttackerBlockPush;
        MedDefenderBlockPush = copyMedDefenderBlockPush;
        LowAttackerBlockPush = copyLowAttackerBlockPush;
        LowDefenderBlockPush = copyLowDefenderBlockPush;*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    //charge
    public override IEnumerator SpecAtk(BoxCollider2D SpecHitBox)
    {
        int index = 0;
        Player P = SpecHitBox.GetComponent<Player>();
        Vector2 constMotion = new Vector2(MoveSpeed * speedscalar * P.transform.localScale.x, 0.0f);
        Vector3 s = P.transform.localScale;
        P.Aura.SetActive(true);
        SpecHitBox.enabled = true;
        Vector2 O = new Vector2(SpecHitBox.offset.x + (SpecHitBox.size.x / 2) - 0.6f, SpecHitBox.offset.y);
        SpecHitBox.transform.GetChild(0).gameObject.SetActive(true);
        float x = SpecHitBox.transform.GetChild(0).transform.localPosition.x;
        SpecHitBox.transform.GetChild(0).transform.localPosition = O;
        int F = SpecAtkHit;
        P.HighBlocking = true;
        P.LowBlocking = true;
        while (F > 0)
        {
            index = Mathf.Min(SpecAtkHit - F, SpecAtkAnim.Length - 1);
            P.CurrentForm.sprite = SpecAtkAnim[index];
            if (P.Opponent.CurrentBlocking == true || P.Opponent.Hitstun == true)
            {
                F = 0;
            }
            //          SpecHitBox.enabled = true;
            P.RB.velocity = constMotion;
            P.transform.localScale = s;
            F -= 1;
//            yield return new WaitForSeconds(5.0f / 60.0f);
    //
            yield return null;
        }
        SpecHitBox.enabled = false;
        SpecHitBox.transform.GetChild(0).gameObject.SetActive(false);
        P.HighBlocking = false;
        P.LowBlocking = false;

        P.Aura.SetActive(false);


        yield return null;
    }

    public override IEnumerator RageMode()
    {
 //       HighAttackerBlockPush = 0.0f;
   //     HighDefenderBlockPush = 0.0f;
     //   MedDefenderBlockPush = 0.0f;
   //     MedAttackerBlockPush = 0.0f;
     //   LowAttackerBlockPush = 0.0f;
      //  LowDefenderBlockPush = 0.0f;

        yield return null;
    }



    }
