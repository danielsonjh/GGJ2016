using System.Collections.Generic;
using UnityEngine;

public static class Note
{
    public const string A = "A";
    public const string B = "B";
    public const string C = "C";

    public static readonly Dictionary<string, Vector2> KeyPositions = new Dictionary<string, Vector2>()
    {
        {Note.A, new Vector2(-2, 0)},
        {Note.B, new Vector2(0, 0)},
        {Note.C, new Vector2(2, 0)},
    };
}