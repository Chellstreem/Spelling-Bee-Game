using UnityEngine;

public class SpawnObject
{
    public GameObject gameObject;
    
    public SpawnableConfig.ObjectGroup objectGroup;    
    public float minPosX;
    public float maxPosX;
    public float minPosY;
    public float maxPosY;
    public int priorityWeight;
    public Transform cachedTransform; // Поле для кэширования Transform

    public SpawnObject(GameObject gameObject, SpawnableConfig.ObjectGroup objectSubGroup, float minPosX, float maxPosX, float minPosY, float maxPosY, int priorityWeight)
    {
        this.gameObject = gameObject;        
        objectGroup = objectSubGroup;
        this.minPosX = minPosX;
        this.maxPosX = maxPosX;
        this.minPosY = minPosY;
        this.maxPosY = maxPosY;
        this.priorityWeight = priorityWeight;
        cachedTransform = gameObject.transform;
    }


}
