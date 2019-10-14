using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JESSE ALLAS
//Last Updated: 10/1/2019
//sample projectile script

public class ProjectileScr : MonoBehaviour
{

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "Player1" || col.tag == "Player2") && !(col.isTrigger))
        {
            if (col.GetComponent<Player>().HighBlocking == true)
            {
                Debug.Log("BLOCK");
            }
            else
            {
                col.GetComponent<Player>().TakeDamage(); //this is why we made a TakeDamage function, projectiles dont actually reach the player who shot it
                Debug.Log("HIT");
            }

            Destroy(gameObject);
        }
    }
}
