using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public const float NoteTime = 0.5f;
    public GameObject Laser;

    

    void Update()
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

    public void PressKey(string note)
    {
        Debug.Log(note);

        var laser = Instantiate(Laser);
        laser.transform.position = Note.KeyPositions[note];
        Destroy(laser, NoteTime);
    }
}
