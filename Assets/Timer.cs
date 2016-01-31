using System;
using UnityEngine;


public class Timer : MonoBehaviour
{
    public const float BeatThreshold = 0.15f;
    public const float InitialTimePerBeat = 0.68f;
    public static float TimePerBeat = InitialTimePerBeat;
    public const int BeatsPerMeasure = 4;
    public const int DivsPerBeat = 8;

    public static float TimeInBeat;
    public static int CurrentBeat;
    public static int CurrentDiv;
    public static int CurrentMeasure;

    public static event Action OnChangeBeat;
    public static event Action OnPreciseBeat;
    public static event Action OnNextDiv;

    public static bool PassedPreciseBeat;
    private static bool ChangedBeat;

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
        var prevDiv = CurrentDiv;

        TimeInBeat = Time.time % TimePerBeat - BeatThreshold;

        CurrentDiv = (int)(((((TimeInBeat) / TimePerBeat) + 1) * DivsPerBeat) % DivsPerBeat);
        if (prevDiv != CurrentDiv)
        {
            if (OnNextDiv != null) OnNextDiv();
        }
        ChangedBeat = false;
        var startedNewBeat = prevTimeInBeat > TimeInBeat + BeatThreshold;
        if (startedNewBeat)
        {
            PassedPreciseBeat = false;
            ChangedBeat = true;
            CurrentBeat++;
            CurrentBeat %= BeatsPerMeasure;
            if (CurrentBeat == 0)
            {
                CurrentMeasure++;
            }
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