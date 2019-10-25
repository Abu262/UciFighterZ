using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thornton : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override IEnumerator SpecAtk(BoxCollider2D SpecHitBox)
    {
        yield return null;
    }
}
