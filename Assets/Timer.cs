using UnityEngine;

public class Timer : MonoBehaviour
{
    public const float BeatThreshold = 0.25f;
    public const float TimePerBeat = 0.6f;
    public const int BeatsPerMeasure = 4;

    public static float TimeInBeat;
    public static int CurrentBeat;

    public static bool IsStartOfLanePhase
    {
        get { return _changedBeat && CurrentBeat == 0; }
    }

    public static bool IsOnBeat
    {
        get { return TimeInBeat <= BeatThreshold; }
    }

    public static bool IsColorBeat
    {
        get { return CurrentBeat >= BeatsPerMeasure / 2; }
    }

    private static bool _changedBeat;


    void Update()
    {
        var prevTimeInBeat = TimeInBeat;
        TimeInBeat = Time.time % TimePerBeat;

        _changedBeat = false;
        if (prevTimeInBeat > TimeInBeat)
        {
            _changedBeat = true;
            CurrentBeat++;
            CurrentBeat %= BeatsPerMeasure;
        }
    }

}