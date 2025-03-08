using UnityEngine;

[CreateAssetMenu(fileName = "SpawnConfig", menuName = "Scriptable Objects/SpawnConfig")]
public class SpawnConfig : ScriptableObject
{
    [SerializeField] private SpawnableObjectConfig[] spawnableObjects;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float decorativeSpawnFrequency = 1.5f;
    [SerializeField] private float interactableSpawnFrequency = 0.5f;
    
    public SpawnableObjectConfig[] SpawnableObjects => spawnableObjects;
    public Vector3 SpawnPosition => spawnPosition;
    public float DecorativeSpawnFrequency => decorativeSpawnFrequency;
    public float InteractableSpawnFrequency => interactableSpawnFrequency;
}