using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Scriptable Objects/SpawnerConfig")]
public class SpawnerConfig : ScriptableObject
{

    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float plantSpawnFrequency;
    [SerializeField] private float animalSpawnFrequency;
    [SerializeField] private float interactableSpawnFrequency;

    public Vector3 SpawnPosition => spawnPosition;
    public float PlantSpawnFrequency => plantSpawnFrequency;
    public float AnimalSpawnFrequency => animalSpawnFrequency;
    public float InteractableSpawnFrequency => interactableSpawnFrequency;
}
