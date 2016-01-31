using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Keyboard : MonoBehaviour
{
    public const float LaserDuration = 0.3f;
    
    public GameObject Laser;
    public GameObject LaneSelector;
    public Sprite LaneSelectSprite;
    public Sprite ColorSelectSprite;

    public static bool GotKeyForBeat;
    public AudioSource Lead;

    private bool _gotKeyForBeat;

    private readonly List<Note> _selectedLanes = new List<Note>();

    void Start()
    {
        Timer.OnChangeBeat += ResetKeyForBeatFlag;
        Timer.OnChangeBeat += ChangeKeyIcon;
        ChangeKeyIcon();
    }

    void OnDestroy()
    {
        Timer.OnChangeBeat -= ResetKeyForBeatFlag;
        Timer.OnChangeBeat -= ChangeKeyIcon;
    }

    void Update()
    {
        if (Timer.IsOnBeat && !GotKeyForBeat)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PressKey(Note.A);
                PlayLeadAudio(-6);
            }
            else if (Input.GetKeyDown(KeyCode.S) && (ModeControl.numberOfColors >= 2 || ModeControl.numberOfLanes >= 2))
            {
                PressKey(Note.B);
                PlayLeadAudio(-3);
            }
            else if (Input.GetKeyDown(KeyCode.D) && (ModeControl.numberOfColors >= 3 || ModeControl.numberOfLanes >= 3))
            {
                PressKey(Note.C);
                PlayLeadAudio(-1);
            }

            else if (Input.GetKeyDown(KeyCode.F) && (ModeControl.numberOfColors>=4||ModeControl.numberOfLanes>=4))
            {
                PressKey(Note.D);
                PlayLeadAudio(1);
            }
            else if (Input.GetKeyDown(KeyCode.G) && (ModeControl.numberOfColors >= 5 || ModeControl.numberOfLanes >= 5)) 

            {
                PressKey(Note.E);
                PlayLeadAudio(4);
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
                laser.GetComponent<LaserBehavior>().Note = note;
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
        clone.transform.position = Notes.KeyPositions[note]+new Vector2(0,0.8f);
        return clone;
    }

    private void ResetKeyForBeatFlag()
    {
        GotKeyForBeat = false;
    }

    private void ChangeKeyIcon()
    {
        for (int i = 0; i < ModeControl.numberOfLanes; i++)
        {
            var child = transform.GetChild(i);
            var spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (Timer.IsColorBeat)
            {
                spriteRenderer.sprite = ColorSelectSprite;
                spriteRenderer.color = Notes.EntityColor[(Note) i];
            }
            else
            {
                spriteRenderer.sprite = LaneSelectSprite;
                spriteRenderer.color = Color.white;
            }

        }
        
        for (int i = ModeControl.numberOfLanes; i<5; i++)
        {
            var child = transform.GetChild(i);
            var spriteRenderer = child.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.clear;
            
        }
    }

    private void PlayLeadAudio(int pitchShift)
    {
        var audio = Instantiate(Lead);
        audio.pitch = Mathf.Pow(AudioManager.PitchMultiplier, pitchShift);
        audio.Play();
        Destroy(audio, 10f);
    }
}
