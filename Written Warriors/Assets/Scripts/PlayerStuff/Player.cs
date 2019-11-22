using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

//JESSE ALLAS
//Last Updated: 11/21/2019

//This is all the controls and stuff for the player
//designers probably won' have to touch this, 

//Keep in mind that all coordinates are relative to the object, so you dont need to worry about characters switching sides

public abstract class Player : MonoBehaviour
{

    //some generally important stuff
    public Camera cam; //camera
    public int Health; //Since the health value changes we want to copy the character health stat
    public PlayerControls Controls; //Player Controls
    public Character Self; //the character we're getting all the stats from
    public Player Opponent; //the opponent player object
    public string opponentTag; //The opponent tag, for checking collisions 
    public Vector2 Move;    //vector to move the player
    // ///////////////////////

    //the hitboxes for the different attacks
    public BoxCollider2D HighHitBox;
    public BoxCollider2D MedHitBox;
    public BoxCollider2D LowHitBox;
    public BoxCollider2D SpecHitBox;
    public BoxCollider2D PlayerBox;
    ////////////////////////


//    public bool Hit; //true when the player is hit


    string CurrentAtk; //the string titling the current move

    //bunch of blocking stuff
    private int BlockTime;   //variable to time how long you are in blockstun
    public bool CurrentBlocking = false;  //bool to make sure we dont overlap blocking functions (it gets weird if it does)
    public int FrameCountParry;  //into to count the parry frames
    
    //bools to check if the player is blocking
    public bool HighBlocking;
    public bool LowBlocking;
    // ////////////////////////////

    
    //managers for a  bunch of random stuff
    public GameOver GO;     //reference to the game over script
    public PauseMenu PM;    //reference to the pause menu script
    private AudioManager AM; //reference to audio manager
    private GameManager GM; //reference to game manager
    // ////////////////////

    [HideInInspector]
    public int Charges; //this is a quickfix for thornton's special, I'll fix it later EDIT: i still dont know a bett way to do this
    

    private bool KnockingBack = false; //bool to make sure we dont overlap knockbacks

    //the big chungi, these determine wether you can act or not
    public bool Hitstun = false;     //this is true when you get hit
    public bool IsBlocking = false;   //this is true when you're blocking
    public bool TakingAction = true;     //this is true when you attack or move or parry, basically when you press buttons

    //some random stuff that we kinda need
    public SpriteRenderer CurrentForm; //refernece to the sprite object
    float OriginalSize; //saves the camera's size
    public GameObject Aura; //a super saiyan affect for special moves

    //RigidBody because physics dont work if we dont
    public Rigidbody2D RB;
    // ////////


    private void Start()
    {
        Charges = 0;
        Aura = Instantiate(Self.Aura, new Vector3(0f,0f,0f), Quaternion.identity);
        Aura.transform.SetParent(gameObject.transform);
        Aura.transform.localPosition = new Vector3(0, 0, 0);
        Aura.SetActive(false);
        GM = FindObjectOfType<GameManager>();
        AM = FindObjectOfType<AudioManager>();
        OriginalSize = cam.orthographicSize;
        PlayerBox.size = new Vector2(Self.PlayerSize.x, Self.PlayerSize.y);
        PlayerBox.offset = new Vector2(Self.PlayerOffset.x, Self.PlayerOffset.y);

        Self.transform.position = transform.position;
        

        //setting some initial things
      //  Hit = false;
        Health = Self.Health;
       // HP.text = Health.ToString();
        HighBlocking = false;
        LowBlocking = false;
        RB = gameObject.GetComponent<Rigidbody2D>();
        HighHitBox.offset = Self.HighHitBoxOffset;
        MedHitBox.offset = Self.MedHitBoxOffset;
        LowHitBox.offset = Self.LowHitBoxOffset;
        SpecHitBox.offset = Self.SpecHitBoxOffset;

        HighHitBox.size = Self.HighHitBoxSize;
        MedHitBox.size = Self.MedHitBoxSize;
        LowHitBox.size = Self.LowHitBoxSize;
        SpecHitBox.size = Self.SpecHitBoxSize;
        //  ready = true;
    }

//    private void Awake()
  //  {
  //
    //}


