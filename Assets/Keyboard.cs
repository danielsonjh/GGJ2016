using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Keyboard : MonoBehaviour
{
    public const float LaserDuration = 0.3f;
    public GameObject Laser;
    public GameObject LaneSelector;

    private readonly List<Note> _selectedLanes = new List<Note>();

    private SpriteRenderer _grayBoxRenderer;

    void Start()
    {
        _grayBoxRenderer = transform.FindChild("GrayBox").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Timer.IsOnBeat)
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
        }

        if (Timer.IsStartOfLanePhase)
        {
            _selectedLanes.Clear();
        }

        ShowGrayBox(!Timer.IsColorBeat);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Stats.Instance.Lives--;
    }

    private void PressKey(Note note)
    {
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
}
