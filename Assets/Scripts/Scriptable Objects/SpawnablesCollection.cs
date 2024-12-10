using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collection", menuName = "Scriptable Objects/Collection")]
public class SpawnablesCollection : ScriptableObject
{
    public SpawnableConfig[] spawnableConfigs;
}
