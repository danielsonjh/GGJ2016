using UnityEngine;

public class Timer : MonoBehaviour
{
    public const float BeatThreshold = 0.35f;
    public const float TimePerBeat = 0.6f;
    public const int BeatsPerMeasure = 4;

    public static float TimeInBeat;
    public static int CurrentBeat;
    public static bool ChangedBeat;
    
    public static bool IsStartOfLanePhase
    {
        get { return ChangedBeat && CurrentBeat == 0; }
    }

    public static bool IsOnBeat
    {
        get { return TimeInBeat <= BeatThreshold; }
    }

    public static bool IsColorBeat
    {
        get { return CurrentBeat >= BeatsPerMeasure / 2; }
    }



    void Update()
    {
        var prevTimeInBeat = TimeInBeat;
        TimeInBeat = Time.time % TimePerBeat;

        ChangedBeat = false;
        if (prevTimeInBeat > TimeInBeat)
        {
            ChangedBeat = true;
            CurrentBeat++;
            CurrentBeat %= BeatsPerMeasure;
        }
    }

}