using UnityEngine;

public class BeatHitDetector : MonoBehaviour {

    public const float TextDuration = Timer.TimePerBeat * 0.5f;
    public readonly Vector2 TextPosition = new Vector2(-5, 1);
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
            var tooEarlyForBeat = !Timer.PassedPreciseBeat && Keyboard.GotKeyForBeat;
            var tooLateForBeat = Timer.PassedPreciseBeat && !Keyboard.GotKeyForBeat;

            if (tooEarlyForBeat || tooLateForBeat)
            {
                InstantiateTextIndicator(MissText);
            }
            else if (Timer.IsOnBeat && Keyboard.GotKeyForBeat)
            {
                InstantiateTextIndicator(HitText);
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
}