    void FixedUpdate()
    {

        //If the player isnt taking an action AND the player isn't currentlly hit AND the player isnt bllocking
        //then they can move
        if (TakingAction == false && Hitstun == false && IsBlocking == false)
        {
            //Move changes when the player waggles the analog stick
            //Move.x controls left and right movement
            if (Move.x >= 0.8f)
            {
                RB.velocity = new Vector2(50.0f * Self.MoveSpeed, 0.0f) * Time.fixedDeltaTime; //move right
            }
            //More movement
            else if (Move.x <= -0.8f)
            {
                RB.velocity = new Vector2(-50.0f * Self.MoveSpeed, 0.0f) * Time.fixedDeltaTime; //move left
            }
            else
            {
                RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;
            }

        //ducking stuff
        //if (Hit == false)
          //  {
            //    Hitstun = false;
            if (Move.y <= -0.6f && !(Move.x >= 0.8f || Move.x <= -0.8f))
            {
                CurrentForm.sprite = Self.CrouchSpr;
                PlayerBox.size = new Vector2(PlayerBox.size.x, Self.PlayerSize.y / 2.0f);
                PlayerBox.offset = new Vector2(PlayerBox.offset.x, Self.PlayerOffset.y - 0.5f);
                
            }
            else
            {
                CurrentForm.sprite = Self.StandSpr;
                PlayerBox.size = new Vector2(PlayerBox.size.x, Self.PlayerSize.y);
                PlayerBox.offset = new Vector2(PlayerBox.offset.x, Self.PlayerOffset.y);
            }
          //  }
    /*    else
            {
                RB.velocity = new Vector2(50.0f * Self.MoveSpeed, 0.0f) * Time.fixedDeltaTime;
                Hitstun = true;
                
                StopCoroutine("PlayStartUpFrames");
                StopCoroutine("PlayHitFrames");
                StopCoroutine("PlayCooldownFrames");
                StopCoroutine("HighAttack");
                StopCoroutine("MedAttack");
                StopCoroutine("LowAttack");
                StopCoroutine("SpecAttack");

            }*/

        }
        //this is a hard code to make sure when you're hit YOOU LOOK LIKE YOU'RE HIT
        if (Hitstun == true)
        {
            CurrentForm.sprite = Self.HitSpr;
        }
        




        //flips the character depending on which side of the screen they are on
        //basically we want everyone to face eachother
        if (Opponent.transform.position.x < gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }



    }
    





    //Coroutines for the different attack types, 
    //I'll only describe the high attack since low and mid attacks are the same as high
    public IEnumerator HighAttack()
    {
        //if the player isn't already attacking
        if (TakingAction == false)
        {
            //they disable their blocks
            HighBlocking = false;
            LowBlocking = false;

            // state that they are attacking    
            TakingAction = true;
            RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime; //freeze their movement


            CurrentAtk = "High"; //label the attack type
            CurrentForm.sprite = Self.HighSprStartUp; //sprite type
            yield return StartCoroutine(PlayStartUpFrames(Self.HighAtkStartUp)); //start up frames

           // if (Hitstun == true)
           // {
           //     Hitstun = false;
           /////     TakingAction = false;
           //     yield break;
           // }
            CurrentForm.sprite = Self.HighSprHit;
            yield return StartCoroutine(PlayHitFrames(Self.HighAtkHit, HighHitBox)); //hit frames
            //if (Hitstun == true)
            //{
            //    Hitstun = false;
            //  //  TakingAction = false;
            //    yield break;
            //}
            CurrentForm.sprite = Self.HighSprStartUp;
            yield return StartCoroutine(PlayCoolDownFrames(Self.HighAtkCoolDown)); //cooldown frames
            //if (Hitstun == true)
            //{
            //    Hitstun = false;
            // //   TakingAction = false;
            //    yield break;
            //}

            TakingAction = false; //attack is done
        }
    }

