using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattis : Character
{
    // Start is called before the first frame update
    void Start()
    {

    }
//    float TeleportDistance;

    //teleport
    public override IEnumerator SpecAtk(BoxCollider2D SpecHitBox)
    {

        Player P = SpecHitBox.GetComponent<Player>();
        P.Aura.SetActive(true);
        SpecHitBox.gameObject.layer = 10;
        P.HighBlocking = true;
        P.LowBlocking = true;
        int F = SpecAtkHit;

        SpecHitBox.GetComponent<SpriteRenderer>().enabled = false;
       // float Speed = 15.0f * P.transform.localScale.x;
        
        while (F >= 0)
        {
       //     P.RB.velocity = new Vector2(Speed, 0.0f);
            F -= 1;
            if (P.Move.x >= 0.8f)
            {

                P.RB.velocity = new Vector2(50.0f * MoveSpeed * 2.0f, 0.0f) * Time.fixedDeltaTime;

                //change blocking bool if the player is walking or not
                //if (transform.localScale.x >=0.0f)
                //{
                //    HighBlocking = false;
                //}
                //else
                //{
                //    HighBlocking = true;
                //}

            }
            //More movement
            else if (P.Move.x <= -0.8f)
            {

                P.RB.velocity = new Vector2(-50.0f * MoveSpeed * 2.0f, 0.0f) * Time.fixedDeltaTime;

                //if (transform.localScale.x <= 0.0f)
                //{
                //    HighBlocking = false;
                //}
                //else
                //{
                //    HighBlocking = true;
                //}
            }
            else
            {
                P.RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;
                // HighBlocking = true;
            }


            yield return null;
        }
        P.HighBlocking = false;
        P.LowBlocking = false;
        P.RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;
        SpecHitBox.GetComponent<SpriteRenderer>().enabled = true;
        SpecHitBox.gameObject.layer = 8;
        P.RB.velocity = new Vector2(0.0f, 0.0f);
        P.PlayerBox.enabled = true;
        //        Transform T = SpecHitBox.GetComponent<Transform>();
        //      T.position = new Vector2(T.position.x + Spec)
        P.Aura.SetActive(false);
        yield return null;
    }


    public override IEnumerator RageMode()
    {
 //       SpecAtkStartUp = 0;
   //     SpecAtkCoolDown = 0;
        yield return null;

    }
}
