using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text Announcement;
    public Player p1;
    public Player p2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this is called to announce when a match starts
    public IEnumerator StartMatch()
    {

        Announcement.text = "GET READY!";
        yield return new WaitForSeconds(2.0f); //waits 2 seconds
        Announcement.text = "3";
        yield return new WaitForSeconds(1.0f);  //1 second
        Announcement.text = "2";
        yield return new WaitForSeconds(1.0f);  // "
        Announcement.text = "1";
        yield return new WaitForSeconds(1.0f);  // "
        Announcement.text = "FIGHT!";

        //allows the playeers to fight
        StartCoroutine(p1.UnFreeze());
        StartCoroutine(p2.UnFreeze());
        yield return new WaitForSeconds(1.0f); //waits another second before removing text
        Announcement.text = "";
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
    //hope this helps!


    //*
    //I dont know if you ever used a coroutine before. but here's an explanation
    //Coroutines are like functions with a few perks.
    //   They run EXACTLY in the order you write them
    //   you can tell them to pause and wait before moving on
    //   they run parallel to the rest of the game, so they're good for timers and stuff like that

    //also they always have to have a yield call somewhere in them
    //if you remember ICS 33 then think of it as an iterator, 
    //it has to reach a yield no matter what path it takes

    //I can explain it more if you want, feel free to ask




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
        yield return new WaitForSeconds(3.0f);


        //whoever wins, we announce it



        if (opponentTag == "Player1") //checks the tag of the player that won
        {
            p2.CurrentForm.color = new Color(1f, 1f, 1f, 0f);
            Announcement.text = "PLAYER ONE WINS!!!";
            //for a round system this is where we would count a round for P2
            

        }
        else//opponentTag == Player2
        {
            p1.CurrentForm.color = new Color(1f, 1f, 1f, 0f);
            Announcement.text = "PLAYER TWO WINS!!!";
            //for a round system this is where we would count a round for P2
        }
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene(0); //loads the main menu

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
            yield return new WaitForSeconds(1.0f);
            Announcement.text = "";

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
            //wait a few seconds
            yield return new WaitForSeconds(3.0f);

            //compare hp and announce winner

            ///player 1 wins
            if (p1.Health > p2.Health)
            {
                Announcement.text = "PLAYER ONE WINS!!!";
                //for a round system this is where we would count a round for P2
                
            }

            //player 2 wins
            if (p1.Health < p2.Health)
            {
                Announcement.text = "PLAYER TWO WINS!!!";
                //for a round system this is where we would count a round for P2
                
            }

            yield return new WaitForSeconds(3.0f);
            //loads main menu
            //NOTE: for a round system we are going to want to remove this
            SceneManager.LoadScene(0);
        }
        yield return null;
    }

    

}
