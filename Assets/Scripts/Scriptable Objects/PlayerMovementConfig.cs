using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Scriptable Objects/PlayerMovementConfig")]
public class PlayerMovementConfig : ScriptableObject
{
    [SerializeField] private GameObject player;    
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float positionThreshold;
    [SerializeField] private Vector3 playerPosition;

    public GameObject Player => player;    
    public float MoveDistance => moveDistance;
    public float MoveSpeed => moveSpeed;
    public float PositionThreshold => positionThreshold;
    public Vector3 PlayerPosition => playerPosition;


}
