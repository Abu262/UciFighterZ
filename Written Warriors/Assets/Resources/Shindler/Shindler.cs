using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shindler : Character
{
//    int Charges = 0;
  //  public int MaxCharges = 5;
    public float speedscalarBack = 0.25f;
    public float speedscalarForward = 0.25f;
    public int backdashtime = 10;
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
        Player P = SpecHitBox.GetComponent<Player>();
        Vector2 constMotion = new Vector2(-1.0f * MoveSpeed * speedscalarBack * P.transform.localScale.x, 0.0f);
        Vector3 s = P.transform.localScale;
        P.Aura.SetActive(true);

        int F = SpecAtkHit;
        int B = backdashtime;

        while (B > 0)
        {
            P.RB.velocity = constMotion;
            P.transform.localScale = s;
            B -= 1;
            yield return null;
        }
        //yield return null;
        constMotion = new Vector2(MoveSpeed * speedscalarForward * P.transform.localScale.x, 0.0f);
        Vector2 O = new Vector2(SpecHitBox.offset.x + (SpecHitBox.size.x / 2) - 0.6f, SpecHitBox.offset.y);
        SpecHitBox.transform.GetChild(0).gameObject.SetActive(true);
        float x = SpecHitBox.transform.GetChild(0).transform.localPosition.x;
        SpecHitBox.transform.GetChild(0).transform.localPosition = O;
        SpecHitBox.enabled = true;
        while (F > 0)
        {

            P.RB.velocity = constMotion;
            P.transform.localScale = s;
            F -= 1;
            yield return null;
        }
        SpecHitBox.enabled = false;
        SpecHitBox.transform.GetChild(0).gameObject.SetActive(false);
        //P.HighBlocking = false;
        //P.LowBlocking = false;

        P.Aura.SetActive(false);


        yield return null;
    }

    public override IEnumerator RageMode()
    {
        //MoveSpeed = MoveSpeed * 1.5f;
        yield return null;
    }

}