    public IEnumerator MedAttack()
    {
        if (TakingAction == false)
        {

            HighBlocking = false;
            LowBlocking = false;
            TakingAction = true;
            RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;


            CurrentAtk = "Middle";
            CurrentForm.sprite = Self.MedSprStartUp;
            yield return StartCoroutine(PlayStartUpFrames(Self.MedAtkStartUp));
           // if (Hitstun == true)
           // {
           //     Hitstun = false;
           ////     TakingAction = false;
           //     yield break;
           // }
            CurrentForm.sprite = Self.MedSprHit;
            yield return StartCoroutine(PlayHitFrames(Self.MedAtkHit, MedHitBox));
          //  if (Hitstun == true)
          //  {
          //      Hitstun = false;
          ////      TakingAction = false;
          //      yield break;
          //  }
            CurrentForm.sprite = Self.MedSprStartUp;
            yield return StartCoroutine(PlayCoolDownFrames(Self.MedAtkCoolDown));
            //if (Hitstun == true)
            //{
            //    Hitstun = false;
            ////    TakingAction = false;
            //    yield break;
            //}

            TakingAction = false;
        }
    }

    public IEnumerator LowAttack()
    {

        if (TakingAction == false)
        {
            HighBlocking = false;
            LowBlocking = false;
            TakingAction = true;
            RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;


            CurrentAtk = "Low";
            CurrentForm.sprite = Self.LowSprStartUp;
            yield return StartCoroutine(PlayStartUpFrames(Self.LowAtkStartUp));
           // if (Hitstun == true)
           // {
           //     Hitstun = false;
           ////     TakingAction = false;
           //     yield break;
           // }
            CurrentForm.sprite = Self.LowSprHit;
            yield return StartCoroutine(PlayHitFrames(Self.LowAtkHit, LowHitBox));
           // if (Hitstun == true)
           // {
           //     Hitstun = false;
           ////     TakingAction = false;
           //     yield break;
           // }
            CurrentForm.sprite = Self.LowSprStartUp;
            yield return StartCoroutine(PlayCoolDownFrames(Self.LowAtkCoolDown));
           // if (Hitstun == true)
           // {
           //     Hitstun = false;
           ////     TakingAction = false;
           //     yield break;
           // }

            TakingAction = false;
        }
    }

    //Special attacks are a bit different
    public IEnumerator SpecAttack()
    {
        if (TakingAction == false)
        {

            CurrentAtk = "Special";
            //this is mainly to aim projectiles,
            //the character object and the player dont share positions so we have to do it manually
            Self.transform.position = transform.position;
            Self.transform.localScale = transform.localScale;

            TakingAction = true;
            RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;
            CurrentForm.sprite = Self.SpecSprStartUp;
            yield return StartCoroutine(PlayStartUpFrames(Self.SpecAtkStartUp));
           // if (Hitstun == true)
           // {
           //     Hitstun = false;
           ////     TakingAction = false;
           //     yield break;
           // }
            CurrentForm.sprite = Self.SpecSprHit;
            yield return StartCoroutine(Self.SpecAtk(SpecHitBox)); //call the special attack directly
           // if (Hitstun == true)
           // {
           //     Hitstun = false;
           ////     TakingAction = false;
           //     yield break;
           // }
            CurrentForm.sprite = Self.SpecSprStartUp;
            yield return StartCoroutine(PlayCoolDownFrames(Self.SpecAtkCoolDown));
          //  if (Hitstun == true)
          //  {
          //      Hitstun = false;
          ////      TakingAction = false;
          //      yield break;
          //  }
            TakingAction = false;
           
        }
    }

