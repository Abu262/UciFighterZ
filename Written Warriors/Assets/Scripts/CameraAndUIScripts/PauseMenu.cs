using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject BG; // The background of the pause menu
    public TextMeshProUGUI StatusBG; // Background of the text
    public TextMeshProUGUI Status; // Foreground of the text
    public bool isPaused;
    private Vector2 PrevPlayer1Velocity;
    private Vector2 PrevPlayer2Velocity;

    public void Update()
    {
        if (isPaused)
        {
            PauseGame(); 
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        BG.SetActive(true);
        StatusBG.color = new Color(21, 59, 176, 255);
        Status.color = new Color(255, 255, 255, 255);
        StartCoroutine(FlashStatus());
        FreezePlayers();
    }

    public void ResumeGame()
    {
        BG.SetActive(true);
        StatusBG.color = new Color(21, 59, 176, 0);
        Status.color = new Color(255, 255, 255, 0);
        StopCoroutine(FlashStatus());
    }
    
    private void FreezePlayers()
    {
        PrevPlayer1Velocity = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>().velocity;
        PrevPlayer2Velocity = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody2D>().velocity;
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void UnFreezePlayers()
    {
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>().velocity = PrevPlayer1Velocity;
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody2D>().velocity = PrevPlayer2Velocity;
    }

    private IEnumerator FlashStatus()
    {
        while(true)
        {
            StatusBG.color = new Color(21, 59, 176, 255);
            Status.color = new Color(255, 255, 255, 255);
            yield return new WaitForSeconds(0.05f);
            StatusBG.color = new Color(21, 59, 176, 0);
            Status.color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }

}
