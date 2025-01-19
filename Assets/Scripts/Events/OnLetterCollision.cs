using UnityEngine;

public class OnLetterCollision : IEvent
{
    public string Value { get; private set; }
    public Vector3 Position { get; private set; }

    public OnLetterCollision(string value, Vector3 position)
    {
        Value = value;
        Position = position;
    }
}

