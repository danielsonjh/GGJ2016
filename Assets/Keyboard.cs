using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Keyboard : MonoBehaviour
{
    public const float NoteTime = 0.5f;
    public GameObject Laser;
    
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
    }

    public void PressKey(Note note)
    {
        Debug.Log(note);

        var laser = Instantiate(Laser);
        laser.transform.position = Notes.KeyPositions[note];
        Destroy(laser, NoteTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Score.Instance.Lives--;
    }
}
