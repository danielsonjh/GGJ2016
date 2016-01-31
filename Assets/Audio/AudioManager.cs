using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource Audio;
    public AudioClip BassClip;

    void Start ()
    {
        Timer.OnPreciseBeat += () =>
        {
            Audio.PlayOneShot(BassClip);
        };
    }
}
