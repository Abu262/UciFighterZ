﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thornton : Character
{
    int Charges = 0;
    public int MaxCharges = 5;
    public Sprite[] SpecChargeAnim;
    // GameObject Rage;

    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Update()
    {

    }

    public override IEnumerator SpecAtk(BoxCollider2D SpecHitBox)
    {
        //if (SpecHitBox.transform.childCount == 0)
        //{
        //    Rage = Instantiate(Aura, new Vector3(0, 0, 0), Quaternion.identity);
        //    Rage.transform.SetParent(SpecHitBox.transform, false);
        //    Rage.SetActive(false);
        //}

        Player P = SpecHitBox.GetComponent<Player>();

        P.Aura.SetActive(true);
        SpriteRenderer SP = SpecHitBox.GetComponent<SpriteRenderer>();
        int F = SpecAtkHit;
        int index = 0;
        if (P.Charges <= MaxCharges)
        {
            //    SP.sprite = SpecSprStartUp;
            
            //int FrameCount = Frames;
            
                
                // animator.speed = (float)((1.0f / Time.smoothDeltaTime) / 60);
            
            while (F > 0)
            {
                index = Mathf.Min(SpecAtkHit - F, SpecChargeAnim.Length - 1);
                P.CurrentForm.sprite = SpecChargeAnim[index];
                F -= 1;
                yield return null;
            }
            P.Charges += 1;
        }
        else
        {
            Vector2 O = new Vector2(SpecHitBox.offset.x + (SpecHitBox.size.x / 2) - 0.6f, SpecHitBox.offset.y);
            SpecHitBox.transform.GetChild(0).gameObject.SetActive(true);
            float x = SpecHitBox.transform.GetChild(0).transform.localPosition.x;
            SpecHitBox.transform.GetChild(0).transform.localPosition = O;
            SpecHitBox.enabled = true;
      //      SP.sprite = SpecSprHit;
            F = F * 2;
            while (F > 0)
            {

                index = Mathf.Min(SpecAtkHit - F, SpecAtkAnim.Length - 1);
                P.CurrentForm.sprite = SpecAtkAnim[index];
                F -= 1;
                yield return null;
            }
            P.Aura.SetActive(false);
            P.Charges = 0;
            SpecHitBox.enabled = false;
            SpecHitBox.transform.GetChild(0).gameObject.SetActive(false);

        }
        if (P.Charges <= MaxCharges)
        {
            P.Aura.SetActive(false);
        }
        yield return null;
    }

    public override IEnumerator RageMode()
    {
        //MoveSpeed = MoveSpeed * 1.5f;
        yield return null;
    }

}
