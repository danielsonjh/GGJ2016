﻿using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    public Color BeatColor;
    public Color OffbeatColor;

    void Update ()
	{
        if (Timer.TimeInBeat >= Timer.TimePerBeat-Timer.BeatThreshold)
        {
            LerpCameraColor(BeatColor, Timer.TimePerBeat-Timer.BeatThreshold + Timer.TimeInBeat));
        }
        else if (Timer.TimeInBeat <= Timer.BeatThreshold)
        {
            LerpCameraColor(OffbeatColor, Timer.BeatThreshold / (Timer.TimeInBeat + Timer.BeatThreshold));
        }
	}

    private void LerpCameraColor(Color targetColor, float time)
    {
        var currColor = Camera.main.backgroundColor;

        Camera.main.backgroundColor = Color.Lerp(currColor, targetColor, time);
    }
}