    public IEnumerator Parry()
    {
        //if you arent doing something else
        if (TakingAction == false)
        {
        TakingAction = true; //now you're doing somethihng

        yield return StartCoroutine(PlayStartUpFrames(3)); //play a few start up frames
        
            //block
        float height = Move.y; //save the position, whether they are ducking or standing
        Vector2 stance = new Vector2(0.0f, height); 
        FrameCountParry = 20; 
        
        //this counts the frames
        while (FrameCountParry > 0)
        {
            //set the current block stance
            RB.velocity = stance; 
            if (height <= -0.6f)
            {
                CurrentForm.sprite = Self.CrouchBlockSpr;
                LowBlocking = true;
                HighBlocking = false;
            }
            else
            {
                CurrentForm.sprite = Self.StandBlockSpr;
                LowBlocking = false;
                HighBlocking = true;
            }
            FrameCountParry--;
            yield return null;
        }


        LowBlocking = false;
        HighBlocking = false;
                
        CurrentForm.sprite = Self.StandSpr;
        yield return StartCoroutine(PlayCoolDownFrames(8));
        TakingAction = false;
        }
        yield return null;

        
    }


    //counts the frames
    IEnumerator PlayStartUpFrames(int Frames)
    {
        HighBlocking = false;
        LowBlocking = false;
        //copy the frames so we don't actually change the character
        int FrameCount = Frames;

        //this counts the frames
        while (FrameCount > 0)
        {

            FrameCount--;
            yield return null;
        }

        yield return null;
    }

    //counts more frames
    IEnumerator PlayHitFrames(int Frames, BoxCollider2D HitBox)
    {
        HitBox.enabled = true; //enables hitbox

        int FrameCount = Frames;
        while (FrameCount > 0)
        {
            FrameCount--;
            yield return null;
        }
        HitBox.enabled = false;
        yield return null;
    }


    IEnumerator PlayCoolDownFrames(int Frames)
    {
        int FrameCount = Frames;
        while (FrameCount > 0)
        {
            FrameCount--;
            yield return null;
        }
        yield return null;
    }

