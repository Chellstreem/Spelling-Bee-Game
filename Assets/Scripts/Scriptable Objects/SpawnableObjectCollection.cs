using UnityEngine;

[CreateAssetMenu(fileName = "SpawnableObjectCollection", menuName = "Scriptable Objects/SpawnableObjectCollection")]
public class SpawnableObjectCollection : ScriptableObject
{
   [SerializeField] private SpawnableConfig[] spawnableObjects;   

    public SpawnableConfig[] SpawnableObjects => spawnableObjects;
}
