using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

//JESSE ALLAS
//Last Updated: 10/1/2019

//This is all the controls and stuff for the player
//designers probably won' have to touch this, 
//if anyone programmmers might need to tweak some things,
//but odds are nobody will have to

public abstract class Player : MonoBehaviour
{

    public bool IsP1 = false;
//    public string Path = FindObjectOfType<GameManager>().ReturnPath();
    public Text HP; //Temporary, displays the current HP
    public int Health; //Since the health value changes we want to copy the character health stat
    public PlayerControls Controls; //Player Controls
    
    public Character Self; //the character we're getting all the stats from

    public Player Opponent; //the opponent player object
    public string opponentTag; //The opponent tag, for checking collisions 

    bool TakingAction = false;     //a bool to prvent the player from interupting their moves

    public Vector2 Move;    //vector to move the player

    //the hitboxes for the different attacks
    public BoxCollider2D HighHitBox;
    public BoxCollider2D MedHitBox;
    public BoxCollider2D LowHitBox;
    public BoxCollider2D PlayerBox;

    //RigidBody because physics dont work if we dont
    public Rigidbody2D RB;

    //bools to check if the player is blocking
    public bool HighBlocking;
    public bool LowBlocking;
    
    public bool Hit; //true when the player is hit

    string CurrentAtk; //the string titling the current move
//    bool ready = false;
    private void Start()
    {

        PlayerBox.size = new Vector2(Self.PlayerSize.x, Self.PlayerSize.y);
        PlayerBox.offset = new Vector2(Self.PlayerOffset.x, Self.PlayerOffset.y);

        Self.transform.position = transform.position;

        gameObject.GetComponent<SpriteRenderer>().sprite = Self.PlayerImage;
        //setting some initial things
        Hit = false;
        Health = Self.Health;
        HP.text = Health.ToString();
        HighBlocking = false;
        LowBlocking = false;
        RB = gameObject.GetComponent<Rigidbody2D>();
        HighHitBox.offset = Self.HighHitBoxOffset;
        MedHitBox.offset = Self.MedHitBoxOffset;
        LowHitBox.offset = Self.LowHitBoxOffset;

        HighHitBox.size = Self.HighHitBoxSize;
        MedHitBox.size = Self.MedHitBoxSize;
        LowHitBox.size = Self.LowHitBoxSize;
      //  ready = true;
    }

    private void Awake()
    {
        // if (IsP1)
        //{
        //Debug.Log("heelo");

       // }
       // else
       // {
         //   Debug.Log("heelo");
          //  Self = Resources.Load<Character>(FindObjectOfType<GameManager>().PathP2);
       // }

        //         StartCoroutine(CreateChar());
        //grabbing some more things that we want to get before the start

        //The Idea is that there will be a character select menu that sets this later



        ///////////
        //FOR THE LOVE OF GOD PUT YOUR CHARACTER PREFABS IN THE RESOURCES FOLDER
        //////////



    }


