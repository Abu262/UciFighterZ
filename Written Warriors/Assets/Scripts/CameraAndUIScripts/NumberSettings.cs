using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberSettings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NumberOfRounds; // Text display of the rounds per game option
    [SerializeField] private TextMeshProUGUI TimePerMatch; // Text display of the time per match option
    private GameObject Audio; // Audio Manager

    private void Awake()
    {
        Audio = GameObject.FindGameObjectWithTag("audio");
    }

    // Increase the number of rounds in a game
    public void IncreaseRounds()
    {
        if (Options.Rounds < Options.MaxRounds)
        {
            Options.Rounds += 1;
        }
        else
        {
            Options.Rounds = Options.MinRounds;
        }
        UpdateRounds();
    }

    // Decrease the number of rounds
    public void DecreaseRounds()
    {
        if (Options.Rounds > Options.MinRounds)
        {
            Options.Rounds -= 1;
        }
        else
        {
            Options.Rounds = Options.MaxRounds;
        }
        UpdateRounds();
    }

    // Update rounds to reflect changes
    private void UpdateRounds()
    {
        Debug.Log("Updated");
        Audio.GetComponent<AudioManager>().Play("MenuSelect");
        NumberOfRounds.text = Options.Rounds.ToString();
    }

    // Increase the amount of time each round takes
    public void IncreaseTime()
    {
        if (Options.Time < Options.MaxSeconds)
        {
            Options.Time += 333;
        }
        else
        {
            Options.Time = Options.MinSeconds;
        }
        UpdateTime();
    }

    // Decrease the amount of time each round takes
    public void DecreaseTime()
    {
        if (Options.Time > Options.MinSeconds)
        {
            Options.Time -= 333;
        }
        else
        {
            Options.Time = Options.MaxSeconds;
        }
        UpdateTime();
    }

    // Update time to reflect changes
    private void UpdateTime()
    {
        Debug.Log("Updated");
        Audio.GetComponent<AudioManager>().Play("MenuSelect");
        TimePerMatch.text = Options.Time.ToString();
    }

}
