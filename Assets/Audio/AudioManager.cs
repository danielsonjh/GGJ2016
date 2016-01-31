using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource Bass1;
    public AudioSource Bass2;
    public AudioSource Snare;

    void Start ()
    {
        Timer.OnNextDiv += OnNextDivHandler;
    }

    void OnDestroy()
    {
        Timer.OnNextDiv -= OnNextDivHandler;
    }

    private void OnNextDivHandler()
    {
        switch (Timer.CurrentDiv)
        {
            case 0:
                if (Timer.CurrentBeat == 0)
                {
                    Bass2.Play();
                } else
                {
                    Bass1.Play();
                }
                break;
            case 2:
                break;
            case 4:
                Snare.Play();
                break;
            case 6:
                break;
        }
    }
}
