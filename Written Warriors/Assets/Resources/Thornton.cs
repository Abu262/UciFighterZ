using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thornton : Character
{
    int Charges = 0;
    public int MaxCharges = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override IEnumerator SpecAtk(BoxCollider2D SpecHitBox)
    {
        int F = SpecAtkHit;
        if (Charges <= MaxCharges)
        {
            

            while (F > 0)
            {

                F -= 1;
                yield return null;
            }
            Charges += 1;
        }
        else
        {
            SpecHitBox.enabled = true;

            F = F * 2;
            while (F > 0)
            {

                
                F -= 1;
                yield return null;
            }
            Charges = 0;
            SpecHitBox.enabled = false;

        }
        yield return null;
    }
}
