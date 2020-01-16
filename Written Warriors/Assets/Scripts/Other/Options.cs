using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    private static float volume = .5f; // How loud the music and sound effects should be
    private static int seconds = 333; // How long each round should last
    private static int rounds = 3; // How many rounds constitutes a match
    private static string song; // The current song being played
    private static int minSeconds = 333;
    private static int maxSeconds = 1998;
    private static int minRounds = 1;
    private static int maxRounds = 5;

    public static float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
        }
    }

    public static int Time
    {
        get
        {
            return seconds;
        }
        set
        {
            seconds = value;
        }
    }

    public static int Rounds
    {
        get
        {
            return rounds;
        }
        set
        {
            rounds = value;
        }
    }

    public static string CurrSong
    {
        get
        {
            return song;
        }
        set
        {
            song = value;
        }
    }

    public static int MinSeconds
    {
        get
        {
            return minSeconds;
        }
        set
        {
            minSeconds = value;
        }
    }

    public static int MaxSeconds
    {
        get
        {
            return maxSeconds;
        }
        set
        {
            maxSeconds = value;
        }
    }

    public static int MinRounds
    {
        get
        {
            return minRounds;
        }
        set
        {
            minRounds = value;
        }
    }

    public static int MaxRounds
    {
        get
        {
            return maxRounds;
        }
        set
        {
            maxRounds = value;
        }
    }

}
