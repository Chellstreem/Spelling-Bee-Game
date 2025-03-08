using UnityEngine;

public class OnMissileCollision : IEvent
{
    public Vector3 Position { get; private set; }

    public OnMissileCollision(Vector3 position)
    {
        Position = position;
    }
}
