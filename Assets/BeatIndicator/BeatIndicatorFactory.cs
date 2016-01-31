using UnityEngine;

public class BeatIndicatorFactory : MonoBehaviour
{
    public GameObject BeatIndicator;

    private const float SpawnTimeOffset = Timer.TimePerBeat * Timer.BeatsPerMeasure;
    private readonly Vector2 _beatIndicatorVel = new Vector2(0, -6f);
    private readonly Vector2 _beatIndicatorDest = new Vector2(0, 1);

    void Start()
    {
        Timer.OnPreciseBeat += CreateBeatIndicator;
    }

    private void CreateBeatIndicator()
    {
        var clone = Instantiate(BeatIndicator);
        clone.transform.position = _beatIndicatorDest + new Vector2(0, Mathf.Abs(_beatIndicatorVel.y * SpawnTimeOffset));
        clone.GetComponent<Rigidbody2D>().velocity = _beatIndicatorVel;
    }
}
