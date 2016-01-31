using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public const float BeatThreshold = 0.4f;
    public const float TimePerBeat = 0.6f;
    public const int BeatsPerMeasure = 4;

    public static float TimeInBeat;
    public static int CurrentBeat;

    public static event Action OnChangeBeat;
    public static event Action OnPreciseBeat;

    private static bool ChangedBeat;
    private static bool PassedPreciseBeat;
    
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
        var startedNewBeat = prevTimeInBeat > TimeInBeat;
        if (startedNewBeat)
        {
            PassedPreciseBeat = false;
            ChangedBeat = true;
            CurrentBeat++;
            CurrentBeat %= BeatsPerMeasure;

            if (OnChangeBeat != null) OnChangeBeat();
        }

        if (!PassedPreciseBeat && TimeInBeat > BeatThreshold/2f)
        {
            PassedPreciseBeat = true;
            if (OnPreciseBeat != null) OnPreciseBeat();
        }
    }
}