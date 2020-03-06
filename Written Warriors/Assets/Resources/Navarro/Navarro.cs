using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navarro : Character
{
    //    public float copyHighAttackerBlockPush;// = 0.0f;
    //  public float copyHighDefenderBlockPush;// = 0.0f;
    //   public float copyMedDefenderBlockPush;// = 0.0f;
    // public float copyMedAttackerBlockPush;// = 0.0f;
    //   public float copyLowAttackerBlockPush;// = 0.0f;
    //   public float copyLowDefenderBlockPush;// = 0.0f;
    public float speedscalar = 0.25f;
    public int Dash = 20;
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
        Vector2 constMotion = new Vector2(MoveSpeed * speedscalar * P.transform.localScale.x, 0.0f);
        Vector3 s = P.transform.localScale;
        P.Aura.SetActive(true);
      //  SpecHitBox.enabled = true;
        int F = SpecAtkHit;
        int C = Dash;
        P.animator.SetBool("IsSpecAtk", true);
        if (P.opponentTag == "Player2")
        {

            
            while (C > 0 && (Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.R)))
            {
                P.RB.velocity = constMotion;
                P.transform.localScale = s;
                C -= 1;
                yield return null;
            }
            if (C < 1)
            {
                P.animator.SetBool("IsSpecAtkLow", true);
                SpecHitBox.enabled = true;
                Vector2 O = new Vector2(SpecHitBox.offset.x + (SpecHitBox.size.x / 2) - 0.6f, SpecHitBox.offset.y);
                SpecHitBox.transform.GetChild(0).gameObject.SetActive(true);
                float x = SpecHitBox.transform.GetChild(0).transform.localPosition.x;
                SpecHitBox.transform.GetChild(0).transform.localPosition = O;
                while (F > 0)
                {

                    P.RB.velocity = new Vector2(0.0f,0.0f);
                    P.transform.localScale = s;
                    F -= 1;
                    yield return null;
                }
                SpecHitBox.enabled = false;
                SpecHitBox.transform.GetChild(0).gameObject.SetActive(false);
            }


        }
        else if (P.opponentTag == "Player1")
        {
            while (C > 0 && (Input.GetKey(KeyCode.Joystick2Button2) || Input.GetKey(KeyCode.LeftBracket)))
            {
                P.RB.velocity = constMotion;
                P.transform.localScale = s;
                C -= 1;
                yield return null;
            }
            if (C < 1)
            {
                P.animator.SetBool("IsSpecAtkLow", true);
                SpecHitBox.enabled = true;
                Vector2 O = new Vector2(SpecHitBox.offset.x + (SpecHitBox.size.x / 2) - 0.6f, SpecHitBox.offset.y);
                SpecHitBox.transform.GetChild(0).gameObject.SetActive(true);
                float x = SpecHitBox.transform.GetChild(0).transform.localPosition.x;
                SpecHitBox.transform.GetChild(0).transform.localPosition = O;
                while (F > 0)
                {

                    P.RB.velocity = new Vector2(0.0f, 0.0f);
                    P.transform.localScale = s;
                    F -= 1;
                    yield return null;
                }
                SpecHitBox.enabled = false;
                SpecHitBox.transform.GetChild(0).gameObject.SetActive(false);
            }

        }

        SpecHitBox.enabled = false;

        P.Aura.SetActive(false);
        P.animator.SetBool("IsSpecAtkLow", false);
        P.animator.SetBool("IsSpecAtk", false);
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
