using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Keyboard : MonoBehaviour
{
    public const float LaserDuration = 0.3f;
    
    public GameObject Laser;
    public GameObject LaneSelector;
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
        if (Timer.IsOnBeat && !_gotKeyForBeat)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PressKey(Note.A);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -6);
                Lead.Play();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                PressKey(Note.B);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -3);
                Lead.Play();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PressKey(Note.C);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, -1);
                Lead.Play();
            }

            else if (Input.GetKeyDown(KeyCode.F))
            {
                PressKey(Note.D);
                Lead.pitch = Mathf.Pow(AudioManager.PitchMultiplier, 1);
                Lead.Play();
            }
            else if (Input.GetKeyDown(KeyCode.G) && Stats.Instance.Difficult) 

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
