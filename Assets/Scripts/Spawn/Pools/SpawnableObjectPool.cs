﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Spawn
{
    public class SpawnableObjectPool : IPool, ISpawnableObjectProvider, ISpawnableObjectReturner
    {
        private readonly SpawnConfig spawnConfig;
        private readonly DiContainer container;

        private Dictionary<SpawnableObjectType, List<SpawnableObject>> poolDictionary; // Хранит пулы по типу объекта
        private Dictionary<GameObject, SpawnableObject> SpawnObjectMap; // Хранит соответствие объектов и групп для быстрого возврата обьекта в пул
        private GameObject poolHolder;

        public SpawnableObjectPool(SpawnConfig spawnConfig, DiContainer container)
        {
            this.spawnConfig = spawnConfig;
            this.container = container;
        }

        public void InitializePool()
        {
            poolDictionary = new Dictionary<SpawnableObjectType, List<SpawnableObject>>();
            SpawnObjectMap = new Dictionary<GameObject, SpawnableObject>();

            poolHolder = new GameObject("Spawnable Object Pool");

            foreach (SpawnableObjectConfig spawnableConfig in spawnConfig.SpawnableObjects)
            {
                SpawnableObjectType objectType = spawnableConfig.ObjType;

                if (!poolDictionary.ContainsKey(objectType))
                    poolDictionary[objectType] = new List<SpawnableObject>();

                for (int i = 0; i < spawnableConfig.PriorityWeight; i++)
                {
                    GameObject obj = container.InstantiatePrefab(spawnableConfig.Prefab, poolHolder.transform);
                    obj.SetActive(false);

                    SpawnableObject spawnObject = CreateSpawnableObject(obj, objectType, spawnableConfig);
                    poolDictionary[objectType].Add(spawnObject);
                    SpawnObjectMap[obj] = spawnObject;
                }
            }
        }

        public SpawnableObject GetObject(SpawnableObjectType objectType)
        {
            if (!poolDictionary.ContainsKey(objectType))
            {
                Debug.Log($"Пул с именем группы {objectType} не найден!");
                return null;
            }

            var pool = poolDictionary[objectType];

            if (pool.Count > 0)
            {
                int randomIndex = Random.Range(0, pool.Count);
                SpawnableObject SpawnObject = pool[randomIndex];
                pool[randomIndex] = pool[pool.Count - 1];
                pool.RemoveAt(pool.Count - 1);

                return SpawnObject;
            }
            else
            {
                Debug.LogWarning($"Пул {objectType} пуст!");
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
            gameObject.transform.position = poolHolder.transform.position;
            gameObject.SetActive(false);
            poolDictionary[spawnObject.ObjectGroup].Add(spawnObject);
        }

        private SpawnableObject CreateSpawnableObject(GameObject obj, SpawnableObjectType objType, SpawnableObjectConfig config)
        {
            float minPosX = config.MinPosX;
            float maxPosX = config.MaxPosX;
            float minPosY = config.MinPosY;
            float maxPosY = config.MaxPosY;
            int priorityWeight = config.PriorityWeight;

            return new SpawnableObject(obj, objType, minPosX, maxPosX, minPosY, maxPosY, priorityWeight);
        }
    }
}