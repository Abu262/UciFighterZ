using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JESSE ALLAS
//Last Updated: 10/1/2019
//Child of character class, smaple

//Hear we can customize unique characters by adjusting data


public class SampleCharacterScr : Character
{
    //This lets us set up this character's stats and also set up the special attack

    public GameObject projectile;
   

    void Start()
    {
        //adjust some stats, make the moves hitframes smaller
        LowAtkHit = 3;
        MedAtkHit = 3;
        HighAtkHit = 3;

        SpecialStr = "High"; //special attacks are high so we label it here
    }


    //makes a bullet and shoots it
    public override IEnumerator SpecAtk()
    {

        GameObject bullet = Instantiate(projectile, new Vector2(transform.position.x + 1.25f * transform.localScale.x, transform.position.y), Quaternion.identity) as GameObject;
    
        bullet.GetComponent<Rigidbody2D>().velocity =  transform.localScale * new Vector2(2.0f,0.0f);
        yield return null;
    }
}
