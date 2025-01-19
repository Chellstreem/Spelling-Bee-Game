using System.Collections;
using UnityEngine;

namespace Spawners
{
    public class DecorativeObjectSpawner : Spawner, IEventSubscriber<OnMovingStarted>, IEventSubscriber<OnMovingStopped>
    {
        public override float SpawnFrequency { get; }
        private ISpawnableObjectProvider objectPool;
        private IEventManager eventManager;
        private ICoroutineRunner coroutineRunner;
        private Vector3 spawnPosition;

        private Coroutine spawnCoroutine;

        public DecorativeObjectSpawner(ISpawnableObjectProvider objectPool, IEventManager eventManager, ICoroutineRunnerHolder runnerHolder, GameConfig gameConfig)
        {
            SpawnFrequency = gameConfig.DecorativeSpawnFrequency;
            this.objectPool = objectPool;
            this.eventManager = eventManager;
            coroutineRunner = runnerHolder.CoroutineRunner;
            spawnPosition = gameConfig.SpawnPosition;

            this.eventManager.Subscribe<OnMovingStarted>(this);
            this.eventManager.Subscribe<OnMovingStopped>(this);
        }

        public override void StartSpawning()
        {
            if (spawnCoroutine == null)
            {
                spawnCoroutine = coroutineRunner.StartCor(SpawnObjects(SpawnableObjectType.Decorative, SpawnFrequency));
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

        public void OnEvent(OnMovingStarted eventData)
        {
            StartSpawning();
        }

        public void OnEvent(OnMovingStopped eventData)
        {
            StopSpawning();
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
            float y = Random.Range(spawnObject.MinPosY, spawnObject.MaxPosY);
            return new Vector3(x, y, z);
        }
    }
}

