using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBehaviourConfig", menuName = "Scriptable Objects/PlayerBehaviourConfig")]
public class PlayerBehaviourConfig : ScriptableObject
{
    [SerializeField] private Vector3 newColliderCenter;

    public Vector3  NewColliderCenter => newColliderCenter;
}
