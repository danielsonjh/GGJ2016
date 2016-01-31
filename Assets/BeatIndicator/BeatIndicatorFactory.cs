using UnityEngine;

public class BeatIndicatorFactory : MonoBehaviour
{
    public GameObject BeatIndicator;
    public Sprite WhiteRing;
    public Sprite ColorRing;

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

        foreach (var sprite in clone.GetComponentsInChildren<SpriteRenderer>())
        {
            var isColored = Timer.CurrentBeat >= Timer.BeatsPerMeasure/2;
            clone.GetComponent<BeatIndicator>().IsColored = isColored;
            sprite.sprite = isColored ? ColorRing : WhiteRing;
        }
        
        if (Timer.CurrentBeat%2 == 0)
        {
            for (int i = 0; i < clone.transform.childCount; i++)
            {
                clone.transform.GetChild(i).localScale = new Vector3(0.75f, 0.75f, 1f);
            }
        }
    }
}
