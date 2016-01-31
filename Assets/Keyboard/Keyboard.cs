using System.Collections.Generic;
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

    void Start()
    {
        Timer.OnChangeBeat += ResetKeyForBeatFlag;
    }

    void Update()
    {
        if (Timer.IsOnBeat && !GotKeyForBeat)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PressKey(Note.A);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -6);
                Lead.Play();
            }
            else if (Input.GetKeyDown(KeyCode.S) && (ModeControl.numberOfColors >= 2 || ModeControl.numberOfLanes >= 2))
            {
                PressKey(Note.B);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -3);
                Lead.Play();
            }
            else if (Input.GetKeyDown(KeyCode.D) && (ModeControl.numberOfColors >= 3 || ModeControl.numberOfLanes >= 3))
            {
                PressKey(Note.C);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -1);
                Lead.Play();
            }

            else if (Input.GetKeyDown(KeyCode.F) && (ModeControl.numberOfColors>=4||ModeControl.numberOfLanes>=4))
            {
                PressKey(Note.D);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, 1);
                Lead.Play();
            }
            else if (Input.GetKeyDown(KeyCode.G) && (ModeControl.numberOfColors >= 5 || ModeControl.numberOfLanes >= 5)) 

            {
                PressKey(Note.E);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, 4);
                Lead.Play();
            }
        }

        if (Timer.IsStartOfLanePhase)
        {
            _selectedLanes.Clear();
        }

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
