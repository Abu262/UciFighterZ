using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(Display1.transform.GetChild(HealthTracker1 - 1).gameObject);
            HealthTracker1 -= 1;
        }
        else
        {
            Destroy(Display2.transform.GetChild(HealthTracker2 - 1).gameObject);
            HealthTracker2 -= 1;
        }


    }

}