    void Update()
    {
        
        if (TakingAction == false)
        {
            //Move changes when the player waggles the analog stick
            //Move.x controls left and right movement
            if (Move.x >= 0.8f)
            {

                RB.velocity = new Vector2(50.0f * Self.MoveSpeed, 0.0f) * Time.fixedDeltaTime;
               
                //change blocking bool if the player is walking or not
                if (transform.localScale.x >=0.0f)
                {
                    HighBlocking = false;
                }
                else
                {
                    HighBlocking = true;
                }

            }
            //More movement
            else if (Move.x <= -0.8f)
            {

                RB.velocity = new Vector2(-50.0f * Self.MoveSpeed, 0.0f) * Time.fixedDeltaTime;

                if (transform.localScale.x <= 0.0f)
                {
                    HighBlocking = false;
                }
                else
                {
                    HighBlocking = true;
                }
            }
            else
            {
                RB.velocity = new Vector2(0.0f, 0.0f) * Time.fixedDeltaTime;
                HighBlocking = true;
            }

        //ducking stuff
        if (Move.y <= -0.6f && !(Move.x >= 0.8f || Move.x <= -0.8f))
            {
                PlayerBox.size = new Vector2(PlayerBox.size.x, Self.PlayerSize.y/2.0f);
                PlayerBox.offset = new Vector2(PlayerBox.offset.x, Self.PlayerOffset.y - 0.5f);
                LowBlocking = true;
                HighBlocking = false;
            }
        else
            {
                PlayerBox.size = new Vector2(PlayerBox.size.x, Self.PlayerSize.y);
                PlayerBox.offset = new Vector2(PlayerBox.offset.x, Self.PlayerOffset.y);
                LowBlocking = false;
              
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
            RB.velocity = new Vector2(0.0f, 0.0f);
        }

    }


    void OnEnable()
    {
        Controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        Controls.Gameplay.Disable();
    }



    //Coroutines for the different attack types, 
    //I'll only describe the high attack since low and mid attacks are the same as high

    public IEnumerator HighAttack()
    {

        //if the player isn't already attacking
        if (TakingAction == false)
        {
            // state that they are attacking    
            TakingAction = true;
            CurrentAtk = "High";
            yield return StartCoroutine(PlayStartUpFrames(Self.HighAtkStartUp)); //start up frames
            yield return StartCoroutine(PlayHitFrames(Self.HighAtkHit, HighHitBox)); //hit frames
            yield return StartCoroutine(PlayCoolDownFrames(Self.HighAtkCoolDown)); //cooldown frames


            TakingAction = false; //attack is done
        }
    }

    public IEnumerator MedAttack()
    {
        if (TakingAction == false)
        {
            TakingAction = true;
            CurrentAtk = "Middle";
            yield return StartCoroutine(PlayStartUpFrames(Self.MedAtkStartUp));
            yield return StartCoroutine(PlayHitFrames(Self.MedAtkHit, MedHitBox));
            yield return StartCoroutine(PlayCoolDownFrames(Self.MedAtkCoolDown));


            TakingAction = false;
        }
    }

    public IEnumerator LowAttack()
    {
        if (TakingAction == false)
        {
            TakingAction = true;
            CurrentAtk = "Low";
            yield return StartCoroutine(PlayStartUpFrames(Self.LowAtkStartUp));
            yield return StartCoroutine(PlayHitFrames(Self.LowAtkHit, LowHitBox));
            yield return StartCoroutine(PlayCoolDownFrames(Self.LowAtkCoolDown));


            TakingAction = false;
        }
    }

    //Special attacks are a bit different
    public IEnumerator SpecAttack()
    {
        if (TakingAction == false)
        {
            CurrentAtk = Self.SpecialStr;
            //this is mainly to aim projectiles,
            //the character object and the player dont share positions so we have to do it manually
            Self.transform.position = transform.position;
            Self.transform.localScale = transform.localScale;

            TakingAction = true;

            yield return StartCoroutine(PlayStartUpFrames(Self.SpecAtkStartUp));
            yield return StartCoroutine(Self.SpecAtk()); //call the special attack directly
            yield return StartCoroutine(PlayCoolDownFrames(Self.SpecAtkCoolDown));
            TakingAction = false;
        }
    }

    //counts the frames
    IEnumerator PlayStartUpFrames(int Frames)
    {
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

    //I dont actually need this, I could just reuse the startup frames coroutine
    //but naming the two seperately makes it easier to read
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
        //only activates if the object his is the opponent and not a projectile or another punch
        //remember all attacks are triggers, hence the !col.isTrigger
        if (col.tag == opponentTag && !col.isTrigger)
        {

            //Checks whatever attack the player is doing and compares it the whatever block the opponent is doing
            //As far as I know my logic here is solid, but it isn't too hard to change
            if (CurrentAtk == "High")
            {
                if (Opponent.HighBlocking == true)
                {
                    Debug.Log("BLOCK");
                }
                else
                {
                    Opponent.TakeDamage();
                    Debug.Log("HIT");
                }
            }
            else if (CurrentAtk == "Middle")
            {
                if (Opponent.HighBlocking == true)
                {
                    Debug.Log("BLOCK");
                }
                
                else
                {

                    Opponent.TakeDamage();
                    Debug.Log("HIT");
                }

            }
            else if (CurrentAtk == "Low")
            {
                if (Opponent.LowBlocking == true)
                {
                    Debug.Log("BLOCK");
                }
                else
                {
                    Opponent.TakeDamage();
                    Debug.Log("HIT");
                }
            }
            ///////////////////


        }
        
    }

    //since special attacks handle things differently
    //it would be easier to create a takedamage function
    //instead of a deal damage function

    //anyway this function causes the player to take damage
    public void TakeDamage()
    {
        //I want to impliment a slowdown/zoom in effect when someone gets hit
        //but it isn't necessary

        Health -= 1;
        HP.text = Health.ToString();
        Hit = true; //when hit is on the player cant move
        StartCoroutine(HitAnimation());

       
    }

    //I seperated this from the take damage because coroutines do things in the order I list them
    //functions tend to be less controlled

     //this function isnt working quite how I want it to but it works well enough right now
    IEnumerator HitAnimation()
    {
        //stop both players from moving
        Opponent.RB.velocity = new Vector2(0.0f, 0.0f);
        RB.velocity = new Vector2(0.0f, 0.0f);

        //send both players flying away from eachother
        Opponent.RB.AddForce(3000.0f * Opponent.transform.localScale * -1.0f);
        RB.AddForce(3000.0f * transform.localScale * -1.0f);

        //we send them flying for about a minute
        int FrameCount = 60;
        while (FrameCount > 0)
        {
            Opponent.RB.AddForce(300.0f * Opponent.transform.localScale * -1.0f);
            RB.AddForce(300.0f * transform.localScale * -1.0f);
            FrameCount--;
            yield return null;
        }
        Hit = false; //allow player to move now
        yield return null;
    }

}
