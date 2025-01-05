using System.Collections.Generic;
using UnityEngine;
using static SpawnableConfig;


public class SpawnableObjectPool : MonoBehaviour, IPool
{
    private SpawnablesCollection collection;    

    private Dictionary<ObjectGroup, List<SpawnableObject>> poolDictionary;
    private Dictionary<GameObject, SpawnableObject> SpawnObjectMap; // Хранит соответствие объектов и групп для быстрого возврата обьекта в пул

    public void Initialize(SpawnablesCollection collection)
    {
        this.collection = collection;

        InitializePools();
        EventManager.OnObjectReturnedToPool += ReturnObject;
    }

    public void InitializePools()
    {
        poolDictionary = new Dictionary<ObjectGroup, List<SpawnableObject>>();
        SpawnObjectMap = new Dictionary<GameObject, SpawnableObject>();

        foreach (var spawnableConfig in collection.SpawnableConfigs)
        {
            var objectGroup = spawnableConfig.ObjGroup;

            if (!poolDictionary.ContainsKey(objectGroup))
                poolDictionary[objectGroup] = new List<SpawnableObject>();
            

            for (int i = 0; i < spawnableConfig.PriorityWeight; i++)
            {
                GameObject obj = Instantiate(spawnableConfig.Prefab, transform);
                obj.SetActive(false);

                float minPosX = spawnableConfig.MinPosX;
                float maxPosX = spawnableConfig.MaxPosX;
                float minPosY = spawnableConfig.MinPosY;
                float maxPosY = spawnableConfig.MaxPosY;
                int priorityWeight = spawnableConfig.PriorityWeight;

                SpawnableObject spawnObject = new SpawnableObject(obj, objectGroup, minPosX, maxPosX, minPosY, maxPosY, priorityWeight);
                poolDictionary[objectGroup].Add(spawnObject);
                SpawnObjectMap[obj] = spawnObject;
            }
        }
    }

    public SpawnableObject GetRandomObject(ObjectGroup objectSubGroup)
    {
        if (!poolDictionary.ContainsKey(objectSubGroup))
        {
            Debug.Log($"Пул с именем группы {objectSubGroup.ToString()} не найден!");
            return null;
        }

        var pool = poolDictionary[objectSubGroup];

        if (pool.Count > 0)
        {
            int randomIndex = Random.Range(0, pool.Count);
            SpawnableObject randomSpawnObject = pool[randomIndex];
            pool[randomIndex] = pool[pool.Count - 1];
            pool.RemoveAt(pool.Count - 1);
            
            return randomSpawnObject;
        }
        else
        {
            Debug.LogWarning($"Пул {objectSubGroup.ToString()} пуст!");
            return null;
        }
    }

    public void ReturnObject(GameObject gameObject)
    {
        if (!SpawnObjectMap.TryGetValue(gameObject, out var spawnObject))
        {
            Debug.LogError("Попытка вернуть объект, не принадлежащий пулу!");
            return;
        }
        gameObject.transform.position = transform.position;
        gameObject.SetActive(false);
        poolDictionary[spawnObject.ObjectGroup].Add(spawnObject); 
    }

    private void OnDestroy()
    {
        EventManager.OnObjectReturnedToPool -= ReturnObject;
    }
}