using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    public Color BeatColor;
    public Color OffbeatColor;

    void Update ()
	{
	    var time = Time.time % Timer.TimePerBeat;
        if (time <= Timer.StrobeThreshold)
        {
            LerpCameraColor(OffbeatColor, time / Timer.StrobeThreshold);
        }
        else if (time > Timer.TimePerBeat - Timer.StrobeThreshold)
        {
            LerpCameraColor(BeatColor, time / Timer.StrobeThreshold);
        }
	}

    private void LerpCameraColor(Color targetColor, float time)
    {
        var currColor = Camera.main.backgroundColor;

        Camera.main.backgroundColor = Color.Lerp(currColor, targetColor, time);
    }
}
