using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLetterChecked : IEvent
{
    public bool IsCorrect { get; private set; }
    public Vector3 Position { get; private set; }

    public OnLetterChecked(bool isCorrect, Vector3 position)
    {
        IsCorrect = isCorrect;
        Position = position;       
    }
}
