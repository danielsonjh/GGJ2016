using System;
using UnityEngine;


public class Timer : MonoBehaviour
{
    public const float BeatThreshold = 0.2f;
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
        get { return Math.Abs(TimeInBeat) <= BeatThreshold; }
    }

    public static bool IsColorBeat
    {
        get { return CurrentBeat >= BeatsPerMeasure / 2; }
    }

    void Update()
    {
        var prevTimeInBeat = TimeInBeat;
        TimeInBeat = Time.time % TimePerBeat - BeatThreshold;

        ChangedBeat = false;
        var startedNewBeat = prevTimeInBeat > TimeInBeat + BeatThreshold;
        if (startedNewBeat)
        {
            PassedPreciseBeat = false;
            ChangedBeat = true;
            CurrentBeat++;
            CurrentBeat %= BeatsPerMeasure;

            if (OnChangeBeat != null) OnChangeBeat();
        }

        if (!PassedPreciseBeat && TimeInBeat > 0)
        {
            PassedPreciseBeat = true;
            if (OnPreciseBeat != null) OnPreciseBeat();
        }
    }
}