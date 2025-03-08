using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Spawn
{
    public class SceneObjectPool : IPool, ISceneObjectProvider
    {
        private readonly SceneObjectCollection collection;
        private Dictionary<SceneObjectType, GameObject[]> poolDictionary;
        private GameObject poolHolder;

        public SceneObjectPool(SceneObjectCollection collection, DiContainer container)
        {
            this.collection = collection;            
        }

        public void InitializePool()
        {
            poolDictionary = new Dictionary<SceneObjectType, GameObject[]>();
            poolHolder = new GameObject("Scene Object Pool");

            foreach (var objectConfig in collection.SceneObjects)
            {
                var objectType = objectConfig.ObjectType;

                if (!poolDictionary.ContainsKey(objectType))
                    poolDictionary[objectType] = new GameObject[objectConfig.AmountOfCopies];

                for (int i = 0; i < poolDictionary[objectType].Length; i++)
                {
                    GameObject obj = Object.Instantiate(objectConfig.Prefab, objectConfig.SpawnPosition, objectConfig.Prefab.transform.rotation, poolHolder.transform);
                    obj.gameObject.SetActive(false);
                    poolDictionary[objectType][i] = obj;
                }
            }
        }

        public GameObject[] GetObjects(SceneObjectType objectType)
        {
            if (!poolDictionary.ContainsKey(objectType) || poolDictionary[objectType].Length == 0)
            {
                Debug.LogWarning("Не найден.");
                return null;
            }

            return poolDictionary[objectType];
        }
    }
}
