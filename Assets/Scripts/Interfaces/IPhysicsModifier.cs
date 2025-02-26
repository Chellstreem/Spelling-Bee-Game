using UnityEngine;

public interface IPhysicsModifier
{
    public void SetGravity(Rigidbody rb, bool isEnabled);
    public void SetBoxColliderCenter(BoxCollider boxCollider, Vector3 newPosition);
}
