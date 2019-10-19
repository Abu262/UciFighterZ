using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//JESSE ALLAS
//Last Updated: 10/1/2019
//Character stats parent class

public class Character : MonoBehaviour
{

    // MISC data
    public Sprite PlayerImage; //player picture, ill make this an animation when we have animations.

    public int Health = 3; // Health Points, I think all characters will have 3 hp

    public Vector2 PlayerSize = new Vector2(1.0f, 1.25f); //player hitbox size
    public Vector2 PlayerOffset = new Vector2(0.0f, 0.0f); //player hitbox position
    
    public float MoveSpeed = 50.0f; //Move speed
    ////////////////////
    

    //Low attack data    
    public int LowAtkStartUp = 3;  //Low Attack startup frames
    public int LowAtkHit = 6;   //Low Attack hit frames
    public int LowAtkCoolDown = 3;   //Low Attack Cooldown frames
    //public Animation LowAtkAnim;    //Low Attack Animation

    public Vector2 LowHitBoxOffset = new Vector2(1.5f, -0.5f);   //Low Attack Hitbox stats
    public Vector2 LowHitBoxSize = new Vector2(1.5f, 0.5f);
    //////////////////


    //Mid attack data
    public int MedAtkStartUp = 3;     //Med Attack startup frames
    public int MedAtkHit = 6;  //Med Attack hit frames
    public int MedAtkCoolDown = 3;  //Med Attack Cooldown frames
    //public Animation MedAtkAnim;  //Med Attack Animation
    
    public Vector2 MedHitBoxOffset = new Vector2(1.5f, 0.0f);  //Med Attack Hitbox stats
    public Vector2 MedHitBoxSize = new Vector2(1.5f, 0.5f);
    //////////////////


    //High Attack data
    public int HighAtkStartUp = 3; //High Attack startup frames
    public int HighAtkHit = 6;  //High Attack hit frames
    public int HighAtkCoolDown = 3; //High Attack Cooldown frames
    //public Animation HighAtkAnim; //High Attack Animation
    
    public Vector2 HighHitBoxOffset = new Vector2(1.5f, 0.5f); //High Attack Hitbox stats
    public Vector2 HighHitBoxSize = new Vector2(1.5f, 0.5f);
    //////////////////


    //Spec attack data
    public int SpecAtkStartUp = 3;      //Special Attack startup frames
    public int SpecAtkHit = 3; //Special Attack hit frames
    public int SpecAtkCoolDown = 3; //Special Attack Cooldown frames
    
    public Vector2 SpecHitBoxOffset = new Vector2(4.0f, -1.25f); //Special Attack Hitbox stats
    public Vector2 SpecHitBoxSize = new Vector2(5.0f, 1.0f);

    public string SpecialStr; //We title this either High, Middle, or Low depending on what kind of attack it is
    //public Animation SpecAtkAnim;    //Special Attack Animation

    //Special Attack function, let's us make a unique special attack
    public virtual IEnumerator SpecAtk()
    {
        yield return null;
    }
    ////////////////////

    

}
