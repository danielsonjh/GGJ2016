﻿using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource Audio;
    public AudioClip BassClip;
    public AudioClip BassClip2;

    void Start ()
    {
        Timer.OnPreciseBeat += () =>
        {
            if (Timer.CurrentBeat == 0)
            {
                Audio.PlayOneShot(BassClip2);
            }
            else
            {
                Audio.PlayOneShot(BassClip);
            }
        };
    }
}
