using UnityEngine;

public class SpawnableObject
{
    private GameObject gameObject;
    private SpawnableObjectType objectGroup;
    private float minPosX;
    private float maxPosX;
    private float minPosY;
    private float maxPosY;
    private int priorityWeight;
    private Transform cachedTransform; // Поле для кэширования Transform

    public GameObject GameObject => gameObject;
    public SpawnableObjectType ObjectGroup => objectGroup;
    public float MinPosX => minPosX;
    public float MaxPosX => maxPosX;
    public float MinPosY => minPosY;
    public float MaxPosY => maxPosY;
    public int PriorityWeight => priorityWeight;
    public Transform CachedTransform => cachedTransform;

    public SpawnableObject(GameObject gameObject, SpawnableObjectType objectGroup, float minPosX, float maxPosX, float minPosY, float maxPosY, int priorityWeight)
    {
        this.gameObject = gameObject;        
        this.objectGroup = objectGroup;
        this.minPosX = minPosX;
        this.maxPosX = maxPosX;
        this.minPosY = minPosY;
        this.maxPosY = maxPosY;
        this.priorityWeight = priorityWeight;
        cachedTransform = gameObject.transform;
    }
}
