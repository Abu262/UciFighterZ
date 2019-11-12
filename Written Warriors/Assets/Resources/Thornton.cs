using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thornton : Character
{
    int Charges = 0;
    public int MaxCharges = 5;
    GameObject Rage;

    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Update()
    {

    }

    public override IEnumerator SpecAtk(BoxCollider2D SpecHitBox)
    {
        if (SpecHitBox.transform.childCount == 0)
        {
            Rage = Instantiate(Aura, new Vector3(0, 0, 0), Quaternion.identity);
            Rage.transform.SetParent(SpecHitBox.transform, false);
            Rage.SetActive(false);
        }


        SpriteRenderer SP = SpecHitBox.GetComponent<SpriteRenderer>();
        int F = SpecAtkHit;
        if (Charges <= MaxCharges)
        {
            SP.sprite = SpecSprStartUp;

            while (F > 0)
            {

                F -= 1;
                yield return null;
            }
            Charges += 1;
        }
        else
        {
            Rage.SetActive(false);
            SpecHitBox.enabled = true;
            SP.sprite = SpecSprHit;
            F = F * 2;
            while (F > 0)
            {

                
                F -= 1;
                yield return null;
            }
            Charges = 0;
            SpecHitBox.enabled = false;

        }
        if (Charges == MaxCharges)
        {
            Rage.SetActive(true);
        }
        yield return null;
    }

    public override IEnumerator RageMode()
    {
        //MoveSpeed = MoveSpeed * 1.5f;
        yield return null;
    }

}