    //The player is a collider and cant activate triggers, so this is only for attacks
    void OnTriggerEnter2D(Collider2D col)
    {

    HighHitBox.enabled = false;
    MedHitBox.enabled = false;
    LowHitBox.enabled = false;
    SpecHitBox.enabled = false;

    //this is mainly for the particles
    Vector2 v = new Vector2(0.0f, 0.0f);
    Vector3 rot = transform.rotation.eulerAngles;
    rot = new Vector3(rot.x, rot.y, rot.z + (-90 * transform.localScale.x));


        //only activates if the object his is the opponent and not a projectile or another punch
        //remember all attacks are triggers, hence the !col.isTrigger
        if (col.tag == opponentTag && !col.isTrigger)
        {

            //Checks whatever attack the player is doing and compares it the whatever block the opponent is doing
            //As far as I know my logic here is solid, but it isn't too hard to change
            if (CurrentAtk == "High")
            {
                v = new Vector2(col.bounds.center.x + (col.bounds.size.x/2 * transform.localScale.x * -1.0f), HighHitBox.bounds.center.y);
               
                if (Opponent.HighBlocking == true)
                {
                    StartCoroutine(Blocking(Opponent.Self.StandBlockSpr, Self.HighBlockStun));
                    GameObject firework = Instantiate(GM.BlockEffect, v, Quaternion.Euler(rot));
                    StartCoroutine(KnockBack(0.1f, Self.HighAttackerBlockPush, Self.HighDefenderBlockPush));
                    
                }
                else
                {
                    Explode(v);
                    StartCoroutine(Opponent.TakeDamage(Self.HighAttackerHitPush,Self.HighDefenderHitPush));
                    
                    
                }
            }
            else if (CurrentAtk == "Middle")
            {
                v = new Vector2(col.bounds.center.x + (col.bounds.size.x/2 * transform.localScale.x * -1.0f), MedHitBox.bounds.center.y);

                

                if (Opponent.HighBlocking == true)
                {
                    StartCoroutine(Blocking(Opponent.Self.StandBlockSpr, Self.MedBlockStun));
                    GameObject firework = Instantiate(GM.BlockEffect, v, Quaternion.Euler(rot));
                    StartCoroutine(KnockBack(0.1f, Self.MedAttackerBlockPush, Self.MedDefenderBlockPush));
                    
                }
                
                else
                {
                    Explode(v);
                    StartCoroutine(Opponent.TakeDamage(Self.MedAttackerHitPush, Self.MedDefenderHitPush));
              
                }

            }
            else if (CurrentAtk == "Low")
            {

                v = new Vector2(col.bounds.center.x + (col.bounds.size.x/2 * transform.localScale.x * -1.0f), LowHitBox.bounds.center.y);




                if (Opponent.LowBlocking == true)
                {
                    StartCoroutine(Blocking(Opponent.Self.CrouchBlockSpr, Self.LowBlockStun));
                    GameObject firework = Instantiate(GM.BlockEffect, v, Quaternion.Euler(rot));
                    StartCoroutine(KnockBack(0.1f, Self.LowAttackerBlockPush, Self.LowDefenderBlockPush));

                }
                else
                {

                    StartCoroutine(Opponent.TakeDamage(Self.LowAttackerHitPush, Self.LowDefenderHitPush));
                    Explode(v);

                }
            }
            //okay the special is a bit different since we have to seperatle label it, basically we redo everything from before but in the special if statement
            else if (CurrentAtk == "Special")
            {
                v = new Vector2(col.bounds.center.x + (col.bounds.size.x / 2 * transform.localScale.x * -1.0f), SpecHitBox.bounds.center.y);
                if (Self.SpecialStr == "High")
                {
                    if (Opponent.HighBlocking == true)
                    {
                        StartCoroutine(Blocking(Opponent.Self.StandBlockSpr,Self.SpecBlockStun));
                        GameObject firework = Instantiate(GM.BlockEffect, v, Quaternion.Euler(rot));
                        StartCoroutine(KnockBack(0.1f, Self.SpecAttackerBlockPush, Self.SpecDefenderBlockPush));
                    }
                    else
                    {

                        StartCoroutine(Opponent.TakeDamage(Self.SpecAttackerHitPush, Self.SpecDefenderHitPush));
                        Explode(v);

                    }
                }
                else if (Self.SpecialStr == "Middle")
                {
                    if (Opponent.HighBlocking == true)
                    {
                        StartCoroutine(Blocking(Opponent.Self.StandBlockSpr, Self.SpecBlockStun));
                        GameObject firework = Instantiate(GM.BlockEffect, v, Quaternion.Euler(rot));
                        StartCoroutine(KnockBack(0.1f, Self.SpecAttackerBlockPush, Self.SpecDefenderBlockPush));

                    }
                    else
                    {

                        StartCoroutine(Opponent.TakeDamage(Self.SpecAttackerHitPush, Self.SpecDefenderHitPush));
                        Explode(v);

                    }
                }
                else if (Self.SpecialStr == "Low")
                {
                    if (Opponent.LowBlocking == true)
                    {
                        StartCoroutine(Blocking(Opponent.Self.CrouchBlockSpr, Self.SpecBlockStun));
                        GameObject firework = Instantiate(GM.BlockEffect, v, Quaternion.Euler(rot));
                        StartCoroutine(KnockBack(0.1f, Self.SpecAttackerBlockPush, Self.SpecDefenderBlockPush));
                    }
                    else
                    {

                        StartCoroutine(Opponent.TakeDamage(Self.SpecAttackerHitPush, Self.SpecDefenderHitPush));
                        Explode(v);
                    }
                }
                else
                {

                    StartCoroutine(Opponent.TakeDamage(Self.SpecAttackerHitPush, Self.SpecDefenderHitPush));
                    Explode(v);
                }
            }

            ///////////////////


        }
        
    }

    //since special attacks handle things differently
    //it would be easier to create a takedamage function
    //instead of a deal damage function

