using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealthConfig", menuName = "Scriptable Objects/PlayerHealthConfig")]
public class PlayerHealthConfig : ScriptableObject
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int livesOnStart = 2;
    [SerializeField] private Vector3 healthBarLocalPosition;
    [SerializeField] private float healthBarFillingSpeed;
    public int MaxLives => maxLives;
    public int LivesOnStart => livesOnStart;
    public Vector3 HealthBarLocalPosition => healthBarLocalPosition;
    public float HealthBarFillingSpeed => healthBarFillingSpeed;

}
