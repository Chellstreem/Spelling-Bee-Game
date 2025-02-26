using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLetterChecked : IEvent
{
    public string Letter {  get; private set; }
    public bool IsCorrect { get; private set; }
    public Vector3 Position { get; private set; }

    public OnLetterChecked(string letter, bool isCorrect, Vector3 position)
    {
        Letter = letter;
        IsCorrect = isCorrect;
        Position = position;
    }
}
