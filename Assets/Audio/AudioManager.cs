﻿using UnityEngine;

public class AudioManager : MonoBehaviour {

    public const float PitchMultiplier = 1.05946f;

    public AudioSource Bass1;
    public AudioSource Bass2;
    public AudioSource Snare;
    public AudioSource EnemyAudio;
    public AudioSource Ambient;

    void Start ()
    {
        Timer.OnNextDiv += OnNextDivHandler;
        Bass1.volume = 0.5f;
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
                //Snare.Play();
                break;
            case 6:
                break;
        }
    }
    
    public void PlayEnemyAudio(Note color)
    {
        var pitchModifier = 0;
        var rand = Random.Range(0f, 1f);
        switch (color)
        {
            case Note.A:
                pitchModifier = 1;
                break;
            case Note.B:
                pitchModifier = 4;
                break;
            case Note.C:
                pitchModifier = 6;
                break;
            case Note.D:
                pitchModifier = 9;
                break;
            case Note.E:
                pitchModifier = 11;
                break;
        }
        if (rand > 0.5f)
        {
            pitchModifier -= 12;
        }
        var audio = Instantiate(EnemyAudio);
        audio.pitch = Mathf.Pow(AudioManager.PitchMultiplier, pitchModifier);
        audio.Play();
        Destroy(audio, 10f);
    }
}
