using System.Collections;
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
        Player P = SpecHitBox.GetComponent<Player>();
        SpecHitBox.enabled = true;
        int F = SpecAtkHit;
        P.HighBlocking = true;
        P.LowBlocking = true;
        while (F > 0)
        {
            if (P.CurrentBlocking == true || P.Opponent.Hit == true)
            {
                F = 0;
            }
  //          SpecHitBox.enabled = true;
            P.RB.velocity = new Vector2(MoveSpeed * speedscalar * transform.localScale.x, 0.0f);
            F -= 1;
//            yield return new WaitForSeconds(5.0f / 60.0f);
    //
            yield return null;
        }
        SpecHitBox.enabled = false;
        P.HighBlocking = false;
        P.LowBlocking = false;




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
