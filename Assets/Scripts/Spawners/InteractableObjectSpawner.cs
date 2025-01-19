using System.Collections;
using UnityEngine;

namespace Spawners
{
    public class InteractableObjectSpawner : Spawner
    {
        public override float SpawnFrequency { get; }
        private ISpawnableObjectProvider objectPool;
        private ICoroutineRunner coroutineRunner;
        private Vector3 spawnPosition;

        private Coroutine spawnCoroutine;

        public InteractableObjectSpawner(ISpawnableObjectProvider objectPool, ICoroutineRunnerHolder runnerHolder, GameConfig gameConfig)
        {
            SpawnFrequency = gameConfig.InteractableSpawnFrequency;
            this.objectPool = objectPool;
            coroutineRunner = runnerHolder.CoroutineRunner;
            spawnPosition = gameConfig.SpawnPosition;
        }

        public override void StartSpawning()
        {
            if (spawnCoroutine == null)
            {
                spawnCoroutine = coroutineRunner.StartCor(SpawnObjects(SpawnableObjectType.Interactable, SpawnFrequency));
            }            
        }

        public override void StopSpawning()
        {
            if (spawnCoroutine != null)
            {
                coroutineRunner.StopCor(spawnCoroutine);
                spawnCoroutine = null;
            }
        }

        private IEnumerator SpawnObjects(SpawnableObjectType objType, float spawnFrequency)
        {
            while (true)
            {
                SpawnableObject spawnObject = objectPool.GetObject(objType);
                GameObject obj = spawnObject.GameObject;
                spawnObject.CachedTransform.position = GetRandomPosition(spawnObject);
                obj.SetActive(true);
                yield return new WaitForSeconds(spawnFrequency);
            }
        }

        private Vector3 GetRandomPosition(SpawnableObject spawnObject)
        {
            float z = spawnPosition.z;
            float x = Random.Range(spawnObject.MinPosX, spawnObject.MaxPosX);
            float y = (Random.value < 0.5f ? spawnObject.MinPosY : spawnObject.MaxPosY);
            return new Vector3(x, y, z);
        }
    }
}
