using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneObject", menuName = "Scriptable Objects/SceneObject")]
public class SceneObject : ScriptableObject
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Vector3 spawnPosition;

    public GameObject Obj => obj;
    public Vector3 SpawnPosition => spawnPosition;
}
