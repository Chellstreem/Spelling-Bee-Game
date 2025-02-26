using System.Collections;
using UnityEngine;

namespace Spawn
{
    public class DecorativeObjectSpawner : Spawner, ISpawner
    {
        private ISpawnableObjectProvider objectPool;        
        private ICoroutineRunner coroutineRunner;
        private Vector3 spawnPosition;

        private Coroutine spawnCoroutine;

        public DecorativeObjectSpawner(ISpawnableObjectProvider objectPool, ICoroutineRunnerProvider runnerRunner, GameConfig gameConfig)
        {
            spawnFrequency = gameConfig.DecorativeSpawnFrequency;
            this.objectPool = objectPool;            
            coroutineRunner = runnerRunner.GetCoroutineRunner();
            spawnPosition = gameConfig.SpawnPosition;
        }

        public override void StartSpawning()
        {
            if (spawnCoroutine == null)
            {
                spawnCoroutine = coroutineRunner.StartCor(SpawnObjects(SpawnableObjectType.Decorative, spawnFrequency));
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

        protected override Vector3 GetPosition(SpawnableObject spawnObject)
        {
            float z = spawnPosition.z;
            float x = Random.Range(spawnObject.MinPosX, spawnObject.MaxPosX);
            float y = Random.Range(spawnObject.MinPosY, spawnObject.MaxPosY);
            return new Vector3(x, y, z);
        }        

        protected override SpawnableObject GetObject(SpawnableObjectType objType)
        {
            return objectPool.GetObject(objType);
        }
    }
}

