using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Keyboard : MonoBehaviour
{
    public const float NoteTime = 0.5f;
    public GameObject Laser;

    private SpriteRenderer _grayBoxRenderer;

    void Start()
    {
        _grayBoxRenderer = transform.FindChild("GrayBox").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Timer.IsOnBeat())
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
        Debug.Log(Timer.CurrentBeat);
        Debug.Log(Timer.IsColorBeat());
        ShowGrayBox(!Timer.IsColorBeat());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Stats.Instance.Lives--;
    }

    private void PressKey(Note note)
    {
        if (Timer.IsColorBeat())
        {
            var laser = Instantiate(Laser);
            laser.transform.position = Notes.KeyPositions[note];
            Destroy(laser, NoteTime);
        }
        else
        {
            // Add lane selector
        }
    }

    private void ShowGrayBox(bool shown)
    {
        _grayBoxRenderer.enabled = shown;
    }
}
