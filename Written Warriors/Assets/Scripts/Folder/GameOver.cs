using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text Announcement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayerDies(string opponentTag)
    {
        //explode opponent

        //announce KO
        Announcement.text = "K.O.";
        yield return new WaitForSeconds(3.0f);

        //announce winner
        
        //load main menu

        if (opponentTag == "Player1")
        {
            Announcement.text = "PLAYER ONE WINS!!!";
            
            //PLAYER 1 WINS return to char select

        }
        else
        {
            Announcement.text = "PLAYER TWO WINS!!!";
            //PLAYER 2 WINS return to char select
        }
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0);
        yield return null;
    }


    public IEnumerator TimerEnds(Player p1, Player p2)
    {
        if (p1.Health == p2.Health)
        {
            Announcement.text = "SUDDEN DEATH!!!";
            p1.Health = 1;
            p2.Health = 1;
            //SUDDEN DEATH shit goes down
        }
        else
        {
            Announcement.text = "TIME";
            yield return new WaitForSeconds(3.0f);

            if (p1.Health > p2.Health)
            {
                Announcement.text = "PLAYER ONE WINS!!!";

                //PLAYER 1 WINS return to char select
            }
            if (p1.Health < p2.Health)
            {
                Announcement.text = "PLAYER TWO WINS!!!";

                //PLAYER 2 WINS return to char
            }

            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene(0);
        }


        

        yield return null;
    }

    

}
