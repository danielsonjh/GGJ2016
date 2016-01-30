using UnityEngine;

public class Timer : MonoBehaviour
{
    public const float TimePerBeat = 0.5f;
    public const float BeatThreshold = 0.1f;

    public static float TimeInBeat;
    
    void Update()
    {
        TimeInBeat = Time.time % TimePerBeat;
    }

    public static bool IsOnBeat()
    {
        return TimeInBeat < BeatThreshold || TimePerBeat - TimeInBeat < BeatThreshold;
    }
}