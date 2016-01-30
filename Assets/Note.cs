using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Note
{
    A, B, C
}

public static class Notes
{
    public static readonly Dictionary<Note, Vector2> KeyPositions = new Dictionary<Note, Vector2>()
    {
        {Note.A, new Vector2(-2, 0)},
        {Note.B, new Vector2(0, 0)},
        {Note.C, new Vector2(2, 0)},
    };

    public static int Length
    {
        get
        {
            return Enum.GetNames(typeof(Note)).Length;
        }
    }

    public static Note GetRandom()
    {
        return (Note)Random.Range(0, Length);
    }
}