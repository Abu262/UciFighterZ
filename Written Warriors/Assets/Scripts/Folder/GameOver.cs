using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI Announcement;
    public TextMeshProUGUI AnnouncementBG;
    public Player p1;
    public Player p2;
    public GameObject HealthDisplay;
    public GameObject GM;
    public StateManager SM;

    // Start is called before the first frame update
    void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this is called to announce when a match starts
    public IEnumerator StartMatch()
    {

        yield return StartCoroutine(SM.MoveTextIn("GET READY", "GET READY", Announcement, AnnouncementBG, 360.0f));
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(ShowRound());
        /*Announcement.text = "GET READY!";
        yield return new WaitForSeconds(2.0f); //waits 2 seconds
        Announcement.text = "3";
        yield return new WaitForSeconds(1.0f);  //1 second
        Announcement.text = "2";
        yield return new WaitForSeconds(1.0f);  // "
        Announcement.text = "1";*/
        //yield return new WaitForSeconds(1.0f);  // "
        Announcement.text = "FIGHT!";
        AnnouncementBG.text = "FIGHT!";

        //allows the playeers to fight
        StartCoroutine(p1.UnFreeze());
        StartCoroutine(p2.UnFreeze());

        yield return new WaitForSeconds(0.05f);
        Announcement.enabled = false;
        AnnouncementBG.enabled = false;
        yield return new WaitForSeconds(0.05f);
        Announcement.enabled = true;
        AnnouncementBG.enabled = true;
        yield return new WaitForSeconds(0.05f);
        Announcement.enabled = false;
        AnnouncementBG.enabled = false;
        yield return new WaitForSeconds(0.05f);
        Announcement.enabled = true;
        AnnouncementBG.enabled = true;
        yield return new WaitForSeconds(0.05f);
        Announcement.enabled = false;
        AnnouncementBG.enabled = false;
        yield return new WaitForSeconds(0.05f);
        Announcement.enabled = true;
        AnnouncementBG.enabled = true;
        yield return new WaitForSeconds(0.05f);
        Announcement.enabled = false;
        AnnouncementBG.enabled = false;
        yield return new WaitForSeconds(0.05f);
        Announcement.enabled = true;
        AnnouncementBG.enabled = true;
        yield return new WaitForSeconds(0.6f);

//        yield return new WaitForSeconds(1.0f); //waits another second before removing text
        Announcement.text = "";
        AnnouncementBG.text = "";
    }

    public IEnumerator ShowRound()
    {
        if (GM.GetComponent<GameManager>().w1 == 2 || GM.GetComponent<GameManager>().w2 == 2)
        {
            if (p1.GetComponent<Player>().Health > p2.GetComponent<Player>().Health)
            {
                Announcement.text = "MATCH COMPLETE: PLAYER 2 WINS!";
                AnnouncementBG.text = "MATCH COMPLETE: PLAYER 2 WINS!";
            }
            else
            {
                Announcement.text = "MATCH COMPLETE: PLAYER 1 WINS!";
                AnnouncementBG.text = "MATCH COMPLETE: PLAYER 1 WINS!";
            }
            yield return new WaitForSeconds(3.0f);
            GM.GetComponent<GameManager>().w2 = 0;
            GM.GetComponent<GameManager>().w1 = 0;
            SceneManager.LoadScene(0);
            yield return null;
        }
        else
        {
            HealthDisplay.GetComponent<HealthDisplay>().ResetHealth();
            //p1.CurrentForm.color = new Color(1f, 1f, 1f, 255f);
            //p2.CurrentForm.color = new Color(1f, 1f, 1f, 255f);
            Announcement.text = "ROUND " + (GM.GetComponent<GameManager>().w1 + GM.GetComponent<GameManager>().w2 + 1).ToString();
            AnnouncementBG.text = "ROUND " + (GM.GetComponent<GameManager>().w1 + GM.GetComponent<GameManager>().w2 + 1).ToString();
            yield return new WaitForSeconds(3.0f);

        }
    }

    //NICHOLE
    //////////////////////////////
    ///I  would recommend a few things
    /// 1) make 2 ints to keep track of the rounds wins for player 1 and player 2
    /// 2) make a coroutine* that increments a players round counter, 
    ///    then checks if said hplayer has won the required number of rounds to win,
    ///    if they didnt, then it resets sets the game back up to how it should be 
    ///    at the start of a round
    /// 3) place a call to this coroutine in the PlayerDies and TimerEnds coroutines,
    ///    these two coroutines are ALWAYS called when a player dies, 
    ///    so putting this coroutine in here would make it easier on you
    //////////////////////////////



    //this is called whenever a player dies
    //ok this looks weird, the PlayerDies Coroutine is called from the player that dies
    //meaning that if player 2 died, then they call this script, meaning player 1 wins
    public IEnumerator PlayerDies(string opponentTag)
    {
        //Disables player controls since the battle is over
        StartCoroutine(p1.Freeze());
        StartCoroutine(p2.Freeze());

        
        //announce KO
        Announcement.text = "K.O.";
        AnnouncementBG.text = "K.O.";
        SM.runTimer = false;
        yield return new WaitForSeconds(3.0f);
        

        //whoever wins, we announce it



        if (opponentTag == "Player1") //checks the tag of the player that won
        {
            p2.CurrentForm.color = new Color(1f, 1f, 1f, 0f);
            Announcement.text = "PLAYER ONE WINS!!!";
            AnnouncementBG.text = "PLAYER ONE WINS!!!";
            GM.GetComponent<GameManager>().w1++;
            //for a round system this is where we would count a round for P2
            

        }
        else//opponentTag == Player2
        {
            p1.CurrentForm.color = new Color(1f, 1f, 1f, 0f);
            Announcement.text = "PLAYER TWO WINS!!!";
            AnnouncementBG.text = "PLAYER TWO WINS!!!";
            GM.GetComponent<GameManager>().w2++;
            //for a round system this is where we would count a round for P2
        }
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1); //loads the main menu

        ////////
        yield return null; 
        ///////
    }


    //this happens when the timer ends
    //three situations for when a timer ends
    // 1) both players have equal health
    // 2) player 1 has more health
    // 3) player 2 has more health
    public IEnumerator TimerEnds()
    {

        //if the players have equal health
        if (p1.Health == p2.Health)
        {
            Announcement.text = "SUDDEN DEATH!!!";
            AnnouncementBG.text = "SUDDEN DEATH!!!";
            yield return new WaitForSeconds(0.5f);
            Announcement.text = "";
            AnnouncementBG.text = "";

            //set both hps equal to 1   
            while (p1.Health > 1)
            {
                p1.Health -= 1;
                FindObjectOfType<HealthDisplay>().ChangeHealth("Player1");
            }
            while (p2.Health > 1)
            {
                p2.Health -= 1;
                FindObjectOfType<HealthDisplay>().ChangeHealth("Player2");
            }
            yield return new WaitForSeconds(2.0f);
            //players keep on fighting until someone dies (I.E the PlayerDies coroutine is called


        }
        //else someone has less hp
        else
        {
            //stop the players from fighting
            StartCoroutine(p1.Freeze());
            StartCoroutine(p2.Freeze());
            Announcement.text = "TIME";
            AnnouncementBG.text = "TIME";
            //wait a few seconds
            yield return new WaitForSeconds(3.0f);

            //compare hp and announce winner

            ///player 1 wins
            if (p1.Health > p2.Health)
            {
                Announcement.text = "PLAYER ONE WINS!!!";
                AnnouncementBG.text = "PLAYER ONE WINS!!!";
                GM.GetComponent<GameManager>().w1++;
                //for a round system this is where we would count a round for P2
                
            }

            //player 2 wins
            if (p1.Health < p2.Health)
            {
                Announcement.text = "PLAYER TWO WINS!!!";
                AnnouncementBG.text = "PLAYER TWO WINS!!!";
                GM.GetComponent<GameManager>().w2++;
                //for a round system this is where we would count a round for P2
                
            }

            yield return new WaitForSeconds(3.0f);
            //loads main menu
            //NOTE: for a round system we are going to want to remove this
            SceneManager.LoadScene(1);
        }
        yield return null;
    }

    

}