    //When you take damage you are put into hitstun
    public IEnumerator TakeDamage(float AttackerPush, float DefenderPush)
    {
        Hitstun = true; //you are in hitstun
//        TakingAction = true;
  //      Opponent.TakingAction = true;
        
        Health -= 1;
        FindObjectOfType<HealthDisplay>().ChangeHealth(gameObject.tag);

//        Hit = true; //when hit is on the player cant move
        StartCoroutine(IFrames(60));
        yield return StartCoroutine(HitAnimation(AttackerPush,DefenderPush));
        
        //check if we died
        if (Health == 0)
        {
            GameObject DeathSplooge = Instantiate(GM.DeathEffect, transform.position, Quaternion.identity);
            StartCoroutine(KillChar());
            StartCoroutine(GO.PlayerDies(opponentTag));
        }

        yield return null;

        
//        TakingAction = false;
  //      Opponent.TakingAction = false;

    }

    IEnumerator KillChar()
    {
      
        Aura.SetActive(false);
        var tempColor = CurrentForm.color;
        yield return new WaitForSeconds(0.05f);
        while (tempColor.a > 0.0)
        {
            RB.velocity = Vector2.zero; 
            tempColor.a -= 0.05f;
            CurrentForm.color = tempColor;
            yield return null;
        }
        yield return null;
    }
    public IEnumerator IFrames(int f)
    {
        
        CurrentForm.enabled = false;
        gameObject.layer = 10;
        int t = 0;
        while (t < f)
        {
            CurrentForm.enabled = !CurrentForm.enabled;
            t += 1;
            yield return null;// new WaitForSeconds(0.05f);
            
        }
        CurrentForm.enabled = true;
        gameObject.layer = 8;
        yield return null;
    }
    

    void Explode(Vector2 position)
    {
        GameObject firework = Instantiate(GM.HitEffect, position, Quaternion.identity);
       // firework.GetComponent<ParticleSystem>().Play();
    }





    //shouldnt have to swap any variables, just slowdown things and knock people back
    IEnumerator HitAnimation(float AttackerPush, float DefenderPush)
    {
  //      TakingAction = true;
    //    Opponent.TakingAction = true;
        
        CurrentForm.sprite = Self.HitSpr;
       
        //stop both players from moving
        Opponent.RB.velocity = new Vector2(0.0f, 0.0f);
        RB.velocity = new Vector2(0.0f, 0.0f);

        //send both players flying away from eachother
        StartCoroutine(KnockBack(0.1f,AttackerPush,DefenderPush));
       
        AM.Play("HitSound2Reverse");
        yield return StartCoroutine(SlowDown()); //important that the knockback starts before the slowdown
        
        //keep the animation in line with the knockback, they'll end at the same time now
        while (Hitstun == true)
        {
            yield return null;
        }

        yield return null;
    }

    //this is what actually pushes people back
    IEnumerator KnockBack(float time, float AttackerPush, float DefenderPush)
    {


        //basically check that they aren't already being pushed back for other reasons
        //adding forces together get's weird
        if (KnockingBack == false)
        {
            KnockingBack = true;
            while (time > 0.0f)
            {
                
            
                RB.velocity = AttackerPush  * transform.localScale * -1.0f;
                Opponent.RB.velocity = DefenderPush * Opponent.transform.localScale * -1.0f;
                time -= Time.deltaTime;
                yield return null;

            }
            KnockingBack = false;
            Hitstun = false;
            yield return null;
        }

  
        yield return null;

    }

    //okay this is confusing, this affects the defender but is called from the attacker, trust me it works better this way
    public IEnumerator Blocking(Sprite BlockSpr, int BlockStun)
    {

        AM.Play("BlockSound");

        Opponent.CurrentForm.sprite = BlockSpr;
        Opponent.TakingAction = true;
        BlockTime = BlockStun;   //dont actually change the passed in variable, copy it


    //    if (CurrentBlocking == false)
      //  {

            
            Opponent.FrameCountParry = 0;
//            int IF = BlockTime;
            //StartCoroutine(Opponent.IFrames(IF));
            while (BlockTime > 0)
            {
                //TakingAction = true;
                //Opponent.TakingAction = true;
                Opponent.IsBlocking = true;
             //   Opponent.CurrentForm.sprite = BlockSpr;
                BlockTime -= 1;
                yield return null;
            }
           // HighBlocking = false;
           // LowBlocking = false;
        Opponent.IsBlocking = false;
        //            CurrentBlocking = false;

        //      }
        //   AM.SetVolume("SpectrumTheme", 0.25f);

        yield return null;
    }





