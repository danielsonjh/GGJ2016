using UnityEngine;

public class BeatHitDetector : MonoBehaviour {

    public const string BeatIndicatorTag = "BeatIndicator";
    
    public const float TextDuration = Timer.TimePerBeat * 0.5f;
    public const float BeatIndicatorOffset = 2;
    public Sprite WhiteX;
    public Sprite ColorX;
    
    private bool _alreadyShowingText = false;

    void Start()
    {
        Timer.OnChangeBeat += ResetShowingTextFlag;
    }

    void Update ()
    {
        if (!_alreadyShowingText)
        {
            var tooLateForBeat = !Timer.IsOnBeat && !Keyboard.GotKeyForBeat;
            if (tooLateForBeat)
            {
                _alreadyShowingText = true;
                var beatIndicator = GetClosestBeatIndicator();
                if (beatIndicator != null && beatIndicator.transform.position.y < BeatIndicatorOffset)
                {
                    beatIndicator.tag = "Untagged";
                    beatIndicator.GetComponent<BeatIndicator>().Hit();

                    ReplaceBeatIndicatorSprites(beatIndicator);
                }
            }
            else if (Timer.IsOnBeat && Keyboard.GotKeyForBeat)
            {
                _alreadyShowingText = true;

                var beatIndicator = GetClosestBeatIndicator();
                if (beatIndicator != null && beatIndicator.transform.position.y < BeatIndicatorOffset)
                {
                    beatIndicator.tag = "Untagged";
                    beatIndicator.GetComponent<BeatIndicator>().Hit();
                }
                
            }
        }
    }

    void OnDestroy()
    {
        Timer.OnChangeBeat -= ResetShowingTextFlag;
    }

    private void ResetShowingTextFlag()
    {
        _alreadyShowingText = false;
    }

    private void ReplaceBeatIndicatorSprites(GameObject prefab)
    {
        foreach (var sprite in prefab.GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.sprite = prefab.GetComponent<BeatIndicator>().IsColored ? ColorX : WhiteX;
        }
    }

    private GameObject GetClosestBeatIndicator()
    {
        var beatIndicators = GameObject.FindGameObjectsWithTag(BeatIndicatorTag);
        var closest = beatIndicators.Length > 0 ? beatIndicators[0] : null;
        foreach (var beatIndicator in beatIndicators)
        {
            if (closest == null || (transform.position - beatIndicator.transform.position).magnitude < (transform.position - closest.transform.position).magnitude)
            {
                closest = beatIndicator;
            }
        }

        return closest;
    }
}
