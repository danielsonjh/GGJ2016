using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    public Color BeatColor;
    public Color OffbeatColor;

    void Update ()
	{
        if (Timer.TimeInBeat >= 0 - Timer.BeatThreshold && Timer.TimeInBeat <= 0)
        {
            LerpCameraColor(BeatColor, (Timer.TimePerBeat - Timer.BeatThreshold + Timer.TimeInBeat));
        }
        else if (Timer.TimeInBeat >= 0 && Timer.TimeInBeat <= Timer.BeatThreshold)
        {
            LerpCameraColor(OffbeatColor, (Timer.TimePerBeat - Timer.TimeInBeat));
        }
	}

    private void LerpCameraColor(Color targetColor, float time)
    {
        var currColor = Camera.main.backgroundColor;

        Camera.main.backgroundColor = Color.Lerp(currColor, targetColor, time);
    }
}