    //this is the only function I know works perfectly
    IEnumerator SlowDown()
    {

       // TakingAction = true;
       // Opponent.TakingAction = true;
        float Vert =  cam.transform.position.y - 2f;
        
        if (Time.timeScale >= 1.0f)
        {

            Time.timeScale = 0.005f;
            Time.fixedDeltaTime = 0.005f * 0.02f;

            if (Time.timeScale < 1.0f)
            {
                //AM.Play("HitSound");
                AM.Play("HitSound2");
                StartCoroutine(MoveCamera(1.75f));
                while (cam.orthographicSize > 3.0f)
                {
                    AM.SetVolume("SpectrumTheme", AM.GetVolume("SpectrumTheme") - 0.025f);
                    ////if (cam.transform.position.y > Vert)
                    ////{
                    ////    cam.transform.position += new Vector3(0.0f, -0.2f, 0.0f);
                    ////}


              //      TakingAction = true;
         //           Opponent.TakingAction = true;
                    cam.orthographicSize -= 0.5f;
                    yield return null;
                }


                cam.orthographicSize = 3.0f;
                yield return new WaitForSeconds(0.0025f);
                
                StartCoroutine(MoveCamera(-1.75f));
                while (cam.orthographicSize < OriginalSize)
                {
                    AM.SetVolume("SpectrumTheme", AM.GetVolume("SpectrumTheme") + 0.025f);


         //           TakingAction = true;
           //         Opponent.TakingAction = true;
                    cam.orthographicSize += 0.5f;
                    yield return null;
                }
                AM.SetVolume("SpectrumTheme", 0.3f);
                cam.orthographicSize = OriginalSize;

                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 1.0f * 0.02f;
                //cam.orthographicSize = 10.0f;

          //      TakingAction = false;
           //     Opponent.TakingAction = false;
            }
        }


        yield return null;
    }

    //this is how I keep the camera centered on the players, partly
    IEnumerator MoveCamera(float Distance)
    {
        if (Distance >= 0.0)
        {
            while (Distance >= 0.0f)
            {

                cam.transform.position += new Vector3(0.0f, -0.5f, 0.0f);
                Distance -= 0.5f;
                yield return null;
            }
        }
        else
        {
            while (Distance <= 0.0f)
            {

                cam.transform.position += new Vector3(0.0f, 0.5f, 0.0f);
                Distance += 0.5f;
                yield return null;
            }
        }


        yield return null;


    }

    //this and the next one I use to stop the players from doing stuff while announcements play
    public IEnumerator Freeze()
    {
            while (true)
        {
            TakingAction = true;
            yield return null;
        }

    }
    public IEnumerator UnFreeze()
    {

        TakingAction = false;
        yield return null;

    }

    //this aint working yet
    public IEnumerator Pause()
    {
        /////
        ///
        PM.isPaused = !PM.isPaused;
        Debug.Log("Pause");
        yield return null;
    }

    //This ended up not being needed but it's here anyway
    public IEnumerator KnockBackSelf(float pushtime)
    {
        float t = pushtime;

        RB.AddForce(pushtime * transform.localScale * -1.0f); //this didnt work how I wanted

        //while (t > 0.0f)
        //{
        //    RB.velocity = 10.0f * transform.localScale * -1.0f;
        //    t -= Time.deltaTime;
        //    yield return null;
        //}


        yield return null;
    }

    //see the above coroutine
    IEnumerator MiniSlowdown()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = 0.1f * 0.02f;
        yield return new WaitForSeconds(0.010f);
        yield return new WaitForSeconds(0.010f);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 1.0f * 0.02f;
    }
}
