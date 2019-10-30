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

    public IEnumerator PlayerDies(string opponentTag)
    {
        //explode opponent
        StartCoroutine(p1.Freeze());
        StartCoroutine(p2.Freeze());
        //announce KO
        Announcement.text = "K.O.";
        yield return new WaitForSeconds(3.0f);


        //announce winner

        //load main menu

        if (opponentTag == "Player1")
        {
            p2.CurrentForm.color = new Color(1f, 1f, 1f, 0f);
            Announcement.text = "PLAYER ONE WINS!!!";
            
            //PLAYER 1 WINS return to char select

        }
        else
        {
            p1.CurrentForm.color = new Color(1f, 1f, 1f, 0f);
            Announcement.text = "PLAYER TWO WINS!!!";
            //PLAYER 2 WINS return to char select
        }
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0);
        yield return null;
    }


    public IEnumerator TimerEnds()
    {
        if (p1.Health == p2.Health)
        {
            Announcement.text = "SUDDEN DEATH!!!";
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
            //SUDDEN DEATH shit goes down
        }
        else
        {
            StartCoroutine(p1.Freeze());
            StartCoroutine(p2.Freeze());
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
