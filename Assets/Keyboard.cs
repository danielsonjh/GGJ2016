﻿using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Keyboard : MonoBehaviour
{
    public const float LaserDuration = 0.3f;
    public GameObject Laser;
    public GameObject LaneSelector;


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
        if (Timer.IsOnBeat && !_gotKeyForBeat)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PressKey(Note.A);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                PressKey(Note.B);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PressKey(Note.C);
            }
<<<<<<< HEAD
            else if (Input.GetKeyDown(KeyCode.F))
            {
                PressKey(Note.D);
            }
            else if (Input.GetKeyDown(KeyCode.G)) 
=======
            else if (Input.GetKeyDown(KeyCode.F) && Stats.Instance.Difficult)
            {
                PressKey(Note.D);
            }
            else if (Input.GetKeyDown(KeyCode.G) && Stats.Instance.Difficult) 
>>>>>>> a728c546f4e355b5c03c58d8f3cd6c697ea05c50
            {
                PressKey(Note.E);
            }
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
        _gotKeyForBeat = true;
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
        _gotKeyForBeat = false;
    }
}
