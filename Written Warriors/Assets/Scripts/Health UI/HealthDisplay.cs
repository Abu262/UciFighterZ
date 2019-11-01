using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public GameObject Display1; // Health display
    public GameObject Display2; // Health display
    private int HealthTracker1; // Keeps track of player's last known health
    private int HealthTracker2;
    private void Start()
    {
        HealthTracker1 = 3;
        HealthTracker2 = 3;
    }


    private void FlipSprite()
    {
        this.transform.Rotate(0f, 180f, 0f);
    }

    public void ChangeHealth(string player)
    {
        if (player == "Player1")
        {
            Display1.transform.GetChild(HealthTracker1 - 1).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
            //Destroy(Display1.transform.GetChild(HealthTracker1 - 1).gameObject);
            HealthTracker1 -= 1;
        }
        else
        {
            Display2.transform.GetChild(HealthTracker2 - 1).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
            //Destroy(Display2.transform.GetChild(HealthTracker2 - 1).gameObject);
            HealthTracker2 -= 1;
        }
    }

    public void ResetHealth()
    {
        for (int i = 0; i < Display1.transform.childCount; ++i)
        {
            Display1.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }
        for (int i = 0; i < Display2.transform.childCount; ++i)
        {
            Display2.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }
        HealthTracker1 = 3;
        HealthTracker2 = 3;
    }

}
