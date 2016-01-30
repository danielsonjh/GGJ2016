using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public const float NoteTime = 0.5f;
    public GameObject Laser;

    private readonly Dictionary<string, Vector2> _keyPosition = new Dictionary<string, Vector2>()
    {
        {"A", new Vector2(-2, 0)},
        {"B", new Vector2(0, 0)},
        {"C", new Vector2(2, 0)},
    };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PressKey("A");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PressKey("B");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PressKey("C");
        }
    }

    public void PressKey(string note)
    {
        Debug.Log(note);

        var laser = Instantiate(Laser);
        laser.transform.position = _keyPosition[note];
        Destroy(laser, NoteTime);
    }
}
