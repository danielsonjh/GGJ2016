using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Note
{
    A, B, C, D, E
}

public static class Notes
{
    public static readonly Dictionary<Note, Vector2> KeyPositions = new Dictionary<Note, Vector2>()
    {
        {Note.A, new Vector2(-2, 0)},
        {Note.B, new Vector2(0, 0)},
        {Note.C, new Vector2(2, 0)},
        {Note.D, new Vector2(4, 0)},
        {Note.E, new Vector2(6, 0)}
    };

    public static readonly Dictionary<Note, Color> EntityColor = new Dictionary<Note, Color>()
    {
        {Note.A, Color.red},
        {Note.B, Color.green},
        {Note.C, Color.blue},
        {Note.D, Color.yellow},
        {Note.E, new Color(1,0.7f, 0.8f) }
    };

    public static readonly Dictionary<Note, Color> SecondaryColor = new Dictionary<Note, Color>()
    {
        {Note.A, new Color(1, 0.6f, 0.3f)}, // orange
        {Note.B, new Color(0.5f, 1, 0.7f)}, // lime green
        {Note.C, new Color(0,5f, 1, 1)}, // cyan
        {Note.D, new Color(1, 1, 0.8f)}, // beige
        {Note.E, new Color(1, 0.7f, 0.8f) } //
    };

    public static int Length
    {
        get { return Enum.GetNames(typeof(Note)).Length; }
    }

    public static Note GetRandom()
    {
        return (Note)Random.Range(0, Length);
    }
    public static Note GetRandom(int max) {
        return (Note)Random.Range(0, max);
    }
}