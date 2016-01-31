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

    public static bool PassedPreciseBeat;
    private static bool ChangedBeat;

    public static bool IsStartOfLanePhase
    {
        get { return ChangedBeat && CurrentBeat == 0; }
    }

    public static bool IsOnBeat
    {
        get { return TimeInBeat <= BeatThreshold/2; }
    }

    public static bool IsColorBeat
    {
        get { return CurrentBeat >= BeatsPerMeasure / 2; }
    }

    void Update()
    {
        var prevTimeInBeat = TimeInBeat;
        TimeInBeat = Time.time % TimePerBeat - BeatThreshold/2f;

        ChangedBeat = false;
        var startedNewBeat = prevTimeInBeat > TimeInBeat + BeatThreshold/2f;
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