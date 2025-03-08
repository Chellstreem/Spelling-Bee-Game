using UnityEngine;

namespace Spawn
{
    public class DecorativeObjectSpawner : Spawner, ISpawner
    {
        private readonly ISpawnableObjectProvider objectPool;        
        private readonly ICoroutineRunner coroutineRunner;
        private readonly Vector3 spawnPosition;

        private Coroutine spawnCoroutine;

        public DecorativeObjectSpawner(ISpawnableObjectProvider objectPool, ICoroutineRunner coroutineRunner, SpawnConfig spawnConfig)
        {
            spawnFrequency = spawnConfig.DecorativeSpawnFrequency;
            this.objectPool = objectPool;            
            this.coroutineRunner = coroutineRunner;
            spawnPosition = spawnConfig.SpawnPosition;
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

