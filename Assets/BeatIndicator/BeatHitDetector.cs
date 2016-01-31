using UnityEngine;

public class BeatHitDetector : MonoBehaviour {

    public const string BeatIndicatorTag = "BeatIndicator";
    
    public const float TextDuration = Timer.TimePerBeat * 0.5f;
    public const float BeatIndicatorOffset = 2;
    public readonly Vector2 TextPosition = new Vector2(-4, 0.5f);
    public GameObject HitText;
    public GameObject MissText;
    
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
                var beatIndicator = GetClosestBeatIndicator();
                if (beatIndicator != null && beatIndicator.transform.position.y < BeatIndicatorOffset)
                {
                    beatIndicator.tag = "Untagged";
                    beatIndicator.GetComponent<BeatIndicator>().Miss();
                    InstantiateTextIndicator(MissText);
                }
            }
            else if (Timer.IsOnBeat && Keyboard.GotKeyForBeat)
            {
                var beatIndicator = GetClosestBeatIndicator();
                if (beatIndicator != null && beatIndicator.transform.position.y < BeatIndicatorOffset)
                {
                    beatIndicator.tag = "Untagged";
                    beatIndicator.GetComponent<BeatIndicator>().Hit();
                    InstantiateTextIndicator(HitText);
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

    private void InstantiateTextIndicator(GameObject prefab)
    {
        _alreadyShowingText = true;
        var clone = Instantiate(prefab);
        prefab.transform.position = TextPosition;
        Destroy(clone, TextDuration);
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
