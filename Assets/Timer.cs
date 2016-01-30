using UnityEngine;

public class Timer : MonoBehaviour
{
    public const float BeatThreshold = 0.1f;
    public const float TimePerBeat = 0.5f;
    public const float BeatsPerMeasure = 4;

    public static float TimeInBeat;
    public static float CurrentBeat;
    
    void Update()
    {
        var prevTimeInBeat = TimeInBeat;
        TimeInBeat = Time.time % TimePerBeat;

        if (prevTimeInBeat > TimeInBeat)
        {
            CurrentBeat++;
            CurrentBeat %= BeatsPerMeasure;
        }
    }

    public static bool IsOnBeat()
    {
        return TimeInBeat < BeatThreshold || TimePerBeat - TimeInBeat < BeatThreshold;
    }

    public static bool IsColorBeat()
    {
        return CurrentBeat >= BeatsPerMeasure / 2;
    }
}