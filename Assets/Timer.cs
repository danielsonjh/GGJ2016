using System;
using UnityEngine;


public class Timer : MonoBehaviour
{
    public const float BeatThreshold = 0.4f;
    public const float TimePerBeat = 0.6f;
    public const int BeatsPerMeasure = 4;
    public const int DivsPerBeat = 8;

    public static float TimeInBeat;
    public static int CurrentBeat;
    public static int CurrentDiv;

    public static event Action OnChangeBeat;
    public static event Action OnPreciseBeat;
    public static event Action OnNextDiv;

    private static bool ChangedBeat;
    private static bool PassedPreciseBeat;

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
        var prevDiv = CurrentDiv;
        TimeInBeat = Time.time % TimePerBeat - BeatThreshold/2f;
        CurrentDiv = (int)(((((TimeInBeat) / TimePerBeat) + 1) * DivsPerBeat) % DivsPerBeat);
        if (prevDiv != CurrentDiv)
        {
            if (OnNextDiv != null) OnNextDiv();
        }
        ChangedBeat = false;
        var startedNewBeat = prevTimeInBeat > TimeInBeat + BeatThreshold/2f;
        if (startedNewBeat)
        {
            PassedPreciseBeat = false;
            ChangedBeat = true;
            CurrentBeat++;
            CurrentBeat %= BeatsPerMeasure;
            CurrentDiv = 0;

            if (OnChangeBeat != null) OnChangeBeat();
        }
        if (!PassedPreciseBeat && TimeInBeat > 0)
        {
            PassedPreciseBeat = true;
            if (OnPreciseBeat != null) OnPreciseBeat();
        }
    }
}