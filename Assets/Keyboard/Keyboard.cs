﻿using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Keyboard : MonoBehaviour
{
    public const float LaserDuration = 0.3f;
    
    public GameObject Laser;
    public GameObject LaneSelector;

    public static bool GotKeyForBeat;
    public AudioSource Lead;

    private bool _gotKeyForBeat;

    private readonly List<Note> _selectedLanes = new List<Note>();

    private SpriteRenderer _grayBoxRenderer;

    void Start()
    {
        _grayBoxRenderer = transform.FindChild("GrayBox").GetComponent<SpriteRenderer>();

        Timer.OnChangeBeat += ResetKeyForBeatFlag;
    }

    void Update()
    {
        if (Timer.IsOnBeat && !GotKeyForBeat)
        {
            var audio = Instantiate(Lead);
            if (Input.GetKeyDown(KeyCode.A))
            {
                PressKey(Note.A);
                audio.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -6);
                audio.Play();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                PressKey(Note.B);
                audio.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -3);
                audio.Play();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PressKey(Note.C);
                audio.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -1);
                audio.Play();
            }

            else if (Input.GetKeyDown(KeyCode.F))
            {
                PressKey(Note.D);
                audio.pitch = Mathf.Pow(AudioManager.PitchMultiplier, 1);
                audio.Play();
            }
            else if (Input.GetKeyDown(KeyCode.G) && Stats.Instance.Difficult) 

            {
                PressKey(Note.E);
                audio.pitch = Mathf.Pow(AudioManager.PitchMultiplier, 4);
                audio.Play();
            }
            Destroy(audio, 10f);
        }

        if (Timer.IsStartOfLanePhase)
        {
            _selectedLanes.Clear();
        }

        ShowGrayBox(!Timer.IsColorBeat);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Enemy(Clone)")
        {
            Stats.Instance.Lives--;
        }
    }

    private void PressKey(Note note)
    {
        GotKeyForBeat = true;
        if (Timer.IsColorBeat)
        {
            foreach (var selectedLane in _selectedLanes)
            {
                var laser = InstantiateAt(Laser, selectedLane);
                laser.GetComponent<LazerBehavior>().Note = note;
                Destroy(laser, LaserDuration);
            }
        }
        else
        {
            InstantiateAt(LaneSelector, note);
            _selectedLanes.Add(note);
        }
    }

    private void ShowGrayBox(bool shown)
    {
        _grayBoxRenderer.enabled = shown;
    }

    private GameObject InstantiateAt(GameObject prefab, Note note)
    {
        var clone = Instantiate(prefab);
        clone.transform.position = Notes.KeyPositions[note];
        return clone;
    }

    private void ResetKeyForBeatFlag()
    {
        GotKeyForBeat = false;
    }
}
