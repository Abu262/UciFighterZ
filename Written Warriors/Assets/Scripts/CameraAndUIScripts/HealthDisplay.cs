using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public GameObject Display1; // Health display
    public GameObject Display2; // Health display
    public GameObject DisplayRed1; // Red underlay for player one's health display
    public GameObject DisplayRed2; // Red underlay for player two's health display
    private int HealthTracker1; // Keeps track of player's last known health
    private int HealthTracker2;
    public Player Player1;
    public Player Player2;

    private void FlipSprite()
    {
        this.transform.Rotate(0f, 180f, 0f);
    }

    private IEnumerator ChangeDisplay(GameObject Display, GameObject DisplayRed, int Health) // Update the health displays
    {
        yield return StartCoroutine(FlashHealth(Display, Health, 2));
        Display.transform.GetChild(Health - 1).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
        DisplayRed.transform.GetChild(Health - 1).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
    }

    private IEnumerator FlashHealth(GameObject Display, int Health, int max)  // Flash the health bar whenever the player takes a hit
    {
        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < Health; j++)
            {
                Display.transform.GetChild(j).gameObject.GetComponent<Image>().enabled = true;
            }
            yield return new WaitForSeconds(0.05f);
            for (int j = 0; j < Health; j++)
            {
                Display.transform.GetChild(j).gameObject.GetComponent<Image>().enabled = false;
            }
            yield return new WaitForSeconds(0.05f);
            for (int j = 0; j < Health; j++)
            {
                Display.transform.GetChild(j).gameObject.GetComponent<Image>().enabled = true;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ChangeHealth(string player)
    {
        if (player == "Player1")
        {
            if (HealthTracker1 - 1 >= 0)
            {
                StartCoroutine(ChangeDisplay(Display1, DisplayRed1, HealthTracker1));
                //Display1.transform.GetChild(HealthTracker1 - 1).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
                //Destroy(Display1.transform.GetChild(HealthTracker1 - 1).gameObject);


            }
            HealthTracker1 -= 1;
            //if (HealthTracker1 == 1)
            //{
            //    Rage1.SetActive(true);
            //}

        }
        else
        {
            if (HealthTracker2 - 1 >= 0)
            {
                StartCoroutine(ChangeDisplay(Display2, DisplayRed2, HealthTracker2));
                //Display2.transform.GetChild(HealthTracker2 - 1).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
                //Destroy(Display2.transform.GetChild(HealthTracker2 - 1).gameObject);

            }
            HealthTracker2 -= 1;
            //if (HealthTracker2 == 1)
            //{
            //    Rage2.SetActive(true);
            //}
        }
    }

    public void ResetHealth()
    {
        for (int i = 0; i < Display1.transform.childCount; ++i)
        {
            Display1.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
            DisplayRed1.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }
        for (int i = 0; i < Display2.transform.childCount; ++i)
        {
            Display2.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
            DisplayRed2.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }
        HealthTracker1 = 3;
        HealthTracker2 = 3;
    }

}
