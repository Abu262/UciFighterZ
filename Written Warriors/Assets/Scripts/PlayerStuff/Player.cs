using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

//JESSE ALLAS
//Last Updated: 10/1/2019

//This is all the controls and stuff for the player
//designers probably won' have to touch this, 

//Keep in mind that all coordinates are relative to the object, so you dont need to worry about characters switching sides

public abstract class Player : MonoBehaviour
{

    public Camera cam;
    public bool IsP1 = false;
//    public string Path = FindObjectOfType<GameManager>().ReturnPath();
   // public Text HP; //Temporary, displays the current HP
    public int Health; //Since the health value changes we want to copy the character health stat
    public PlayerControls Controls; //Player Controls
    
    public Character Self; //the character we're getting all the stats from

    public Player Opponent; //the opponent player object
    public string opponentTag; //The opponent tag, for checking collisions 

    bool TakingAction = true;     //a bool to prvent the player from interupting their moves

    public Vector2 Move;    //vector to move the player

    //the hitboxes for the different attacks
    public BoxCollider2D HighHitBox;
    public BoxCollider2D MedHitBox;
    public BoxCollider2D LowHitBox;
    public BoxCollider2D SpecHitBox;
    public BoxCollider2D PlayerBox;

    //RigidBody because physics dont work if we dont
    public Rigidbody2D RB;

    //bools to check if the player is blocking
    public bool HighBlocking;
    public bool LowBlocking;
    
    public bool Hit; //true when the player is hit

    string CurrentAtk; //the string titling the current move

    private int BlockTime;
    public bool CurrentBlocking = false;
    public int FrameCountParry;


    public SpriteRenderer CurrentForm;
    public GameOver GO;

    [HideInInspector]
    public int Charges; //this is a quickfix for thornton's special, I'll fix it later
    private bool Hitstun = false;
    private bool KnockingBack = false;
    private AudioManager AM;
    float OriginalSize;// = cam.orthographicSize;
    private GameManager GM;
    public GameObject Aura;
    //music cut, sound e plays

    //block e should explode towards blocker DONE

    //flashier block (lower music for short period)


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
        Hit = false;
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


