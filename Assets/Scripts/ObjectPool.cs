using System.Collections.Generic;

using UnityEngine;
using static SpawnableConfig;


public class ObjectPool : MonoBehaviour
{
    [SerializeField] SpawnablesCollection collection;    

    private Dictionary<ObjectGroup, List<SpawnObject>> poolDictionary;
    private Dictionary<GameObject, SpawnObject> SpawnObjectMap; // Хранит соответствие объектов и групп для быстрого возврата обьекта в пул

    public void Initialize()
    {
        InitializePools();

        EventBus.OnObjectReturnedToPool += ReturnObject;
    }

    private void InitializePools()
    {
        poolDictionary = new Dictionary<ObjectGroup, List<SpawnObject>>();
        SpawnObjectMap = new Dictionary<GameObject, SpawnObject>();

        foreach (var spawnableConfig in collection.spawnableConfigs)
        {
            var objectGroup = spawnableConfig.objectGroup;

            if (!poolDictionary.ContainsKey(objectGroup))
                poolDictionary[objectGroup] = new List<SpawnObject>();
            

            for (int i = 0; i < spawnableConfig.priorityWeight; i++)
            {
                GameObject instance = Instantiate(spawnableConfig.prefab, transform);
                instance.SetActive(false);

                float minPosX = spawnableConfig.minPosX;
                float maxPosX = spawnableConfig.maxPosX;
                float minPosY = spawnableConfig.minPosY;
                float maxPosY = spawnableConfig.maxPosY;
                int priorityWeight = spawnableConfig.priorityWeight;

                SpawnObject spawnObject = new SpawnObject(instance, objectGroup, minPosX, maxPosX, minPosY, maxPosY, priorityWeight);
                poolDictionary[objectGroup].Add(spawnObject);
                SpawnObjectMap[instance] = spawnObject;
            }
        }
    }

    public SpawnObject GetRandomObject(ObjectGroup objectSubGroup)
    {
        if (!poolDictionary.ContainsKey(objectSubGroup))
        {
            Debug.LogError($"Пул с именем группы {objectSubGroup.ToString()} не найден!");
            return null;
        }

        var pool = poolDictionary[objectSubGroup];

        if (pool.Count > 0)
        {
            int randomIndex = Random.Range(0, pool.Count);
            SpawnObject randomSpawnObject = pool[randomIndex];
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
        poolDictionary[spawnObject.objectGroup].Add(spawnObject); 
    }

    private void OnDestroy()
    {
        EventBus.OnObjectReturnedToPool -= ReturnObject;
    }
}