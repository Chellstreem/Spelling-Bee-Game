using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public abstract class Spawner
{
    protected float spawnFrequency;

    public abstract void StartSpawning();

    public abstract void StopSpawning();

    protected virtual IEnumerator SpawnObjects(SpawnableObjectType objType, float spawnFrequency)
    {
        while (true)
        {
            SpawnableObject spawnObject = GetObject(objType);
            GameObject obj = spawnObject.GameObject;
            spawnObject.CachedTransform.position = GetPosition(spawnObject);
            obj.SetActive(true);
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    protected abstract Vector3 GetPosition(SpawnableObject spawnObject);

    protected abstract SpawnableObject GetObject(SpawnableObjectType objType);    
}
