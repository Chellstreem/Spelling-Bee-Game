using System.Collections.Generic;
using UnityEngine;


public static class GameplayData
{
    public static float Speed = 20;
    public static List<string> SavedWords = new List<string> { "test", "best" }; // Значение по умолчанию
    public static readonly Vector3 PlayerPosition = new Vector3(-1.33f, 0, -42.74f);
}