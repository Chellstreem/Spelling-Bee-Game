using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneObjectConfig", menuName = "Scriptable Objects/SceneObjectConfig")]
public class SceneObjectConfig : ScriptableObject
{
    [SerializeField] private SceneObjectType objectType;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private int amountOfCopies;

    public SceneObjectType ObjectType => objectType;
    public GameObject Prefab => prefab;
    public Vector3 SpawnPosition => spawnPosition;
    public int AmountOfCopies => amountOfCopies;    
}
