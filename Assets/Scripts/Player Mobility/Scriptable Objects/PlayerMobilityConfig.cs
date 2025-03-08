using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMobilityConfig", menuName = "Scriptable Objects/PlayerMobilityConfig")]
public class PlayerMobilityConfig : ScriptableObject
{
    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float positionThreshold = 0.001f;
    [SerializeField] private Vector3 lowerPlayerPosition;
    [SerializeField] private Vector3 upperPlayerPosition;

    public float MoveSpeed => moveSpeed;
    public float PositionThreshold => positionThreshold;
    public Vector3 LowerPlayerPosition => lowerPlayerPosition;
    public Vector3 UpperPlayerPosition => upperPlayerPosition;    
}
