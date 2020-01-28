using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WongMa : Character
{
    int Charges = 0;
    public int MaxCharges = 5;
    
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
        int R = Random.Range(1, 4);
        Player P = SpecHitBox.GetComponent<Player>();
 //       Vector2 constMotion = new Vector2(-1.0f * MoveSpeed * speedscalar * P.transform.localScale.x, 0.0f);
        Vector3 s = P.transform.localScale;
        P.Aura.SetActive(true);

        int F = SpecAtkHit;

        if (R == 1)
        {
            F = LowAtkStartUp;
            while (F > 0)
            {
                Debug.Log("LOW");
                P.transform.localScale = s;
                F -= 1;
                yield return null;
            }
        }
        if (R == 2)
        {
            F = MedAtkStartUp;
            while (F > 0)
            {
                Debug.Log("MEDIUM");
                P.transform.localScale = s;
                F -= 1;
                yield return null;
            }
        }
        if (R == 3)
        {
            F = HighAtkStartUp;
            while (F > 0)
            {
                Debug.Log("HIGH");
                P.transform.localScale = s;
                F -= 1;
                yield return null;
            }
        }


        SpecHitBox.enabled = false;
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