        if (TakingAction == false)
        {
            //Move changes when the player waggles the analog stick
            //Move.x controls left and right movement
            if (Move.x >= 0.8f)
            {

                RB.velocity = new Vector2(50.0f * Self.MoveSpeed, 0.0f) * Time.fixedDeltaTime;
               
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
            else if (Move.x <= -0.8f)
            {

                RB.velocity = new Vector2(-50.0f * Self.MoveSpeed, 0.0f) * Time.fixedDeltaTime;

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
                RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;
               // HighBlocking = true;
            }

        //ducking stuff
        if (Hit == false)
            {
                Hitstun = false;
                if (Move.y <= -0.6f && !(Move.x >= 0.8f || Move.x <= -0.8f))
                {
                    CurrentForm.sprite = Self.CrouchSpr;
                    PlayerBox.size = new Vector2(PlayerBox.size.x, Self.PlayerSize.y / 2.0f);
                    PlayerBox.offset = new Vector2(PlayerBox.offset.x, Self.PlayerOffset.y - 0.5f);
                    //LowBlocking = true;
                    //HighBlocking = false;
                }
                else
                {
                    CurrentForm.sprite = Self.StandSpr;
                    PlayerBox.size = new Vector2(PlayerBox.size.x, Self.PlayerSize.y);
                    PlayerBox.offset = new Vector2(PlayerBox.offset.x, Self.PlayerOffset.y);
                //    LowBlocking = false;

                }
            }
        else
            {
                RB.velocity = new Vector2(50.0f * Self.MoveSpeed, 0.0f) * Time.fixedDeltaTime;
                Hitstun = true;
                CurrentForm.sprite = Self.HitSpr;
                StopCoroutine("PlayStartUpFrames");
                StopCoroutine("PlayHitFrames");
                StopCoroutine("PlayCooldownFrames");
                StopCoroutine("HighAttack");
                StopCoroutine("MedAttack");
                StopCoroutine("LowAttack");
                StopCoroutine("SpecAttack");

            }

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

        if (Hit == true)
        {
//            TakingAction = true;
            //RB.velocity = new Vector2(0.0f, 0.0f);
        }

    }
    





    //Coroutines for the different attack types, 
    //I'll only describe the high attack since low and mid attacks are the same as high

    public IEnumerator HighAttack()
    {

        //if the player isn't already attacking
        if (TakingAction == false)
        {

            HighBlocking = false;
            LowBlocking = false;
            // state that they are attacking    
            TakingAction = true;
            RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;


            CurrentAtk = "High";
            CurrentForm.sprite = Self.HighSprStartUp;
            yield return StartCoroutine(PlayStartUpFrames(Self.HighAtkStartUp)); //start up frames
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            CurrentForm.sprite = Self.HighSprHit;
            yield return StartCoroutine(PlayHitFrames(Self.HighAtkHit, HighHitBox)); //hit frames
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            CurrentForm.sprite = Self.HighSprStartUp;
            yield return StartCoroutine(PlayCoolDownFrames(Self.HighAtkCoolDown)); //cooldown frames
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }

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
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            CurrentForm.sprite = Self.MedSprHit;
            yield return StartCoroutine(PlayHitFrames(Self.MedAtkHit, MedHitBox));
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            CurrentForm.sprite = Self.MedSprStartUp;
            yield return StartCoroutine(PlayCoolDownFrames(Self.MedAtkCoolDown));
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }

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
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            CurrentForm.sprite = Self.LowSprHit;
            yield return StartCoroutine(PlayHitFrames(Self.LowAtkHit, LowHitBox));
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            CurrentForm.sprite = Self.LowSprStartUp;
            yield return StartCoroutine(PlayCoolDownFrames(Self.LowAtkCoolDown));
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }

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
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            CurrentForm.sprite = Self.SpecSprHit;
            yield return StartCoroutine(Self.SpecAtk(SpecHitBox)); //call the special attack directly
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            CurrentForm.sprite = Self.SpecSprStartUp;
            yield return StartCoroutine(PlayCoolDownFrames(Self.SpecAtkCoolDown));
            if (Hitstun == true)
            {
                Hitstun = false;
                TakingAction = false;
                yield break;
            }
            TakingAction = false;
           
        }
    }

    public IEnumerator Parry()
    {
        if (TakingAction == false)
        {
                    TakingAction = true;
        yield return StartCoroutine(PlayStartUpFrames(3));
        //block
        float height = Move.y;
        Vector2 stance = new Vector2(0.0f, height);
        FrameCountParry = 20;
        
        //this counts the frames
        while (FrameCountParry > 0)
        {
                Debug.Log(FrameCountParry);
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

        if (CurrentBlocking == false)
            {
                LowBlocking = false;
                HighBlocking = false;

            }
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
                    //                    KnockBackSelf(Self.HighAttackerBlockPush);
                    //                  Opponent.KnockBackSelf(Self.HighDefenderBlockPush);
                  //  Debug.Log("BLOCK");
                }
                else
                {
                    Explode(v);
                    Opponent.TakeDamage(Self.HighAttackerHitPush,Self.HighDefenderHitPush);
                    //Debug.Log("HIT");
                    
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
                    //                    KnockBackSelf(Self.MedAttackerBlockPush);
                    //                  Opponent.KnockBackSelf(Self.MedDefenderBlockPush);
                    //Debug.Log("BLOCK");
                }
                
                else
                {
                    Explode(v);
                    Opponent.TakeDamage(Self.MedAttackerHitPush, Self.MedDefenderHitPush);
                    //Debug.Log("HIT");
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
                 //   KnockBackSelf(Self.LowAttackerBlockPush);
                   // Opponent.KnockBackSelf(Self.LowDefenderBlockPush);
                    //Debug.Log("BLOCK");
                }
                else
                {

                    Opponent.TakeDamage(Self.LowAttackerHitPush, Self.LowDefenderHitPush);
                    Explode(v);
                    //Debug.Log("HIT");
                }
            }
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
                        //   KnockBackSelf(Self.LowAttackerBlockPush);
                        // Opponent.KnockBackSelf(Self.LowDefenderBlockPush);
                    //    Debug.Log("BLOCK");
                    }
                    else
                    {

                        Opponent.TakeDamage(Self.SpecAttackerHitPush, Self.SpecDefenderHitPush);
                        Explode(v);
                    //    Debug.Log("HIT");
                    }
                }
                else if (Self.SpecialStr == "Middle")
                {
                    if (Opponent.HighBlocking == true)
                    {
                        StartCoroutine(Blocking(Opponent.Self.StandBlockSpr, Self.SpecBlockStun));
                        GameObject firework = Instantiate(GM.BlockEffect, v, Quaternion.Euler(rot));
                        StartCoroutine(KnockBack(0.1f, Self.SpecAttackerBlockPush, Self.SpecDefenderBlockPush));
                        //   KnockBackSelf(Self.LowAttackerBlockPush);
                        // Opponent.KnockBackSelf(Self.LowDefenderBlockPush);
                    //    Debug.Log("BLOCK");
                    }
                    else
                    {

                        Opponent.TakeDamage(Self.SpecAttackerHitPush, Self.SpecDefenderHitPush);
                        Explode(v);
                    //    Debug.Log("HIT");
                    }
                }
                else if (Self.SpecialStr == "Low")
                {
                    if (Opponent.LowBlocking == true)
                    {
                        StartCoroutine(Blocking(Opponent.Self.CrouchBlockSpr, Self.SpecBlockStun));
                        GameObject firework = Instantiate(GM.BlockEffect, v, Quaternion.Euler(rot));
                        StartCoroutine(KnockBack(0.1f, Self.SpecAttackerBlockPush, Self.SpecDefenderBlockPush));
                        //   KnockBackSelf(Self.LowAttackerBlockPush);
                        // Opponent.KnockBackSelf(Self.LowDefenderBlockPush);
                    //    Debug.Log("BLOCK");
                    }
                    else
                    {

                        Opponent.TakeDamage(Self.SpecAttackerHitPush, Self.SpecDefenderHitPush);
                        Explode(v);
                     //   Debug.Log("HIT");
                    }
                }
                else
                {

                    Opponent.TakeDamage(Self.SpecAttackerHitPush, Self.SpecDefenderHitPush);
                    Explode(v);
                   // Debug.Log("HIT");
                }
            }

            ///////////////////


        }
        
    }

    //since special attacks handle things differently
    //it would be easier to create a takedamage function
    //instead of a deal damage function

    //anyway this function causes the player to take damage
    public void TakeDamage(float AttackerPush, float DefenderPush)
    {
      
        TakingAction = true;
        Opponent.TakingAction = true;
        //I want to impliment a slowdown/zoom in effect when someone gets hit
        //but it isn't necessary
        
        //   FindObjectOfType<AudioManager>().Play("Hit");
        Health -= 1;
        FindObjectOfType<HealthDisplay>().ChangeHealth(gameObject.tag);
       // HP.text = Health.ToString();
        Hit = true; //when hit is on the player cant move
        StartCoroutine(IFrames());
        StartCoroutine(HitAnimation(AttackerPush,DefenderPush));
        if (Health == 0)
        {
            CurrentForm.color = new Color(1f, 1f, 1f, 0f);
            Aura.SetActive(false);
            StartCoroutine(GO.PlayerDies(opponentTag));
        }
//        if (Health == 1)
  //      {
    //        StartCoroutine(Self.RageMode());

      //  }

 
        TakingAction = false;
        Opponent.TakingAction = false;

    }

    IEnumerator IFrames()
    {
        
        CurrentForm.enabled = false;
        gameObject.layer = 10;
        int t = 0;
        while (t <= 10)
        {
            CurrentForm.enabled = !CurrentForm.enabled;
            t += 1;
            yield return new WaitForSeconds(0.05f);
            
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



    //I seperated this from the take damage because coroutines do things in the order I list them
    //functions tend to be less controlled

    //this function isnt working quite how I want it to but it works well enough right now
    IEnumerator HitAnimation(float AttackerPush, float DefenderPush)
    {
        TakingAction = true;
        Opponent.TakingAction = true;
        
        CurrentForm.sprite = Self.HitSpr;
        //stop both players from moving
        Opponent.RB.velocity = new Vector2(0.0f, 0.0f);
        RB.velocity = new Vector2(0.0f, 0.0f);

        //send both players flying away from eachother
        StartCoroutine(KnockBack(0.3f,AttackerPush,DefenderPush));
       // AM.Play("HitSoundReverse");
        AM.Play("HitSound2Reverse");
        yield return StartCoroutine(SlowDown());
        //we send them flying for about a minute
        TakingAction = false;
        Opponent.TakingAction = false;


        Hit = false; //allow player to move now
        TakingAction = false;
        Opponent.TakingAction = false;
        yield return null;
    }

    IEnumerator KnockBack(float time, float AttackerPush, float DefenderPush)
    {
        TakingAction = true;
        Opponent.TakingAction = true;
        if (KnockingBack == false)
        {
            KnockingBack = true;
            while (time > 0.0f)
            {
                TakingAction = true;
                Opponent.TakingAction = true;
                RB.velocity = AttackerPush * transform.localScale * -1.0f;
                Opponent.RB.velocity = DefenderPush * Opponent.transform.localScale * -1.0f;
                time -= Time.deltaTime;
                yield return null;

            }
            KnockingBack = false;
            yield return null;
        }
        TakingAction = false;
        Opponent.TakingAction = false;
        yield return null;

    }

    public IEnumerator Blocking(Sprite BlockSpr, int BlockStun)
    {
//        AM.SetVolume("SpectrumTheme", 0.1f);
        AM.Play("BlockSound");
        //StartCoroutine(MiniSlowdown());
        Opponent.CurrentForm.sprite = BlockSpr;
        Opponent.TakingAction = true;
        BlockTime = BlockStun;


        if (CurrentBlocking == false)
        {

            Opponent.TakingAction = true;
            Opponent.FrameCountParry = 0;
            

            while (BlockTime > 0)
            {
                TakingAction = true;
                Opponent.TakingAction = true;
             //   Opponent.CurrentForm.sprite = BlockSpr;
                BlockTime -= 1;
                yield return null;
            }
            HighBlocking = false;
            LowBlocking = false;
            TakingAction = false;
            Opponent.TakingAction = false;
            CurrentBlocking = false;

        }
     //   AM.SetVolume("SpectrumTheme", 0.25f);

        yield return null;
    }

    public IEnumerator KnockBackSelf(float pushtime)
    {
        float t = pushtime;

        RB.AddForce(pushtime * transform.localScale * -1.0f);

        //while (t > 0.0f)
        //{
        //    RB.velocity = 10.0f * transform.localScale * -1.0f;
        //    t -= Time.deltaTime;
        //    yield return null;
        //}


        yield return null;
    }


    IEnumerator MiniSlowdown()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = 0.1f * 0.02f;
        yield return new WaitForSeconds(0.010f);
        yield return new WaitForSeconds(0.010f);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 1.0f * 0.02f;
    }

    IEnumerator SlowDown()
    {

        TakingAction = true;
        Opponent.TakingAction = true;
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


                    TakingAction = true;
                    Opponent.TakingAction = true;
                    cam.orthographicSize -= 0.5f;
                    yield return null;
                }


                cam.orthographicSize = 3.0f;
                yield return new WaitForSeconds(0.0025f);
                
                StartCoroutine(MoveCamera(-1.75f));
                while (cam.orthographicSize < OriginalSize)
                {
                    AM.SetVolume("SpectrumTheme", AM.GetVolume("SpectrumTheme") + 0.025f);


                    TakingAction = true;
                    Opponent.TakingAction = true;
                    cam.orthographicSize += 0.5f;
                    yield return null;
                }
                AM.SetVolume("SpectrumTheme", 0.3f);
                cam.orthographicSize = OriginalSize;

                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 1.0f * 0.02f;
                //cam.orthographicSize = 10.0f;

                TakingAction = false;
                Opponent.TakingAction = false;
            }
        }


        yield return null;
    }

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
}
