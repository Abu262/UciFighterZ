using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattis : Character
{
    // Start is called before the first frame update
    void Start()
    {

    }


    //teleport
    public override IEnumerator SpecAtk(BoxCollider2D SpecHitBox)
    {
        yield return null;
    }
}
