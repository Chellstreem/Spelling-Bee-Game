using UnityEngine;

public class PhysicsModifier : IPhysicsModifier
{
    public void SetGravity(Rigidbody rb, bool isEnabled) => rb.useGravity = isEnabled;

    public void SetBoxColliderCenter(BoxCollider boxCollider, Vector3 newPosition)
    {
        boxCollider.center = newPosition;
    }
}
